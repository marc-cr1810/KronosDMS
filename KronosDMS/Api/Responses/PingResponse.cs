namespace KronosDMS.Api.Responses
{
    public class PingResponse : Response
    {
        internal PingResponse(Response response) : base(response)
        {
        }

        public bool Success { get; internal set; }
    }
}
