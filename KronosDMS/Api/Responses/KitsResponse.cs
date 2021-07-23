using KronosDMS.Objects;
using System.Collections.Generic;

namespace KronosDMS.Api.Responses
{
    public class KitsSearchResponse : Response
    {
        internal KitsSearchResponse(Response response) : base(response)
        {
            Kits = new Dictionary<string, Kit>();
        }

        public Dictionary<string, Kit> Kits { get; set; } = new Dictionary<string, Kit>();
    }
}
