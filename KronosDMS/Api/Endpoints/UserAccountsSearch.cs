using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace KronosDMS.Api.Endpoints
{
    public class UserAccountsSearch : IEndpoint<UserAccountsSearchResponse>
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int ID { get; set; }

        public UserAccountsSearch(string username, string firstname, string lastname)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/accounts/get");

            this.Username = username;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.ID = -1;
        }

        public UserAccountsSearch(int id)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/accounts/get");

            this.ID = id;
        }

        public override async Task<UserAccountsSearchResponse> PerformRequestAsync()
        {
            if (ID != -1)
            {
                this.Arguments.Add($"id={HttpUtility.UrlEncode(this.ID.ToString())}");
            }
            else
            {
                this.Arguments.Add($"u={HttpUtility.UrlEncode(this.Username)}");
                this.Arguments.Add($"f={HttpUtility.UrlEncode(this.Firstname)}");
                this.Arguments.Add($"l={HttpUtility.UrlEncode(this.Lastname)}");
            }

            this.Response = Task.Run(() => Requester.Get(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new UserAccountsSearchResponse(this.Response)
                {
                    UserAccounts = JsonConvert.DeserializeObject<Dictionary<int, UserAccount>>(this.Response.RawMessage)
                };
            }
            else
                return new UserAccountsSearchResponse(Error.GetError(this.Response));
        }
    }
}
