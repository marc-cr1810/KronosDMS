using KronosDMS.Http.Server.Models;
using KronosDMS.Security;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace KronosDMS_Server.Handlers
{
    public class FormatsHandler
    {
        public static Route GetCSV = new Route()
        {
            Name = "Get CSV Format Handler",
            UrlRegex = @"^/api/v1/formats/csv/(\S*)$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                string name = request.Path.Split('/').Last().ToUpper();

                if (Server.CSVFormats.Formats.ContainsKey(name))
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = Server.CSVFormats.Get(name),
                        ReasonPhrase = "OK",
                        StatusCode = HttpStatusCode.OK
                    };
                }
                else if (name == "")
                {
                    string[] formats = Server.CSVFormats.Formats.Keys.ToArray();

                    return new HttpResponse()
                    {
                        ContentAsUTF8 = JsonConvert.SerializeObject(formats),
                        ReasonPhrase = "OK",
                        StatusCode = HttpStatusCode.OK
                    };
                }

                return new HttpResponse()
                {
                    ContentAsUTF8 = "Invalid CSV Format",
                    ReasonPhrase = "NotFound",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
        };
    }
}
