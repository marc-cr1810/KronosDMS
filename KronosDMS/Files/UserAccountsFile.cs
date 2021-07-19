using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS.Files
{
    public class UserAccountsFile
    {
        public Dictionary<int, UserAccount> Accounts;

        private readonly int MAX_RESULTS = 100;

        public UserAccountsFile()
        {
            if (File.Exists(@"data/UserAccounts.json"))
                try
                {
                    Accounts = JsonConvert.DeserializeObject<Dictionary<int, UserAccount>>(File.ReadAllText(@"data/UserAccounts.json"));
                }
                catch { }
            if (Accounts is null)
                Accounts = new Dictionary<int, UserAccount>();
        }

        public bool Add(UserAccount user)
        {
            if (Accounts.ContainsKey(user.ID))
                return false;
            foreach (KeyValuePair<int, UserAccount> a in Accounts)
            {
                if (a.Value.Username == user.Username)
                    return false;
            }
            Accounts.Add(user.ID, user);
            Write();
            return true;
        }

        public string Search(string username, string firstname, string lastname, int id = -1)
        {
            Dictionary<int, UserAccount> result = new Dictionary<int, UserAccount>();

            if (id != -1)
            {
                if (Accounts.ContainsKey(id))
                    result.Add(id, Accounts[id]);
                return JsonConvert.SerializeObject(result);
            }

            int numResults = 0;
            foreach (KeyValuePair<int, UserAccount> account in Accounts)
            {
                UserAccount u = account.Value;
                if (u.Username.ToUpper().Contains(username.ToUpper()) &&
                    u.FirstName.ToUpper().Contains(firstname.ToUpper()) &&
                    u.LastName.ToUpper().Contains(lastname.ToUpper()))
                {
                    u.PasswordHash = null;
                    u.ClientToken = null;
                    u.AccessToken = null;
                    result.Add(account.Key, u);
                    numResults++;
                    if (numResults == MAX_RESULTS)
                        break;
                }
            }
            return JsonConvert.SerializeObject(result);
        }

        public void Write()
        {
            string output = JsonConvert.SerializeObject(Accounts, Formatting.Indented);
            File.WriteAllText(@"data/UserAccounts.json", output);
        }
    }
}
