using KronosDMS.Http.Server.Models;
using KronosDMS.Security;

namespace KronosDMS_Server.Handlers
{
    public class KitHandler
    {
        public static Route Get = new Route()
        {
            Name = "Get Kits Handler",
            UrlRegex = @"^/api/v1/kits/get$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "kits.get"))
                    return PermissionHandler.UnauthorizedResponse;

                string make = Routes.GetArgValue(request, "f");
                string model = Routes.GetArgValue(request, "m");
                string number = Routes.GetArgValue(request, "n");
                string description = Routes.GetArgValue(request, "d");
                string id = Routes.GetArgValue(request, "id");

                return new HttpResponse()
                {
                    ContentAsUTF8 = Server.Kits.Search(make, model, number, description, id),
                    ReasonPhrase = "OK",
                    StatusCode = "200"
                };
            }
        };

        public static Route Set = new Route()
        {
            Name = "Set Kit Handler",
            UrlRegex = @"^/api/v1/kits/set$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "kits.modify.set"))
                    return PermissionHandler.UnauthorizedResponse;

                if (Server.Kits.Set(request.Content))
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
                        ContentAsUTF8 = "Kit does not exist",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };

        public static Route Add = new Route()
        {
            Name = "Add Kit Handler",
            UrlRegex = @"^/api/v1/kits/add$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "kits.modify.add"))
                    return PermissionHandler.UnauthorizedResponse;

                if (Server.Kits.Add(request.Content))
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
                        ContentAsUTF8 = "Kit already exists",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };

        public static Route Remove = new Route()
        {
            Name = "Delete Kit Handler",
            UrlRegex = @"^/api/v1/kits/delete$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "kits.modify.remove"))
                    return PermissionHandler.UnauthorizedResponse;

                string id = Routes.GetArgValue(request, "id");

                if (Server.Kits.Remove(id))
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
                        ContentAsUTF8 = "Kit does not already exist",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };
    }
}
