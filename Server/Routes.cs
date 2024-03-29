﻿using KronosDMS.Http.Server.Models;
using KronosDMS.Http.Server.RouteHandlers;
using KronosDMS.Objects;
using KronosDMS.Security;
using KronosDMS_Server.Handlers;
using System.Collections.Generic;
using System.IO;

namespace KronosDMS_Server
{
    public class Routes
    {
        public static List<Route> GetRoutes()
        {
            return new List<Route>() {
                ServerHandler.Reload,

                ClientHandler.Update,
                ClientHandler.UpdaterDownload,
                ClientHandler.Themes,

                UserAccountsHandler.Login,
                UserAccountsHandler.Logout,
                UserAccountsHandler.Validate,
                UserAccountsHandler.Get,
                UserAccountsHandler.Set,
                UserAccountsHandler.SetPassword,
                UserAccountsHandler.Add,
                UserAccountsHandler.Remove,

                GroupsHandler.Get,
                GroupsHandler.Add,
                GroupsHandler.Remove,
                GroupsHandler.Set,

                MakeHandler.Get,
                MakeHandler.Set,
                MakeHandler.Add,

                PartsHandler.Get,
                PartsHandler.Set,
                PartsHandler.Add,
                PartsHandler.Remove,

                RecallHandler.Get,
                RecallHandler.Set,
                RecallHandler.Add,
                RecallHandler.Remove,
                RecallHandler.LockState,

                KitHandler.Get,
                KitHandler.Set,
                KitHandler.Add,
                KitHandler.Remove,
                KitHandler.LockState,

                FormatsHandler.GetCSV,

                new Route {
                    Name = "Ping Handler",
                    UrlRegex = @"^/api/v1/ping$",
                    Method = "GET",
                    Callable = (HttpRequest request) => {
                        return new HttpResponse()
                        {
                            ContentAsUTF8 = "{}",
                            ReasonPhrase = "OK",
                            StatusCode = "200"
                        };
                     }
                },

                new Route {
                    Name = "Installer Downloader Handler",
                    UrlRegex = @"^/installer",
                    Method = "GET",
                    Callable = (HttpRequest request) => {
                        if (File.Exists("data/client/installer.zip"))
                        {
                            var response = new HttpResponse();
                            response.StatusCode = "200";
                            response.ReasonPhrase = "Ok";
                            response.Headers["Content-Type"] = QuickMimeTypeMapper.GetMimeType(".zip");
                            response.Content = File.ReadAllBytes("data/client/installer.zip");

                            return response;
                        }
                        else
                        {
                            return new HttpResponse()
                            {
                                ContentAsUTF8 = "Bad Request",
                                ReasonPhrase = "BadRequest",
                                StatusCode = "400"
                            };
                        }
                    }
                }
            };
        }

        public static string GetArgValue(HttpRequest request, string arg)
        {
            if (request.Arguments.ContainsKey(arg))
                return request.Arguments[arg];
            return "";
        }

        public static bool HasPermission(HttpRequest request, string permission)
        {
            UserAccount user = GetUserFromKey(request);
            if (!PermissionHandler.Has(user, permission))
            {
                KConsole.WriteColoredLine(System.ConsoleColor.DarkRed, $"[KronosDMS Auth] User Account \"{user.Username}\" lacks permission {permission}");
                return false;
            }
            return true;
        }

        public static string GetAccessToken(HttpRequest request)
        {
            string accessToken = "";
            if (request.Headers.ContainsKey("Authorization"))
                accessToken = request.Headers["Authorization"].Split(' ')[1];
            return accessToken;
        }

        public static UserAccount GetUserFromKey(HttpRequest request)
        {
            return Server.AccountManager.GetAccount(GetAccessToken(request));
        }
    }
}
