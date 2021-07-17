using KronosDMS.Objects;
using System.Collections.Generic;

namespace KronosDMS.Api.Responses
{
    public class PartsSearchResponse : Response
    {
        internal PartsSearchResponse(Response response) : base(response)
        {
            Parts = new Dictionary<string, Part>();
        }

        public Dictionary<string, Part> Parts { get; set; } = new Dictionary<string, Part>();
    }
}
