using KronosDMS.Api.Responses;
using KronosDMS.Http.Server;
using KronosDMS.Utils;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace KronosDMS.Api.Endpoints
{
    public class ServerGetInfo : IEndpoint<ServerGetInfoResponse>
    {
        public ServerGetInfo()
        {
            this.UsesEncryption = false;
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/server/info");
        }

        public override async Task<ServerGetInfoResponse> PerformRequestAsync()
        {
            this.Response = Task.Run(() => Requester.Get(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new ServerGetInfoResponse(this.Response)
                {
                    ServerInfo = JsonConvert.DeserializeObject<ServerInfo>(this.Response.RawMessage)
                };
            }
            else
                return new ServerGetInfoResponse(Error.GetError(this.Response));
        }
    }

    public class ServerReload : IEndpoint<Response>
    {
        public ServerReload()
        {
            this.UsesEncryption = false;
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
