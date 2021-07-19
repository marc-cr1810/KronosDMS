using KronosDMS.Api.Responses;
using System;
using System.Threading.Tasks;
using System.Web;

namespace KronosDMS.Api.Endpoints
{
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
}
