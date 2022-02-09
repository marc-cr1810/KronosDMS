using KronosDMS.Objects;
using System.Security.Cryptography;
using System.Text;

namespace KronosDMS
{
    public struct PartQuantityPair
    {
        public string Number { get; set; }
        public int Quantity { get; set; }

        public PartQuantityPair(string number, int quantity)
        {
            this.Number = number;
            this.Quantity = quantity;
        }
    }

    public struct UpdateInfo
    {
        public struct ClientVerInfo
        {
            public string Version { get; set; }
            public bool Force { get; set; }
        }

        public struct UpdaterVerInfo
        {
            public string Version { get; set; }
            public bool Force { get; set; }
        }

        public ClientVerInfo Client;
        public UpdaterVerInfo Updater;
    }

    public struct GroupData
    {
        public string Name;
        public Group Group;
    }

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
