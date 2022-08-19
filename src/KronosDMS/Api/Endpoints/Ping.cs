using KronosDMS.Api.Responses;
using System;
using System.Threading.Tasks;

namespace KronosDMS.Api.Endpoints
{
    public class Ping : IEndpoint<PingResponse>
    {
        public Ping()
        {
            this.Address = new Uri(Requester.BaseAPIAddr + "/api/v1/ping");
        }

        public override async Task<PingResponse> PerformRequestAsync()
        {
            this.Response = Task.Run(() => Requester.Get(this)).Result;

            if (this.Response.IsSuccess)
            {
                return new PingResponse(this.Response)
                {
                    Success = true
                };
            }
            else
                return new PingResponse(Error.GetError(this.Response));
        }
    }
}
