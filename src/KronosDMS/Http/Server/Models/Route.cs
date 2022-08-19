using System;

namespace KronosDMS.Http.Server.Models
{
    public class Route
    {
        public string Name { get; set; } // descriptive name for debugging
        public string UrlRegex { get; set; }
        public string Method { get; set; }
        public bool UsesEncryption = true; // Uses encryption if encryption is enabled
        public Func<HttpRequest, HttpResponse> Callable { get; set; }
    }
}
