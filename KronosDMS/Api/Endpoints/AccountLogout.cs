using KronosDMS.Objects;
using KronosDMS.Api.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KronosDMS.Api.Endpoints
{
    public class AccountLogout : IEndpoint<Response>
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public AccountLogout(string username, string passwordHash)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/auth/logout");

            this.Username = username;
            this.PasswordHash = passwordHash;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.PostContent = new JObject(
                                       new JProperty("Username", this.Username),
                                       new JProperty("Password", this.PasswordHash),
                                       new JProperty("ClientToken", Requester.ClientToken)).ToString();

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
