namespace KronosDMS.Api.Responses
{
    public class GetUpdateInfoResponse : Response
    {
        internal GetUpdateInfoResponse(Response response) : base(response)
        {
        }

        public string Version { get; internal set; }
        public bool Force { get; internal set; }
    }
}
