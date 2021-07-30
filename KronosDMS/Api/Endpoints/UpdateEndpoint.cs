using KronosDMS.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS.Api.Endpoints
{
    public class GetUpdateInfo : IEndpoint<GetUpdateInfoResponse>
    {
        private struct UpdateInfo
        {
            public string Version { get; set; }
            public bool Force { get; set; }
        }

        public GetUpdateInfo()
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/client/update");
        }

        public override async Task<GetUpdateInfoResponse> PerformRequestAsync()
        {
            this.Response = Task.Run(() => Requester.Get(this)).Result;

            if (this.Response.IsSuccess)
            {
                UpdateInfo info = JsonConvert.DeserializeObject<UpdateInfo>(this.Response.RawMessage);

                return new GetUpdateInfoResponse(this.Response)
                {
                    Version = info.Version,
                    Force = info.Force
                };
            }
            else
                return new GetUpdateInfoResponse(Error.GetError(this.Response));
        }
    }

    public class DownloadUpdate : IEndpoint<Response>
    {
        public DownloadUpdate()
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/client/update");
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.Arguments.Add($"download=1");

            if (File.Exists("updater/client.zip"))
                File.Delete("updater/client.zip");

            WebClient web = new WebClient();
            web.DownloadFile($"{Requester.BaseAPIAddr}/api/v1/client/update?download=1", "updater/client.zip");

            if (File.Exists("updater/client.zip"))
            {
                return new Response()
                {
                    IsSuccess = true,
                    Code = HttpStatusCode.OK,
                    RawMessage = "{}"
                };
            }
            else
                return new Response(Error.GetError(this.Response));
        }
    }
}
