using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace KronosDMS.Api.Endpoints
{
    public class RecallsSearch : IEndpoint<RecallsSearchResponse>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }

        public RecallsSearch(string make, string model, string number, string description)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/getrecall");

            this.Make = make;
            this.Model = model;
            this.Number = number;
            this.Description = description;
        }

        public RecallsSearch(string id)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/getrecall");

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
