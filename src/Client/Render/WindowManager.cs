using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render
{
    public static class WindowManager
    {
        public static bool ShowImGuiDemoWindow = false;
        public static bool ShowMetricsWindow = false;
        public static bool ShowServerDisconnectionMsg = false;

        private static List<Window> Windows { get; set; }

        public static void Init()
        {
            Windows = new List<Window>();
            Logger.Log("Initialized window manager", LogLevel.OK);
        }

        public static void Update()
        {
            for (int i = 0; i < Windows.Count; i++)
            {
                Window window = Windows[i];
                if (window != null)
                {
                    if (!window.Open)
                    {
                        Close(window);
                        i--;
                    }
                    window.Show();
                }
            }
        }

        public static void Render()
        {
            // Show the ImGui demo window. Most of the sample code is in ImGui.ShowDemoWindow(). Read its code to learn more about Dear ImGui!
            if (ShowImGuiDemoWindow)
            {
                // Normally user code doesn't need/want to call this because positions are saved in .ini file anyway.
                // Here we just want to make the demo initial state a bit more friendly!
                ImGui.SetNextWindowPos(new Vector2(650, 20), ImGuiCond.FirstUseEver);
                ImGui.ShowDemoWindow(ref ShowImGuiDemoWindow);
            }

            if (ShowMetricsWindow)
            {
                ImGui.ShowMetricsWindow(ref ShowMetricsWindow);
            }
        }

        public static void Open(Window window)
        {
            if (window == null)
            {
                Logger.Log("Failed to open a window", LogLevel.ERROR, "at WindowManager.cs void Open(Window window)\n\tValue of \"window\" is NULL");
            }
            Windows.Add(window);
        }

        public static void Close(Window window)
        {
            if (window == null)
            {
                Logger.Log("Failed to close a window", LogLevel.ERROR, "at WindowManager.cs void Close(Window window)\n\tValue of \"window\" is NULL");
            }
            window.Close();
            Windows.Remove(window);
        }

        public static int GetWindowCount()
        {
            return Windows.Count;
        }
    }
}
