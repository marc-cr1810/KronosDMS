using KronosDMS.Utils;

namespace KronosDMS.Api.Responses
{
    public class GetUpdateInfoResponse : Response
    {
        internal GetUpdateInfoResponse(Response response) : base(response)
        {
        }

        public UpdateInfo UpdateInfo { get; set; }
    }
}
