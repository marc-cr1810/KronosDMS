using KronosDMS.Api.Responses;
using System;
using System.Threading.Tasks;

namespace KronosDMS.Api.Endpoints
{
    public class ServerReload : IEndpoint<Response>
    {
        public ServerReload()
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/server/reload");
        }

        public override async Task<Response> PerformRequestAsync()
        {
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
