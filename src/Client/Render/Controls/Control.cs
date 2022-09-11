using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Controls
{
    public class Control
    {
        public string Name { get; set; }
        public string Text { get; set; }

        // Action event functions
        public Action Click = null;

        public Control(string name)
        {
            Name = name;
            Text = name;
        }

        public Control(string name, string text)
        {
            Name = name;
            Text = text;
        }

        public virtual void Draw() { }
    }
}
