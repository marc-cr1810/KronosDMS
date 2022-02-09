using KronosDMS.Http.Server.Models;
using KronosDMS.Http.Server.RouteHandlers;
using System.IO;

namespace KronosDMS_Server.Handlers
{
    public class ClientHandler
    {
        public static Route Update = new Route()
        {
            Name = "Client Update Handler",
            UrlRegex = @"^/api/v1/client/update$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {

                bool download = Routes.GetArgValue(request, "download") == "1";

                if (download)
                {
                    if (File.Exists("data/client/update/client.zip"))
                    {
                        var response = new HttpResponse();
                        response.StatusCode = "200";
                        response.ReasonPhrase = "Ok";
                        response.Headers["Content-Type"] = QuickMimeTypeMapper.GetMimeType(".zip");
                        response.Content = File.ReadAllBytes("data/client/update/client.zip");

                        return response;
                    }
                }
                return new HttpResponse()
                {
                    ContentAsUTF8 = Server.UpdateConfig.ToJSON(),
                    ReasonPhrase = "OK",
                    StatusCode = "200"
                };
            }
        };

        public static Route UpdaterDownload = new Route()
        {
            Name = "Client Updater Download Handler",
            UrlRegex = @"^/api/v1/client/updater$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {

                bool download = Routes.GetArgValue(request, "download") == "1";

                if (download)
                {
                    if (File.Exists("data/client/update/updater.zip"))
                    {
                        var response = new HttpResponse();
                        response.StatusCode = "200";
                        response.ReasonPhrase = "Ok";
                        response.Headers["Content-Type"] = QuickMimeTypeMapper.GetMimeType(".zip");
                        response.Content = File.ReadAllBytes("data/client/update/updater.zip");

                        return response;
                    }
                }
                return new HttpResponse()
                {
                    ContentAsUTF8 = "{}",
                    ReasonPhrase = "OK",
                    StatusCode = "200"
                };
            }
        };

        public static Route Themes = new Route()
        {
            Name = "Client Themes Handler",
            UrlRegex = @"^/api/v1/client/themes$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                bool download = Routes.GetArgValue(request, "download") == "1";

                if (download)
                {
                    if (File.Exists("data/client/themes.zip"))
                    {
                        var response = new HttpResponse();
                        response.StatusCode = "200";
                        response.ReasonPhrase = "Ok";
                        response.Headers["Content-Type"] = QuickMimeTypeMapper.GetMimeType(".zip");
                        response.Content = File.ReadAllBytes("data/client/themes.zip");

                        return response;
                    }
                }
                return new HttpResponse()
                {
                    ContentAsUTF8 = "{}",
                    ReasonPhrase = "OK",
                    StatusCode = "200"
                };
            }
        };
    }
}
