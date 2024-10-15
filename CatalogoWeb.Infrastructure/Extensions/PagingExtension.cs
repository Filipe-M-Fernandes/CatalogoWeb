using CatalogoWeb.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoWeb.Infrastructure.Extensions
{
    public static class PagingExtension
    {
        public static async Task<PagedModel<TModel>> PaginateAsync<TModel>(
       this IQueryable<TModel> query,
       int page,
       int limit,
       string order)
       where TModel : class
        {
            if (page == 0) page = 1;
            if (limit == 0) limit = 10;
            if (limit > 500) limit = 500;

            var paged = new PagedModel<TModel>();

            page = (page < 0) ? 1 : page;

            paged.CurrentPage = page;
            paged.PageSize = limit;
            paged.Order = order;


            var totalItemsCountTask = await query.CountAsync();

            var startRow = (page - 1) * limit;
            if (!string.IsNullOrEmpty(order))
            {
                var orderByDesc = (order[0] == '-' ? true : false);
                if (order[0] == '-' || order[0] == '+' || order[0] == ' ') paged.Order = order.Substring(1, order.Length - 1);

                if (orderByDesc == true)
                {
                    paged.Items = await query
                   .OrderByDescending((string)paged.Order)
                   .Skip(startRow)
                   .Take(limit)
                   .ToListAsync();
                }
                else
                {
                    paged.Items = await query
                   .OrderBy((string)paged.Order)
                   .Skip(startRow)
                   .Take(limit)
                   .ToListAsync();
                }
            }
            else
            {
                paged.Items = await query
                .Skip(startRow)
                .Take(limit)
                .ToListAsync();
            }


            paged.TotalItems = totalItemsCountTask;
            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)limit);

            return paged;

        }
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            string[] orders = propertyName.Split(',');
            IOrderedQueryable<T> _retorno = source.OrderBy(ToLambda<T>(orders[0])); ;

            if (orders.Count() == 1)
                return _retorno;
            int count = 0;
            foreach (var order in orders)
            {
                if (count == 0) { _retorno = source.OrderBy(ToLambda<T>(order)); }
                else
                {
                    string ordernacao;
                    var orderByDesc = (order[0] == '-' ? true : false);
                    if (order[0] == '-' || order[0] == '+' || order[0] == ' ') ordernacao = order.Substring(1, order.Length - 1);
                    if (orderByDesc == true)
                    {
                        _retorno = _retorno.ThenByDescending(ToLambda<T>(order));
                    }
                    else
                    {
                        _retorno = _retorno.ThenBy(ToLambda<T>(order));
                    }
                }
                count++;
            }

            return _retorno;
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            string[] orders = propertyName.Split(',');
            IOrderedQueryable<T> _retorno = source.OrderByDescending(ToLambda<T>(orders[0])); ;

            if (orders.Count() == 1)
                return _retorno;
            int count = 0;
            foreach (var order in orders)
            {
                if (count == 0) { _retorno = source.OrderByDescending(ToLambda<T>(order)); }
                else
                {
                    string ordernacao;
                    var orderByDesc = (order[0] == '-' ? true : false);
                    if (order[0] == '-' || order[0] == '+' || order[0] == ' ') ordernacao = order.Substring(1, order.Length - 1);
                    if (orderByDesc == true)
                    {
                        _retorno = _retorno.ThenByDescending(ToLambda<T>(order));
                    }
                    else
                    {
                        _retorno = _retorno.ThenBy(ToLambda<T>(order));
                    }
                }
                count++;
            }

            return _retorno;
        }
        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return source.ThenByDescending(ToLambda<T>(propertyName));
        }
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return source.ThenBy(ToLambda<T>(propertyName));
        }
        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }
    }
}
