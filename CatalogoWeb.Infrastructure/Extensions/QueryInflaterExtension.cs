using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CatalogoWeb.Infrastructure.Extensions
{
    public static class QueryInflaterExtension
    {
        public static IQueryable<T> Inflate<T>(this IQueryable<T> query, IEnumerable<string> expands) where T : class
        {
            if (expands?.Any() != true) return query;
            foreach (var expand in expands)
            {
                var parts = expand.Split('.');
                var properties =
                    typeof(T).GetProperties(BindingFlags.Public | BindingFlags.FlattenHierarchy |
                                            BindingFlags.Instance);
                InflateProperties(ref query, parts, properties, expand);
            }

            return query;
        }

        private static void InflateProperties<T>(ref IQueryable<T> query, IReadOnlyList<string> parts, PropertyInfo[] properties, string expand) where T : class
        {
            for (var i = 0; i < parts.Count; i++)
            {
                var property = properties.FirstOrDefault(p =>
                    string.Compare(p.Name, parts[i], StringComparison.OrdinalIgnoreCase) == 0);
                if (property == null) break;
                if (InflateProperty(ref query, parts, ref properties, expand, property, i)) break;
            }
        }

        private static bool InflateProperty<T>(ref IQueryable<T> query, IReadOnlyList<string> parts, ref PropertyInfo[] properties, string expand, PropertyInfo property, int i) where T : class
        {
            var type = property.PropertyType;
            if (type.IsArray && type.GetElementType()?.IsValueType == true) return false;
            if (IsList(property.PropertyType) && IncludeList(ref query, parts, ref properties, expand, property, i))
                return true;
            return IncludeClass(ref query, parts, ref properties, expand, i, property);
        }

        private static bool IncludeList<T>(ref IQueryable<T> query, IReadOnlyList<string> parts, ref PropertyInfo[] properties, string expand, PropertyInfo property, int i) where T : class
        {
            var prop = property.PropertyType.GenericTypeArguments.FirstOrDefault(t => t.IsClass);
            if (prop == null) return true;

            if (i == parts.Count - 1)
            {
                query = query.Include(expand);
                return true;
            }

            properties =
                prop.GetProperties(BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance);

            return false;
        }

        private static bool IncludeClass<T>(ref IQueryable<T> query, IReadOnlyList<string> parts, ref PropertyInfo[] properties, string expand, int i, PropertyInfo property) where T : class
        {
            if (i == parts.Count - 1 && property.PropertyType.IsClass && property.PropertyType != typeof(string))
            {
                query = query.Include(expand);
                return true;
            }

            var propertyType = property.PropertyType;

            if (IsList(propertyType)) propertyType = propertyType.GetGenericArguments().First();

            properties =
                propertyType.GetProperties(BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance);

            return false;
        }

        private static bool IsList(Type type) => type.IsGenericType &&
                                                 typeof(ICollection<>).IsAssignableFrom(
                                                     type.GetGenericTypeDefinition());

    }
}
