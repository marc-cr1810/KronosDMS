using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace KronosDMS.Api.Endpoints
{
    public class UserGroupsGet : IEndpoint<UserGroupsGetResponse>
    {
        public string ID { get; set; }

        public UserGroupsGet(string id)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/system/groups/get");

            this.ID = id;
        }

        public override async Task<UserGroupsGetResponse> PerformRequestAsync()
        {
            this.Arguments.Add($"id={HttpUtility.UrlEncode(this.ID)}");

            this.Response = Task.Run(() => Requester.Get(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new UserGroupsGetResponse(this.Response)
                {
                    Groups = JsonConvert.DeserializeObject<Dictionary<string, Group>>(this.Response.RawMessage)
                };
            }
            else
                return new UserGroupsGetResponse(Error.GetError(this.Response));
        }
    }
}
