using KronosDMS.Http.Server.Models;

namespace KronosDMS_Server.Handlers
{
    class PartsHandler
    {
        public static Route Get = new Route()
        {
            Name = "Get Parts Handler",
            UrlRegex = @"^/api/getpart$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                string make = Routes.GetArgValue(request, "f");
                string number = Routes.GetArgValue(request, "n");
                string description = Routes.GetArgValue(request, "d");
                string id = Routes.GetArgValue(request, "id");

                return new HttpResponse()
                {
                    ContentAsUTF8 = Server.Parts.Search(make, number, description, id),
                    ReasonPhrase = "OK",
                    StatusCode = "200"
                };
            }
        };

        public static Route Set = new Route()
        {
            Name = "Set Part Handler",
            UrlRegex = @"^/api/setpart$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                if (Server.Parts.Set(request.Content))
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
                        ContentAsUTF8 = "Part does not exist",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };

        public static Route Add = new Route()
        {
            Name = "Add Part Handler",
            UrlRegex = @"^/api/addpart$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                if (Server.Parts.Add(request.Content))
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
                        ContentAsUTF8 = "Part already exists",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };

        public static Route Remove = new Route()
        {
            Name = "Delete Part Handler",
            UrlRegex = @"^/api/deletepart$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                string id = Routes.GetArgValue(request, "id");

                if (Server.Parts.Remove(id))
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
                        ContentAsUTF8 = "Part does not already exist",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };
    }
}
