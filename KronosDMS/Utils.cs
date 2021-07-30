using System.Security.Cryptography;
using System.Text;

namespace KronosDMS
{
    public static class Utils
    {
        public static string SHA256Hash(string str)
        {
            byte[] str256 = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < str256.Length; i++)
            {
                strBuilder.Append(str256[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}
