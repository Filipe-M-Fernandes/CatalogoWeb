using System.Text;
using XSystem.Security.Cryptography;

namespace CatalogoWeb.Core
{
    public class CriptografiaHelper
    {
        public static string Sha256(string value)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(value));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
