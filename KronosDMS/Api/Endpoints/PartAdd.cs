using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace KronosDMS.Api.Endpoints
{
    public class PartAdd : IEndpoint<Response>
    {
        public Part Part { get; set; }

        public PartAdd(Part part)
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/addpart");
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
