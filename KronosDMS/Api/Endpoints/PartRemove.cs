using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Web;

namespace KronosDMS.Api.Endpoints
{
    public class PartRemove : IEndpoint<Response>
    {
        public string ID { get; set; }

        public PartRemove(string id)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/deletepart");
            this.ID = id;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.Arguments.Add($"id={HttpUtility.UrlEncode(this.ID)}");

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
