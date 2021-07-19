using KronosDMS.Objects;
using System.Collections.Generic;

namespace KronosDMS.Api.Responses
{
    public class UserGroupsGetResponse : Response
    {
        internal UserGroupsGetResponse(Response response) : base(response)
        {
            Groups = new Dictionary<string, Group>();
        }

        public Dictionary<string, Group> Groups { get; set; } = new Dictionary<string, Group>();
    }
}
