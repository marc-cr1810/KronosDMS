using KronosDMS.Files;
using KronosDMS.Http.Server.Models;
using KronosDMS.Objects;

namespace KronosDMS.Security
{
    public static class PermissionHandler
    {
        public static Group DefaultGroup = new Group() { Level = 0, Permissions = new System.Collections.Generic.List<string>() };
        public static GroupsFile GroupsFile;

        public readonly static HttpResponse UnauthorizedResponse = new HttpResponse()
        {
            ContentAsUTF8 = "Incorrect permissions",
            ReasonPhrase = "Forbidden",
            StatusCode = "403"
        };

        public static bool Has(UserAccount user, string permission)
        {
            Group group = user.Group is not null ? GroupsFile.Groups[user.Group] : DefaultGroup;

            if (group.Permissions is null)
                return false;
            foreach (string p in group.Permissions)
            {
                if (p.EndsWith(".*") && permission.StartsWith(p.Substring(0, p.Length - 2)))
                    return true;
                if (p == permission)
                    return true;
                if (p == "*")
                    return true;
            }
            return false;
        }

        public static void SetDefaultGroup(string group)
        {
            DefaultGroup = GroupsFile.Groups[group];
        }
    }
}
