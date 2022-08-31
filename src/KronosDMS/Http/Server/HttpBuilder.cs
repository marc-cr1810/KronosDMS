using KronosDMS.Http.Server.Models;

namespace KronosDMS.Http.Server
{
    class HttpBuilder
    {
        public static HttpResponse InternalServerError()
        {
            string content = "Internal Error: 500";

            return new HttpResponse()
            {
                ReasonPhrase = "InternalServerError",
                StatusCode = HttpStatusCode.InternalServerError,
                ContentAsUTF8 = content
            };
        }

        public static HttpResponse NotFound()
        {
            string content = "Error: 404 not found";

            return new HttpResponse()
            {
                ReasonPhrase = "NotFound",
                StatusCode = HttpStatusCode.NotFound,
                ContentAsUTF8 = content
            };
        }
    }
}
