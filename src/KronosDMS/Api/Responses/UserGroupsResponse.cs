using KronosDMS.Objects;
using System.Collections.Generic;

namespace KronosDMS.Api.Responses
{
    public class UserGroupsSearchResponse : Response
    {
        internal UserGroupsSearchResponse(Response response) : base(response)
        {
            Groups = new Dictionary<string, Group>();
        }

        public Dictionary<string, Group> Groups { get; set; } = new Dictionary<string, Group>();
    }
}
