using KronosDMS.Http.Server.Models;
using KronosDMS.Objects;
using KronosDMS.Security;

namespace KronosDMS_Server.Handlers
{
    public class GroupsHandler
    {
        public static Route Get = new Route()
        {
            Name = "Get User Groups Handler",
            UrlRegex = @"^/api/v1/system/groups/get$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "system.groups.get"))
                    return PermissionHandler.UnauthorizedResponse;

                string name = Routes.GetArgValue(request, "n");
                string level = Routes.GetArgValue(request, "l");
                string id = Routes.GetArgValue(request, "id");

                return new HttpResponse()
                {
                    ContentAsUTF8 = PermissionHandler.GroupsFile.Search(name, level, id),
                    ReasonPhrase = "OK",
                    StatusCode = HttpStatusCode.OK
                };
            }
        };

        public static Route Add = new Route()
        {
            Name = "Add User Group Handler",
            UrlRegex = @"^/api/v1/system/groups/add$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "system.groups.modify.add"))
                    return PermissionHandler.UnauthorizedResponse;

                if (PermissionHandler.GroupsFile.Add(request.Content))
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
                        ContentAsUTF8 = "User Group already exists",
                        ReasonPhrase = "NotModified",
                        StatusCode = HttpStatusCode.NotModified
                    };
                }
            }
        };

        public static Route Set = new Route()
        {
            Name = "Set User Group Handler",
            UrlRegex = @"^/api/v1/system/groups/set$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "system.groups.modify.set"))
                    return PermissionHandler.UnauthorizedResponse;

                if (PermissionHandler.GroupsFile.Set(request.Content))
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
                        ContentAsUTF8 = "User Group does not exist",
                        ReasonPhrase = "NotModified",
                        StatusCode = HttpStatusCode.NotModified
                    };
                }
            }
        };

        public static Route Remove = new Route()
        {
            Name = "Delete User Group Handler",
            UrlRegex = @"^/api/v1/system/groups/delete$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "system.groups.modify.remove"))
                    return PermissionHandler.UnauthorizedResponse;

                string id = Routes.GetArgValue(request, "id");

                if (PermissionHandler.GroupsFile.Remove(id))
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
                        ContentAsUTF8 = "User Group does not already exist",
                        ReasonPhrase = "NotModified",
                        StatusCode = HttpStatusCode.NotModified
                    };
                }
            }
        };
    }
}
