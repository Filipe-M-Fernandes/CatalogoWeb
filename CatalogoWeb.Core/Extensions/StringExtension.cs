namespace CatalogoWeb.Core.Extensions
{
    public static class StringExtension
    {
        public static bool HasValue(this string texto)
        {
            return !string.IsNullOrEmpty(texto);
        }
    }
}
