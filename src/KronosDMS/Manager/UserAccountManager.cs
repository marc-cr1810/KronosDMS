using KronosDMS.Files;
using KronosDMS.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace KronosDMS.Objects
{
    public class UserAccountManager
    {
        public struct Credentials
        {
            public string Username;
            public string Password;
            public string ClientToken;
        }

        private UserAccountsFile File { get; set; }
        private Dictionary<string, int> AccessTokenAccounts;

        public UserAccountManager()
        {
            File = new UserAccountsFile();

            // Ensure the sysad user account exists (yes it is a weak password, CHANGE IT!!!!)
            if (!File.Accounts.ContainsKey(1000))
            {
                Create("sysad", "sysad", "System", "Administrator");
            }

            AccessTokenAccounts = new Dictionary<string, int>();
        }

        public bool Create(string json)
        {
            UserAccount account = JsonConvert.DeserializeObject<UserAccount>(json);
            account.ID = (File.Accounts.Count == 0) ? 1000 : File.Accounts.Last().Key + 1;
            return File.Add(account);
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
                ID = (File.Accounts.Count == 0) ? 1000 : File.Accounts.Last().Key + 1,
                Username = username,
                PasswordHash = passwordHash,
                FirstName = firstname,
                LastName = lastname,
            };

            return File.Add(account);
        }

        public bool Set(string json)
        {
            UserAccount account = JsonConvert.DeserializeObject<UserAccount>(json);
            if (!File.Accounts.ContainsKey(account.ID))
                return false;
            if (account.ID == 1000)
            {
                if (account.Username != "sysad" ||
                    account.Group != "Administrator")
                    return false;
            }
            File.Accounts[account.ID] = account;
            File.Write();
            Logger.Log("Changed user account information", LogLevel.INFO,
                $"Username: {account.Username}");
            return true;
        }

        public bool SetPassword(int id, string passwordHash, string newPasswordHash)
        {
            if (!File.Accounts.ContainsKey(id) || id == -1)
                return false;
            UserAccount user = File.Accounts[id];
            if (File.Accounts[id].PasswordHash == passwordHash)
            {
                user.PasswordHash = newPasswordHash;
                File.Accounts[id] = user;
                Logger.Log($"User \"{user.Username}\" changed their password");
                return true;
            }
            return false;
        }

        public bool Remove(int id)
        {
            if (!File.Accounts.ContainsKey(id))
                return false;
            UserAccount account = File.Accounts[id];
            if (account.ID == 1000)
            {
                Logger.Log("Cannot remove the system administrator account", LogLevel.WARN);
                return false;
            }
            File.Accounts.Remove(id);
            File.Write();
            Logger.Log($"Removed user \"{id}\" from file");
            return true;
        }

        public string Login(string json)
        {
            Credentials credentials = JsonConvert.DeserializeObject<Credentials>(json);
            foreach (KeyValuePair<int, UserAccount> a in File.Accounts)
            {
                if (a.Value.Username == credentials.Username && a.Value.PasswordHash == credentials.Password)
                {
                    UserAccount user = a.Value;

                    // Remove the old access token from the user
                    if (user.AccessToken is not null)
                    {
                        if (AccessTokenAccounts.ContainsKey(user.AccessToken))
                            AccessTokenAccounts.Remove(user.AccessToken);
                    }

                    user.ClientToken = credentials.ClientToken;
                    user.AccessToken = Guid.NewGuid().ToString();
                    File.Accounts[a.Key] = user;
                    user.PasswordHash = null;

                    AccessTokenAccounts.Add(user.AccessToken, user.ID);

                    Logger.Log($"User Account {user.Username} \"{user.FirstName} {user.LastName}\" logged in");

                    return JsonConvert.SerializeObject(user);
                }
            }

            Logger.Log("Invalid username or password", LogLevel.WARN,
                $"Username: {credentials.Username}\n" +
                $"Password: {credentials.Password.Substring(0, 4)}****");
            return "";
        }

        public string Logout(string json)
        {
            Credentials credentials = JsonConvert.DeserializeObject<Credentials>(json);
            foreach (KeyValuePair<int, UserAccount> a in File.Accounts)
            {
                if (a.Value.Username == credentials.Username && a.Value.PasswordHash == credentials.Password)
                {
                    UserAccount user = a.Value;

                    // Remove the old access token from the user
                    if (user.AccessToken is not null)
                    {
                        if (AccessTokenAccounts.ContainsKey(user.AccessToken))
                            AccessTokenAccounts.Remove(user.AccessToken);
                    }

                    user.ClientToken = null;
                    user.AccessToken = null;
                    File.Accounts[a.Key] = user;
                    File.Write();


                    Logger.Log($"User Account {user.Username} \"{user.FirstName} {user.LastName}\" logged out");

                    return "{}";
                }
            }
            return "";
        }

        public bool ValidateLogin(int userId, string accessToken)
        {
            if (AccessTokenAccounts.ContainsKey(accessToken))
            {
                if (AccessTokenAccounts[accessToken] == userId)
                    return true;
            }
            return false;
        }

        public string Search(string username, string firstname, string lastname, int id = -1)
        {
            return File.Search(username, firstname, lastname, id);
        }

        public UserAccount GetAccount(string accessToken)
        {
            if (accessToken is not null)
            {
                if (AccessTokenAccounts.ContainsKey(accessToken))
                    return File.Accounts[AccessTokenAccounts[accessToken]];
            }
            return new UserAccount();
        }
    }
}
