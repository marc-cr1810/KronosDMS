using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace KronosDMS.Api.Endpoints
{
    public class UserAccountsSet : IEndpoint<Response>
    {
        public UserAccount UserAccount { get; set; }

        public UserAccountsSet(UserAccount account)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/accounts/set");
            this.UserAccount = account;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.PostContent = JsonConvert.SerializeObject(this.UserAccount);
            this.Response = Task.Run(() => Requester.Post(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new Response(this.Response);
            }
            else
                return new Response(Error.GetError(this.Response));
        }
    }
}
