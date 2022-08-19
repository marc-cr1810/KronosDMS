using KronosDMS.Api.Responses;
using KronosDMS.Utils;
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
        public GetUpdateInfo()
        {
            this.UsesEncryption = false;
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
                    UpdateInfo = info
                };
            }
            else
                return new GetUpdateInfoResponse(Error.GetError(this.Response));
        }
    }

    public class DownloadUpdate : IEndpoint<Response>
    {
        string BaseDir = "./updater/";

        public DownloadUpdate(string baseDir = "./updater/")
        {
            this.UsesEncryption = false;
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/client/update");
            this.BaseDir = baseDir;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.Arguments.Add($"download=1");

            if (File.Exists($"{BaseDir}client.zip"))
                File.Delete($"{BaseDir}client.zip");

            WebClient web = new WebClient();
            web.DownloadFile($"{Requester.BaseAPIAddr}/api/v1/client/update?download=1", $"{BaseDir}client.zip");

            if (File.Exists($"{BaseDir}client.zip"))
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

    public class DownloadUpdater : IEndpoint<Response>
    {
        string BaseDir = "./";

        public DownloadUpdater(string baseDir = "./")
        {
            this.UsesEncryption = false;
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/client/updater");
            this.BaseDir = baseDir;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.Arguments.Add($"download=1");

            if (File.Exists($"{BaseDir}updater.zip"))
                File.Delete($"{BaseDir}updater.zip");

            WebClient web = new WebClient();
            web.DownloadFile($"{this.Address}?download=1", $"{BaseDir}updater.zip");

            if (File.Exists($"{BaseDir}updater.zip"))
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

    public class DownloadThemes : IEndpoint<Response>
    {
        string BaseDir = "./themes/";

        public DownloadThemes(string baseDir = "./themes/")
        {
            this.UsesEncryption = false;
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/client/themes");
            this.BaseDir = baseDir;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.Arguments.Add($"download=1");

            if (!Directory.Exists($"{BaseDir}"))
                Directory.CreateDirectory($"{BaseDir}");

            if (File.Exists($"{BaseDir}themes.zip"))
                File.Delete($"{BaseDir}themes.zip");

            WebClient web = new WebClient();
            web.DownloadFile($"{this.Address}?download=1", $"{BaseDir}themes.zip");

            if (File.Exists($"{BaseDir}themes.zip"))
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
