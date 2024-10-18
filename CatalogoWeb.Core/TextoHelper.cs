namespace CatalogoWeb.Core
{
    public class TextoHelper
    {
        public static string RemoverAcentos(string texto)
        {
            if (texto == null) return string.Empty;

            const string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            const string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (var i = 0; i < comAcentos.Length; i++)
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());

            return texto;
        }

        public static string RemoverCaracteresEspeciais(string texto, string textoSubstituir = " ")
        {
            if (string.IsNullOrEmpty(texto)) return string.Empty;

            const string caracteresEspeciais = "ºª§&@!'¨°:-–_";

            for (var i = 0; i < caracteresEspeciais.Length; i++)
                texto = texto.Replace(caracteresEspeciais[i].ToString(), textoSubstituir);

            return texto;
        }

        public static string RetornaNumeros(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return "";
            }
            else
            {
                var numeros = new String(texto.Where(Char.IsDigit).ToArray());
                return string.IsNullOrEmpty(numeros) ? null : numeros;
            }
        }

        public static long? RetornaNumero(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return null;
            }
            else
            {
                var numeros = new String(texto.Where(Char.IsDigit).ToArray());
                return string.IsNullOrEmpty(numeros) ? null : Convert.ToInt64(numeros);
            }
        }
        public static string RetornaLetras(string texto)
        {
            return string.IsNullOrEmpty(texto) ? "" : new String(texto.Where(Char.IsLetter).ToArray()).ToUpper();
        }
    }
}
