using KronosDMS.Http.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Server.Handlers
{
    public class AccountsHandler
    {
        public static Route Login = new Route()
        {
            Name = "Account Login Handler",
            UrlRegex = @"^/api/login$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                string username = Routes.GetArgValue(request, "username");
                string passwordHash = Routes.GetArgValue(request, "password");

                string result = Server.AccountManager.Login(request.Content);
                if (result != "")
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = result,
                        ReasonPhrase = "OK",
                        StatusCode = "200"
                    };
                }
                else
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "Incorrect username or password",
                        ReasonPhrase = "Unauthorized",
                        StatusCode = "561"
                    };
                }
            }
        };
    }
}
