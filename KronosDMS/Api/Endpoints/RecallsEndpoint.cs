using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace KronosDMS.Api.Endpoints
{
    public class RecallAdd : IEndpoint<Response>
    {
        public Recall Recall { get; set; }

        public RecallAdd(Recall recall)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/recalls/add");
            this.Recall = recall;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.PostContent = JsonConvert.SerializeObject(this.Recall);
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

    public class RecallRemove : IEndpoint<Response>
    {
        public string ID { get; set; }

        public RecallRemove(string id)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/recalls/delete");
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

    public class RecallSet : IEndpoint<Response>
    {
        public Recall Recall { get; set; }

        public RecallSet(Recall recall)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/recalls/set");
            this.Recall = recall;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.PostContent = JsonConvert.SerializeObject(this.Recall);
            this.Response = Task.Run(() => Requester.Post(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new Response(this.Response);
            }
            else
                return new Response(Error.GetError(this.Response));
        }
    }

    public class RecallsSearch : IEndpoint<RecallsSearchResponse>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }

        public RecallsSearch(string make, string model, string number, string description)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/recalls/get");

            this.Make = make;
            this.Model = model;
            this.Number = number;
            this.Description = description;
        }

        public RecallsSearch(string id)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/recalls/get");

            this.ID = id;
        }

        public override async Task<RecallsSearchResponse> PerformRequestAsync()
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
                return new RecallsSearchResponse(this.Response)
                {
                    Recalls = JsonConvert.DeserializeObject<Dictionary<string, Recall>>(this.Response.RawMessage)
                };
            }
            else
                return new RecallsSearchResponse(Error.GetError(this.Response));
        }
    }
}
