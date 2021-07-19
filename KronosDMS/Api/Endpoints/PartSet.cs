using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace KronosDMS.Api.Endpoints
{
    public class PartSet : IEndpoint<Response>
    {
        public Part Part { get; set; }

        public PartSet(Part part)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/parts/set");
            this.Part = part;
        }

        public override async Task<Response> PerformRequestAsync()
        {
            this.PostContent = JsonConvert.SerializeObject(this.Part);
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
}
