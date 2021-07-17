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
    public class AccountLogin : IEndpoint<AccountLoginResponse>
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public AccountLogin(string username, string password)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/login");

            byte[] password256 = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder pwBuilder = new StringBuilder();
            for (int i = 0; i < password256.Length; i++)
            {
                pwBuilder.Append(password256[i].ToString("x2"));
            }
            string passwordHash = pwBuilder.ToString();

            this.Username = username;
            this.PasswordHash = passwordHash;
        }

        public override async Task<AccountLoginResponse> PerformRequestAsync()
        {
            this.PostContent = new JObject(
                                       new JProperty("Username", this.Username),
                                       new JProperty("Password", this.PasswordHash),
                                       new JProperty("ClientToken", Requester.ClientToken)).ToString();

            this.Response = Task.Run(() => Requester.Post(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new AccountLoginResponse(this.Response)
                {
                    Account = JsonConvert.DeserializeObject<UserAccount>(this.Response.RawMessage)
                };
            }
            else
                return new AccountLoginResponse(Error.GetError(this.Response));
        }
    }
}
