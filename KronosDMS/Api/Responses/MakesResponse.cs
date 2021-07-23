using KronosDMS.Objects;
using System.Collections.Generic;

namespace KronosDMS.Api.Responses
{
    public class MakesSearchResponse : Response
    {
        internal MakesSearchResponse(Response response) : base(response)
        {
            Makes = new Dictionary<string, Make>();
        }

        public Dictionary<string, Make> Makes { get; set; } = new Dictionary<string, Make>();
    }
}
