using KronosDMS.Objects;
using System.Collections.Generic;

namespace KronosDMS.Api.Responses
{
    public class AccountLoginResponse : Response
    {
        internal AccountLoginResponse(Response response) : base(response)
        {

        }

        public UserAccount Account;
    }

    public class UserAccountsSearchResponse : Response
    {
        internal UserAccountsSearchResponse(Response response) : base(response)
        {
            UserAccounts = new Dictionary<int, UserAccount>();
        }

        public Dictionary<int, UserAccount> UserAccounts { get; set; } = new Dictionary<int, UserAccount>();
    }
}
