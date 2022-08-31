using KronosDMS.Http.Server.Models;
using KronosDMS.Security;

namespace KronosDMS_Server.Handlers
{
    class PartsHandler
    {
        public static Route Get = new Route()
        {
            Name = "Get Parts Handler",
            UrlRegex = @"^/api/v1/parts/get$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "parts.get"))
                    return PermissionHandler.UnauthorizedResponse;

                string make = Routes.GetArgValue(request, "f");
                string number = Routes.GetArgValue(request, "n");
                string description = Routes.GetArgValue(request, "d");
                string id = Routes.GetArgValue(request, "id");

                return new HttpResponse()
                {
                    ContentAsUTF8 = Server.Parts.Search(make, number, description, id),
                    ReasonPhrase = "OK",
                    StatusCode = HttpStatusCode.OK
                };
            }
        };

        public static Route Set = new Route()
        {
            Name = "Set Part Handler",
            UrlRegex = @"^/api/v1/parts/set$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "parts.modify.set"))
                    return PermissionHandler.UnauthorizedResponse;

                if (Server.Parts.Set(request.Content))
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "{}",
                        ReasonPhrase = "OK",
                        StatusCode = HttpStatusCode.OK
                    };
                }
                else
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "Part does not exist",
                        ReasonPhrase = "NotModified",
                        StatusCode = HttpStatusCode.NotModified
                    };
                }
            }
        };

        public static Route Add = new Route()
        {
            Name = "Add Part Handler",
            UrlRegex = @"^/api/v1/parts/add$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "parts.modify.add"))
                    return PermissionHandler.UnauthorizedResponse;

                if (Server.Parts.Add(request.Content))
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "{}",
                        ReasonPhrase = "OK",
                        StatusCode = HttpStatusCode.OK
                    };
                }
                else
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "Part already exists",
                        ReasonPhrase = "NotModified",
                        StatusCode = HttpStatusCode.NotModified
                    };
                }
            }
        };

        public static Route Remove = new Route()
        {
            Name = "Delete Part Handler",
            UrlRegex = @"^/api/v1/parts/delete$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "parts.modify.remove"))
                    return PermissionHandler.UnauthorizedResponse;

                string id = Routes.GetArgValue(request, "id");

                if (Server.Parts.Remove(id))
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "{}",
                        ReasonPhrase = "OK",
                        StatusCode = HttpStatusCode.OK
                    };
                }
                else
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "Part does not already exist",
                        ReasonPhrase = "NotModified",
                        StatusCode = HttpStatusCode.NotModified
                    };
                }
            }
        };
    }
}
