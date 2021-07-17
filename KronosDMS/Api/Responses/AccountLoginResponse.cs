using KronosDMS.Objects;

namespace KronosDMS.Api.Responses
{
    public class AccountLoginResponse : Response
    {
        internal AccountLoginResponse(Response response) : base(response)
        {

        }

        public UserAccount Account;
    }
}
