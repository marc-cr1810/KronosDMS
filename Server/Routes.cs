using KronosDMS.Http.Server.Models;
using KronosDMS.Http.Server.RouteHandlers;
using KronosDMS.Objects;
using KronosDMS.Security;
using KronosDMS_Server.Handlers;
using System.Collections.Generic;
using System.IO;

namespace KronosDMS_Server
{
    public class Routes
    {
        public static List<Route> GetRoutes()
        {
            return new List<Route>() {
                ServerHandler.Reload,

                UserAccountsHandler.Login,
                UserAccountsHandler.Logout,
                UserAccountsHandler.Validate,
                UserAccountsHandler.Get,
                UserAccountsHandler.Set,
                UserAccountsHandler.SetPassword,
                UserAccountsHandler.Add,
                UserAccountsHandler.Remove,

                GroupsHandler.Get,

                MakeHandler.Get,
                MakeHandler.Set,
                MakeHandler.Add,

                PartsHandler.Get,
                PartsHandler.Set,
                PartsHandler.Add,
                PartsHandler.Remove,

                RecallHandler.Get,
                RecallHandler.Set,
                RecallHandler.Add,
                RecallHandler.Remove,

                KitHandler.Get,
                KitHandler.Set,
                KitHandler.Add,
                KitHandler.Remove,

                new Route {
                    Name = "Ping Handler",
                    UrlRegex = @"^/api/v1/ping$",
                    Method = "GET",
                    Callable = (HttpRequest request) => {
                        return new HttpResponse()
                        {
                            ContentAsUTF8 = "{}",
                            ReasonPhrase = "OK",
                            StatusCode = "200"
                        };
                     }
                },

                new Route {
                    Name = "Client Update Handler",
                    UrlRegex = @"^/api/v1/client/update$",
                    Method = "GET",
                    Callable = (HttpRequest request) => {

                        bool download = Routes.GetArgValue(request, "download") == "1";

                        if (download)
                        {
                            if (File.Exists("data/update/client.zip"))
                            {
                                var response = new HttpResponse();
                                response.StatusCode = "200";
                                response.ReasonPhrase = "Ok";
                                response.Headers["Content-Type"] = QuickMimeTypeMapper.GetMimeType(".zip");
                                response.Content = File.ReadAllBytes("data/update/client.zip");

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
    },
            };
        }

        public static string GetArgValue(HttpRequest request, string arg)
        {
            if (request.Arguments.ContainsKey(arg))
                return request.Arguments[arg];
            return "";
        }

        public static bool HasPermission(HttpRequest request, string permission)
        {
            if (!PermissionHandler.Has(GetUserFromKey(request), permission))
                return false;
            return true;
        }

        public static string GetAccessToken(HttpRequest request)
        {
            string accessToken = "";
            if (request.Headers.ContainsKey("Authorization"))
                accessToken = request.Headers["Authorization"].Split(' ')[1];
            return accessToken;
        }

        public static UserAccount GetUserFromKey(HttpRequest request)
        {
            return Server.AccountManager.GetAccount(GetAccessToken(request));
        }
    }
}
