using System.Collections.Generic;

namespace KronosDMS.Objects
{
    public class Group
    {
        public int Level;
        public List<string> Permissions;

        public Group(int level, List<string> permissions)
        {
            this.Level = level;
            this.Permissions = permissions;
        }
    }
}
