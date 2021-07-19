using KronosDMS.Http.Server.Models;
using KronosDMS.Security;

namespace KronosDMS_Server.Handlers
{
    public class GroupsHandler
    {
        public static Route Get = new Route()
        {
            Name = "Get Groups Handler",
            UrlRegex = @"^/api/v1/system/groups/get$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "system.groups.get"))
                    return PermissionHandler.UnauthorizedResponse;

                string id = Routes.GetArgValue(request, "id");

                return new HttpResponse()
                {
                    ContentAsUTF8 = PermissionHandler.GroupsFile.Get(id),
                    ReasonPhrase = "OK",
                    StatusCode = "200"
                };
            }
        };
    }
}
