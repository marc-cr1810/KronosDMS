using KronosDMS.Http.Server.Models;

namespace KronosDMS_Server.Handlers
{
    public class MakeHandler
    {
        public static Route Get = new Route()
        {
            Name = "Get Make Handler",
            UrlRegex = @"^/api/v1/makes/get$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                string name = Routes.GetArgValue(request, "n");

                return new HttpResponse()
                {
                    ContentAsUTF8 = Server.Makes.Search(name),
                    ReasonPhrase = "OK",
                    StatusCode = "200"
                };
            }
        };

        public static Route Set = new Route()
        {
            Name = "Set Make Handler",
            UrlRegex = @"^/api/v1/makes/set$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                if (Server.Makes.Set(request.Content))
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
                        ContentAsUTF8 = "Make does not exist",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };

        public static Route Add = new Route()
        {
            Name = "Add Make Handler",
            UrlRegex = @"^/api/v1/makes/add$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                if (Server.Makes.Add(request.Content))
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
                        ContentAsUTF8 = "Make already exists",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };
    }
}
