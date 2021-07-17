using KronosDMS.Http.Server.Models;
using KronosDMS_Server.Handlers;
using System.Collections.Generic;

namespace KronosDMS_Server
{
    public class Routes
    {
        public static List<Route> GetRoutes()
        {
            return new List<Route>() {
                AccountsHandler.Login,

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

                new Route {
                    Name = "Ping Handler",
                    UrlRegex = @"^/api/ping$",
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
    }
}
