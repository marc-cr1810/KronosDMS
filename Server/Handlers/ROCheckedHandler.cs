using KronosDMS.Http.Server.Models;
using KronosDMS.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Server.Handlers
{
    public class ROCheckedHandler
    {
        public static Route Get = new Route()
        {
            Name = "Get Checked RO's Handler",
            UrlRegex = @"^/api/v1/checkedros/get$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "checkedros.get"))
                    return PermissionHandler.UnauthorizedResponse;

                string number = Routes.GetArgValue(request, "n");
                string date = Routes.GetArgValue(request, "d");

                return new HttpResponse()
                {
                    ContentAsUTF8 = Server.ROChecked.Search(number, date),
                    ReasonPhrase = "OK",
                    StatusCode = "200"
                };
            }
        };

        public static Route Add = new Route()
        {
            Name = "Add Checked RO Handler",
            UrlRegex = @"^/api/v1/checkedros/add$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "checkedros.modify.add"))
                    return PermissionHandler.UnauthorizedResponse;

                if (Server.ROChecked.Add(request.Content))
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
                        ContentAsUTF8 = "RO's already exists",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };
    }
}
