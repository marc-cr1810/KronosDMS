using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
