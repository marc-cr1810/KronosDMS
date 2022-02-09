using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS.Api.Endpoints
{
    public class GetFormat : IEndpoint<GetFormatResponse>
    {
        public GetFormat(string type, string name)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + $"/api/v1/formats/{type}/{name}");
        }

        public override async Task<GetFormatResponse> PerformRequestAsync()
        {
            this.Response = Task.Run(() => Requester.Get(this)).Result;

            if (this.Response.IsSuccess)
            {
                CSVFormat format = JsonConvert.DeserializeObject<CSVFormat>(this.Response.RawMessage);

                return new GetFormatResponse(this.Response)
                {
                    Format = format
                };
            }
            else
                return new GetFormatResponse(Error.GetError(this.Response));
        }
    }
}
