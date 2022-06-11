using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace KronosDMS.Api.Endpoints
{
    public class UserGroupAdd : IEndpoint<Response>
    {
        public string Name { get; set; }
        public Group Group { get; set; }

        public UserGroupAdd(string name, Group group)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/system/groups/add");
            this.Name = name;
            this.Group = group;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.PostContent = JsonConvert.SerializeObject(new GroupData() { Name = this.Name, Group = this.Group });
            this.Response = Task.Run(() => Requester.Post(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new Response(this.Response);
            }
            else
                return new Response(Error.GetError(this.Response));
        }
    }

    public class UserGroupRemove : IEndpoint<Response>
    {
        public string ID { get; set; }

        public UserGroupRemove(string id)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/system/groups/delete");
            this.ID = id;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.Arguments.Add($"id={HttpUtility.UrlEncode(this.ID)}");

            this.Response = Task.Run(() => Requester.Get(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new Response(this.Response);
            }
            else
                return new Response(Error.GetError(this.Response));
        }
    }

    public class UserGroupSet : IEndpoint<Response>
    {
        public string Name { get; set; }
        public Group Group { get; set; }

        public UserGroupSet(string name, Group group)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/system/groups/set");
            this.Name = name;
            this.Group = group;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.PostContent = JsonConvert.SerializeObject(new GroupData() { Name = this.Name, Group = this.Group });
            this.Response = Task.Run(() => Requester.Post(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new Response(this.Response);
            }
            else
                return new Response(Error.GetError(this.Response));
        }
    }

    public class UserGroupsSearch : IEndpoint<UserGroupsSearchResponse>
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public string ID { get; set; }

        public UserGroupsSearch(string name, int level)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/system/groups/get");

            this.Name = name;
            this.Level = level.ToString();
        }

        public UserGroupsSearch(string id)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/system/groups/get");

            this.ID = id;
        }

        public override async Task<UserGroupsSearchResponse> PerformRequestAsync()
        {
            if (ID is not null)
            {
                this.Arguments.Add($"id={HttpUtility.UrlEncode(this.ID)}");
            }
            else
            {
                this.Arguments.Add($"n={HttpUtility.UrlEncode(this.Name)}");
                this.Arguments.Add($"l={HttpUtility.UrlEncode(this.Level)}");
            }

            this.Response = Task.Run(() => Requester.Get(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new UserGroupsSearchResponse(this.Response)
                {
                    Groups = JsonConvert.DeserializeObject<Dictionary<string, Group>>(this.Response.RawMessage)
                };
            }
            else
                return new UserGroupsSearchResponse(Error.GetError(this.Response));
        }
    }
}
