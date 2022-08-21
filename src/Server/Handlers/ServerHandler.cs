using KronosDMS.Http.Server.Models;
using KronosDMS.Objects;
using KronosDMS.Security;
using KronosDMS.Utils;

namespace KronosDMS_Server.Handlers
{
    public class ServerHandler
    {
        public static Route GetServerInfo = new Route()
        {
            Name = "Get Server Information",
            UrlRegex = @"^/api/v1/server/info$",
            Method = "GET",
            UsesEncryption = false,
            Callable = (HttpRequest request) =>
            {
                return new HttpResponse()
                {
                    ContentAsUTF8 = Server.Config.ServerInfo.ToJson(),
                    ReasonPhrase = "OK",
                    StatusCode = "200"
                };
            }
        };

        public static Route Reload = new Route()
        {
            Name = "Get User Accounts Handler",
            UrlRegex = @"^/api/v1/server/reload$",
            Method = "GET",
            UsesEncryption = false,
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "server.reload"))
                    return PermissionHandler.UnauthorizedResponse;

                UserAccount user = Routes.GetUserFromKey(request);
                Logger.Log($"User \"{user.Username}\" reloaded the server");
                Logger.Log("Reloading server... ");
                Server.Load();
                Logger.Log("Done");

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
