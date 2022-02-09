using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace KronosDMS.Api.Endpoints
{
    public class MakeAdd : IEndpoint<Response>
    {
        public Make Make { get; set; }

        public MakeAdd(Make make)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/makes/add");
            this.Make = make;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.PostContent = JsonConvert.SerializeObject(this.Make);
            this.Response = Task.Run(() => Requester.Post(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new Response(this.Response)
                {

                };
            }
            else
                return new Response(Error.GetError(this.Response));
        }
    }

    public class MakeRemove : IEndpoint<Response>
    {
        public string ID { get; set; }

        public MakeRemove(string id)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/makes/delete");
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

    public class MakeSet : IEndpoint<Response>
    {
        public Make Make { get; set; }

        public MakeSet(Make make)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/makes/set");
            this.Make = make;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.PostContent = JsonConvert.SerializeObject(this.Make);
            this.Response = Task.Run(() => Requester.Post(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new Response(this.Response)
                {

                };
            }
            else
                return new Response(Error.GetError(this.Response));
        }
    }

    public class MakesSearch : IEndpoint<MakesSearchResponse>
    {
        public string Name { get; set; }

        public MakesSearch(string name)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/makes/get");

            this.Name = name;
        }

        public override async Task<MakesSearchResponse> PerformRequestAsync()
        {
            this.Arguments.Add($"n={HttpUtility.UrlEncode(this.Name)}");

            this.Response = Task.Run(() => Requester.Get(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new MakesSearchResponse(this.Response)
                {
                    Makes = JsonConvert.DeserializeObject<Dictionary<string, Make>>(this.Response.RawMessage)
                };
            }
            else
                return new MakesSearchResponse(Error.GetError(this.Response));
        }
    }
}
