using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS.Objects
{
    public struct UserAccount
    {
        public int ID;
        public string Username;
        public string PasswordHash;
        public string FirstName;
        public string LastName;
        public string ClientToken;
        public string AccessToken;
    }
}
