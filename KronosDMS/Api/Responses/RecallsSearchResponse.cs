using KronosDMS.Objects;
using System.Collections.Generic;

namespace KronosDMS.Api.Responses
{
    public class RecallsSearchResponse : Response
    {
        internal RecallsSearchResponse(Response response) : base(response)
        {
            Recalls = new Dictionary<string, Recall>();
        }

        public Dictionary<string, Recall> Recalls { get; set; } = new Dictionary<string, Recall>();
    }
}
