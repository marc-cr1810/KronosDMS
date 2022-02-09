using KronosDMS.Http.Server.Models;
using KronosDMS.Security;

namespace KronosDMS_Server.Handlers
{
    public class RecallHandler
    {
        public static Route Get = new Route()
        {
            Name = "Get Recalls Handler",
            UrlRegex = @"^/api/v1/recalls/get$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "recalls.get"))
                    return PermissionHandler.UnauthorizedResponse;

                string make = Routes.GetArgValue(request, "f");
                string model = Routes.GetArgValue(request, "m");
                string number = Routes.GetArgValue(request, "n");
                string description = Routes.GetArgValue(request, "d");
                string id = Routes.GetArgValue(request, "id");

                return new HttpResponse()
                {
                    ContentAsUTF8 = Server.Recalls.Search(make, model, number, description, id),
                    ReasonPhrase = "OK",
                    StatusCode = "200"
                };
            }
        };

        public static Route Set = new Route()
        {
            Name = "Set Recall Handler",
            UrlRegex = @"^/api/v1/recalls/set$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "recalls.modify.set"))
                    return PermissionHandler.UnauthorizedResponse;

                if (Server.Recalls.Set(request.Content))
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "{}",
                        ReasonPhrase = "OK",
                        StatusCode = "200"
                    };
                }
                else
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "Recall does not exist",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };

        public static Route Add = new Route()
        {
            Name = "Add Recall Handler",
            UrlRegex = @"^/api/v1/recalls/add$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "recalls.modify.add"))
                    return PermissionHandler.UnauthorizedResponse;

                if (Server.Recalls.Add(request.Content))
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "{}",
                        ReasonPhrase = "OK",
                        StatusCode = "200"
                    };
                }
                else
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "Recall already exists",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };

        public static Route Remove = new Route()
        {
            Name = "Delete Recall Handler",
            UrlRegex = @"^/api/v1/recalls/delete$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "recalls.modify.remove"))
                    return PermissionHandler.UnauthorizedResponse;

                string id = Routes.GetArgValue(request, "id");

                if (Server.Recalls.Remove(id))
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "{}",
                        ReasonPhrase = "OK",
                        StatusCode = "200"
                    };
                }
                else
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "Recall does not already exist",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };

        public static Route LockState = new Route()
        {
            Name = "Set Recall Lock State Handler",
            UrlRegex = @"^/api/v1/recalls/setlock$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                string id = Routes.GetArgValue(request, "id");
                bool locked = Routes.GetArgValue(request, "locked") == "1";

                if (locked && !Routes.HasPermission(request, "recalls.lock"))
                    return PermissionHandler.UnauthorizedResponse;
                else if (!locked && !Routes.HasPermission(request, "recalls.unlock"))
                    return PermissionHandler.UnauthorizedResponse;


                if (Server.Recalls.SetLockState(id, locked))
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "{}",
                        ReasonPhrase = "OK",
                        StatusCode = "200"
                    };
                }
                else
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "Recall does not exist",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };
    }
}
