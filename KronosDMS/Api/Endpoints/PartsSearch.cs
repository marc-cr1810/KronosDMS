using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace KronosDMS.Api.Endpoints
{
    public class PartsSearch : IEndpoint<PartsSearchResponse>
    {
        public string Make { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }

        public PartsSearch(string make, string number, string description)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/getpart");

            this.Make = make;
            this.Number = number;
            this.Description = description;
        }

        public PartsSearch(string id)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/getpart");

            this.ID = id;
        }

        public override async Task<PartsSearchResponse> PerformRequestAsync()
        {
            if (ID is not null)
            {
                this.Arguments.Add($"id={HttpUtility.UrlEncode(this.ID)}");
            }
            else
            {
                this.Arguments.Add($"f={HttpUtility.UrlEncode(this.Make)}");
                this.Arguments.Add($"n={HttpUtility.UrlEncode(this.Number)}");
                this.Arguments.Add($"d={HttpUtility.UrlEncode(this.Description)}");
            }

            this.Response = Task.Run(() => Requester.Get(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new PartsSearchResponse(this.Response)
                {
                    Parts = JsonConvert.DeserializeObject<Dictionary<string, Part>>(this.Response.RawMessage)
                };
            }
            else
                return new PartsSearchResponse(Error.GetError(this.Response));
        }
    }
}
