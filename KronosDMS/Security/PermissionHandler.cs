using KronosDMS.Files;
using KronosDMS.Http.Server.Models;
using KronosDMS.Objects;

namespace KronosDMS.Security
{
    public static class PermissionHandler
    {
        public static GroupsFile GroupsFile;

        public readonly static HttpResponse UnauthorizedResponse = new HttpResponse()
        {
            ContentAsUTF8 = "Incorrect permissions",
            ReasonPhrase = "Forbidden",
            StatusCode = "403"
        };

        public static bool Has(UserAccount user, string permission)
        {
            if (user.Group is null)
                return false;
            if (GroupsFile.Groups.ContainsKey(user.Group))
            {
                foreach (string p in GroupsFile.Groups[user.Group].Permissions)
                {
                    if (p.EndsWith(".*") && permission.StartsWith(p.Substring(0, p.Length - 2)))
                        return true;
                    if (p == permission)
                        return true;
                    if (p == "*")
                        return true;
                }
            }
            return false;
        }
    }
}
