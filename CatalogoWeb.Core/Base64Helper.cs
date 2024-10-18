namespace CatalogoWeb.Core
{
    public class Base64Helper
    {
        public static string EncodeTo64(string toEncode)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(toEncode));
        }

        public static string DecodeFrom64(string encodedData)
        {
            if (encodedData != null)
            {
                var base64EncodedBytes = Convert.FromBase64String(encodedData);
                var retorno = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                return retorno;
            }
            else
            {
                return null;
            }

        }

    }
}
