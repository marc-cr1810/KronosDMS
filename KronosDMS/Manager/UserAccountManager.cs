using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS.Manager
{
    public class UserAccountManager
    {
        private Dictionary<int, UserAccount> Accounts;

        public struct Credentials
        {
            public string Username;
            public string Password;
            public string ClientToken;
        }

        public UserAccountManager()
        {
            if (File.Exists(@"data/UserAccounts.json"))
                try
                {
                    Accounts = JsonConvert.DeserializeObject<Dictionary<int, UserAccount>>(File.ReadAllText(@"data/UserAccounts.json"));
                } catch { }
            if (Accounts is null)
                Accounts = new Dictionary<int, UserAccount>();
        }

        public bool Create(string username, string password, string firstname, string lastname)
        {
            return Create(username, SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)), firstname, lastname);
        }

        public bool Create(string username, byte[] password256, string firstname, string lastname)
        {
            StringBuilder pwBuilder = new StringBuilder();
            for (int i = 0; i < password256.Length; i++)
            {
                pwBuilder.Append(password256[i].ToString("x2"));
            }
            string passwordHash = pwBuilder.ToString();

            UserAccount account = new UserAccount()
            {
                ID = 1000 + Accounts.Count,
                Username = username,
                PasswordHash = passwordHash,
                FirstName = firstname,
                LastName = lastname,
            };

            foreach (KeyValuePair<int, UserAccount> a in Accounts)
            {
                if (a.Value.Username == account.Username)
                    return false;
            }

            Accounts.Add(account.ID, account);
            Write();

            return true;
        }

        public string Login(string json)
        {
            Credentials credentials = JsonConvert.DeserializeObject<Credentials>(json);
            foreach (KeyValuePair<int, UserAccount> a in Accounts)
            {
                if (a.Value.Username == credentials.Username && a.Value.PasswordHash == credentials.Password)
                {
                    UserAccount user = a.Value;
                    user.ClientToken = credentials.ClientToken;
                    user.AccessToken = Guid.NewGuid().ToString();
                    Accounts[a.Key] = user;
                    user.PasswordHash = null;
                    return JsonConvert.SerializeObject(user);
                }
            }

            return "";
        }

        public void Write()
        {
            string output = JsonConvert.SerializeObject(Accounts, Formatting.Indented);
            File.WriteAllText(@"data/Accounts.json", output);
        }
    }
}
