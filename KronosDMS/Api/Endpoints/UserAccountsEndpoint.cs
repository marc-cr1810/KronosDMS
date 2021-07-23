using KronosDMS.Api.Responses;
using KronosDMS.Objects;
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
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/auth/login");

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

    public class UserAccountAdd : IEndpoint<Response>
    {
        public UserAccount UserAccount { get; set; }

        public UserAccountAdd(UserAccount account)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/accounts/add");
            this.UserAccount = account;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.PostContent = JsonConvert.SerializeObject(this.UserAccount);
            this.Response = Task.Run(() => Requester.Post(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new Response(this.Response)
                {

                };
            }
            else
                return new Response(Error.GetError(this.Response));
        }
    }

    public class UserAccountRemove : IEndpoint<Response>
    {
        public int ID { get; set; }

        public UserAccountRemove(int id)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/accounts/delete");
            this.ID = id;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.Arguments.Add($"id={HttpUtility.UrlEncode(this.ID.ToString())}");

            this.Response = Task.Run(() => Requester.Get(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new Response(this.Response);
            }
            else
                return new Response(Error.GetError(this.Response));
        }
    }

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
