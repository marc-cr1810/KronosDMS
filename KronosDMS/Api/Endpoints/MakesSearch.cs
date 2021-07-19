using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace KronosDMS.Api.Endpoints
{
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
