using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace KronosDMS.Api.Endpoints
{
    public class KitAdd : IEndpoint<Response>
    {
        public Kit Kit { get; set; }

        public KitAdd(Kit kit)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/kits/add");
            this.Kit = kit;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.PostContent = JsonConvert.SerializeObject(this.Kit);
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

    public class KitRemove : IEndpoint<Response>
    {
        public string ID { get; set; }

        public KitRemove(string id)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/kits/delete");
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

    public class KitSet : IEndpoint<Response>
    {
        public Kit Kit { get; set; }

        public KitSet(Kit kit)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/kits/set");
            this.Kit = kit;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.PostContent = JsonConvert.SerializeObject(this.Kit);
            this.Response = Task.Run(() => Requester.Post(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new Response(this.Response);
            }
            else
                return new Response(Error.GetError(this.Response));
        }
    }

    public class KitsSearch : IEndpoint<KitsSearchResponse>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }

        public KitsSearch(string make, string model, string number, string description)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/kits/get");

            this.Make = make;
            this.Model = model;
            this.Number = number;
            this.Description = description;
        }

        public KitsSearch(string id)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/kits/get");

            this.ID = id;
        }

        public override async Task<KitsSearchResponse> PerformRequestAsync()
        {
            if (ID is not null)
            {
                this.Arguments.Add($"id={HttpUtility.UrlEncode(this.ID)}");
            }
            else
            {
                this.Arguments.Add($"f={HttpUtility.UrlEncode(this.Make)}");
                this.Arguments.Add($"m={HttpUtility.UrlEncode(this.Model)}");
                this.Arguments.Add($"n={HttpUtility.UrlEncode(this.Number)}");
                this.Arguments.Add($"d={HttpUtility.UrlEncode(this.Description)}");
            }

            this.Response = Task.Run(() => Requester.Get(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new KitsSearchResponse(this.Response)
                {
                    Kits = JsonConvert.DeserializeObject<Dictionary<string, Kit>>(this.Response.RawMessage)
                };
            }
            else
                return new KitsSearchResponse(Error.GetError(this.Response));
        }
    }
}
