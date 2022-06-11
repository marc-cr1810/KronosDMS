using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Windows
{
    public class ConsoleWindow : Window
    {
        public ConsoleWindow() : base("Console")
        {

        }

        protected override void Draw()
        {
            ImGui.BeginChild("ConsoleOutput", Vector2.Zero, true);
            for (int i = 0; i < Logger.Count(); i++)
            {
                LoggerItem logItem = Logger.Get(i);
                Vector4 color = Theme.ColorToVec4(Client.ActiveTheme.Colors.Console.Info);
                switch (logItem.Level)
                {
                    case LogLevel.OK: color = Theme.ColorToVec4(Client.ActiveTheme.Colors.Console.Ok); break;
                    case LogLevel.WARN: color = Theme.ColorToVec4(Client.ActiveTheme.Colors.Console.Warning); break;
                    case LogLevel.ERROR: color = Theme.ColorToVec4(Client.ActiveTheme.Colors.Console.Error); break;
                    case LogLevel.FATAL: color = Theme.ColorToVec4(Client.ActiveTheme.Colors.Console.Fatal); break;
                }
                ImGui.PushStyleColor(ImGuiCol.Text, color);
                if (ImGui.TreeNode(logItem.ToString()))
                {
                    if (logItem.Details != "")
                        ImGui.TextUnformatted(logItem.Details);
                    ImGui.TreePop();
                }
                ImGui.PopStyleColor();
            }
            ImGui.EndChild();
        }
    }
}
