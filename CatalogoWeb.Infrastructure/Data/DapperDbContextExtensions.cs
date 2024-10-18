using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades.Filtros;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CatalogoWeb.Infrastructure.Data
{
    public static class DapperDbContextExtensions
    {
        public static async Task<IEnumerable<T>> QueryAsync<T>(
        this DbContext context,
        string text,
        object parameters = null,
        int? timeout = null,
        CommandType? type = null
    )
        {
            using var command = new DapperEFCoreCommand(
                context,
                text,
                parameters,
                timeout,
                type
            );

            var connection = context.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }

        public static async Task<T> QueryFirstAsync<T>(
         this DbContext context,
         string text,
         object parameters = null,
         int? timeout = null,
         CommandType? type = null
     )
        {
            using var command = new DapperEFCoreCommand(
                context,
                text,
                parameters,
                timeout,
                type
            );

            var connection = context.Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }

        public static async Task<PagedModel<T>> QueryAsyncPaged<T>(
        this DbContext context,
        string text,
        string textCount,
        PagedParams paged,
        object parameters = null,
        int? timeout = null,
        CommandType? type = null
    )
        {
            if (paged != null)
            {
                if (paged.PageNumber == 0) paged.PageNumber = 1;
                if (paged.PageSize == 0) paged.PageSize = 10;
                if (paged.PageSize > 500) paged.PageSize = 500;
                string sql = "";
                bool orderByDesc = false;
                if (!String.IsNullOrEmpty(paged.Order))
                {
                    orderByDesc = (paged.Order[0] == '-' ? true : false);
                    if (paged.Order[0] == '-' || paged.Order[0] == '+') paged.Order = paged.Order.Substring(1, paged.Order.Length - 1);
                    sql = " ORDER BY " + paged.Order + " " + (orderByDesc == true ? "DESC" : "ASC");
                }
                if (paged.PageNumber > 0 && paged.PageSize > 0)
                    sql += " OFFSET " + ((paged.PageNumber - 1) * paged.PageSize) + " ROWS FETCH NEXT " + paged.PageSize + " ROWS ONLY";
                text += sql;
            }

            using var command = new DapperEFCoreCommand(
                context,
                text,
                parameters,
                timeout,
                type
            );

            using var commandCount = new DapperEFCoreCommand(
                context,
                textCount,
                parameters,
                timeout,
                type
            );
            var connection = context.Database.GetDbConnection();
            var totalItemsCountTask = await connection.QueryAsync<int>(commandCount.Definition);

            int totalItens = totalItemsCountTask.DefaultIfEmpty(0).FirstOrDefault();
            var pagedModel = new PagedModel<T>();

            pagedModel.CurrentPage = (paged.PageNumber < 0) ? 1 : paged.PageNumber;
            pagedModel.PageSize = paged.PageSize;
            pagedModel.Order = paged.Order;
            pagedModel.TotalItems = totalItens;
            pagedModel.TotalPages = (int)Math.Ceiling(pagedModel.TotalItems / (double)pagedModel.PageSize);
            var itens = await connection.QueryAsync<T>(command.Definition);
            pagedModel.Items = itens.ToList();

            return pagedModel;
        }


        public static async Task<int> ExecuteAsync(
            this DbContext context,
            string text,
            object parameters = null,
            int? timeout = null,
            CommandType? type = null
        )
        {
            using var command = new DapperEFCoreCommand(
                context,
                text,
                parameters,
                timeout,
                type
            );

            var connection = context.Database.GetDbConnection();
            return await connection.ExecuteAsync(command.Definition);
        }
    }
}
