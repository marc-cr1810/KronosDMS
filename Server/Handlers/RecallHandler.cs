using KronosDMS.Http.Server.Models;

namespace KronosDMS_Server.Handlers
{
    public class RecallHandler
    {
        public static Route Get = new Route()
        {
            Name = "Get Recalls Handler",
            UrlRegex = @"^/api/getrecall$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
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
            UrlRegex = @"^/api/setrecall$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
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
            UrlRegex = @"^/api/addrecall$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
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
            UrlRegex = @"^/api/deleterecall$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
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
    }
}
