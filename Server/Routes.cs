using KronosDMS.Http.Server.Models;
using KronosDMS.Security;
using KronosDMS_Server.Handlers;
using System.Collections.Generic;

namespace KronosDMS_Server
{
    public class Routes
    {
        public static List<Route> GetRoutes()
        {
            return new List<Route>() {
                UserAccountsHandler.Login,
                UserAccountsHandler.Logout,
                UserAccountsHandler.Get,
                UserAccountsHandler.Set,
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
            string accessToken = "";
            if (request.Headers.ContainsKey("Authorization"))
                accessToken = request.Headers["Authorization"].Split(' ')[1];
            if (!PermissionHandler.Has(Server.AccountManager.GetAccount(accessToken), permission))
                return false;
            return true;
        }
    }
}
