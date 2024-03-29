﻿using KronosDMS.Http.Server.Models;
using KronosDMS.Security;

namespace KronosDMS_Server.Handlers
{
    public class UserAccountsHandler
    {
        public static Route Login = new Route()
        {
            Name = "Account Login Handler",
            UrlRegex = @"^/api/v1/auth/login$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
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

        public static Route Logout = new Route()
        {
            Name = "Account Logout Handler",
            UrlRegex = @"^/api/v1/auth/logout$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                string result = Server.AccountManager.Logout(request.Content);
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

        public static Route Validate = new Route()
        {
            Name = "Validate User Account Login Handler",
            UrlRegex = @"^/api/v1/accounts/validate$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                int id = Routes.GetUserFromKey(request).ID;
                string accessToken = Routes.GetAccessToken(request);

                if (Server.AccountManager.ValidateLogin(id, accessToken))
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "{}",
                        ReasonPhrase = "OK",
                        StatusCode = "200"
                    };
                }
                else
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "Invalid token",
                        ReasonPhrase = "InvalidToken",
                        StatusCode = "498"
                    };
                }
            }
        };

        public static Route Get = new Route()
        {
            Name = "Get User Accounts Handler",
            UrlRegex = @"^/api/v1/accounts/get$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "server.accounts.get"))
                    return PermissionHandler.UnauthorizedResponse;

                string username = Routes.GetArgValue(request, "u");
                string firstname = Routes.GetArgValue(request, "f");
                string lastname = Routes.GetArgValue(request, "l");
                int id = -1;
                if (Routes.GetArgValue(request, "id") != "")
                    id = int.Parse(Routes.GetArgValue(request, "id"));

                return new HttpResponse()
                {
                    ContentAsUTF8 = Server.AccountManager.Search(username, firstname, lastname, id),
                    ReasonPhrase = "OK",
                    StatusCode = "200"
                };
            }
        };

        public static Route Set = new Route()
        {
            Name = "Set User Account Handler",
            UrlRegex = @"^/api/v1/accounts/set$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "server.accounts.set"))
                    return PermissionHandler.UnauthorizedResponse;

                if (Server.AccountManager.Set(request.Content))
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "{}",
                        ReasonPhrase = "OK",
                        StatusCode = "200"
                    };
                }
                else
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "User Account not modified",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };

        public static Route SetPassword = new Route()
        {
            Name = "Set User Password Account Handler",
            UrlRegex = @"^/api/v1/accounts/set/password$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "server.accounts.set.password"))
                    return PermissionHandler.UnauthorizedResponse;

                string oldPassword = Routes.GetArgValue(request, "o");
                string newPassword = Routes.GetArgValue(request, "n");
                int id = Routes.GetUserFromKey(request).Username is not null ? Routes.GetUserFromKey(request).ID : -1;
                if (Routes.GetArgValue(request, "id") != "")
                    id = int.Parse(Routes.GetArgValue(request, "id"));

                if (Server.AccountManager.SetPassword(id, oldPassword, newPassword))
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "{}",
                        ReasonPhrase = "OK",
                        StatusCode = "200"
                    };
                }
                else
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "Failed to change password",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };

        public static Route Add = new Route()
        {
            Name = "Add User Account Handler",
            UrlRegex = @"^/api/v1/accounts/add$",
            Method = "POST",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "server.accounts.add"))
                    return PermissionHandler.UnauthorizedResponse;

                if (Server.AccountManager.Create(request.Content))
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "{}",
                        ReasonPhrase = "OK",
                        StatusCode = "200"
                    };
                }
                else
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "USer Account already exists",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };

        public static Route Remove = new Route()
        {
            Name = "Remove User Account Handler",
            UrlRegex = @"^/api/v1/accounts/delete$",
            Method = "GET",
            Callable = (HttpRequest request) =>
            {
                if (!Routes.HasPermission(request, "server.accounts.remove"))
                    return PermissionHandler.UnauthorizedResponse;

                int id = int.Parse(Routes.GetArgValue(request, "id"));

                if (Server.AccountManager.Remove(id))
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "{}",
                        ReasonPhrase = "OK",
                        StatusCode = "200"
                    };
                }
                else
                {
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = "User Account already does not exist",
                        ReasonPhrase = "NotModified",
                        StatusCode = "304"
                    };
                }
            }
        };
    }
}
