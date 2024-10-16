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
    }
}
