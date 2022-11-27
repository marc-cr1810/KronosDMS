using ImGuiNET;
using KronosDMS.Utils;
using KronosDMS_Client.Render.ImGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render
{
    public struct WindowData
    {
        public ImGuiWindow Window;
        public Action OnClosed;

        public WindowData(ImGuiWindow window)
        {
            Window = window;
            OnClosed = null;
        }

        public WindowData(ImGuiWindow window, Action onClosed)
        {
            Window = window;
            OnClosed = onClosed;
        }
    }

    public static class WindowManager
    {
        public static bool ShowImGuiDemoWindow = false;
        public static bool ShowMetricsWindow = false;
        public static bool ShowServerDisconnectionMsg = false;

        private static List<WindowData> Windows { get; set; }

        public static void Init()
        {
            Windows = new List<WindowData>();
            Logger.Log("Initialized window manager", LogLevel.OK);
        }

        public static void Update()
        {
            for (int i = 0; i < Windows.Count; i++)
            {
                WindowData data = Windows[i];
                ImGuiWindow window = data.Window;
                if (window != null)
                {
                    if (!window.Open)
                    {
                        Close(window);
                        if (data.OnClosed != null)
                            data.OnClosed();
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

        public static void Open(ImGuiWindow window)
        {
            if (window == null)
            {
                Logger.Log("Failed to open a window", LogLevel.ERROR, "at WindowManager.cs void Open(Window window)\n\tValue of \"window\" is NULL");
            }
            window.Init();
            Windows.Add(new WindowData(window));
        }

        public static void OpenChild(ImGuiWindow parent, ImGuiWindow window, Action onClosed = null)
        {
            window.Parent = parent;
            window.Init();
            Windows.Add(new WindowData(window, onClosed));
        }

        public static void Close(ImGuiWindow window)
        {
            if (window == null)
            {
                Logger.Log("Failed to close a window", LogLevel.ERROR, "at WindowManager.cs void Close(Window window)\n\tValue of \"window\" is NULL");
            }
            window.Close();
            WindowData data = Windows.First(w => w.Window.ID == window.ID);
            Windows.Remove(data);
        }

        public static int GetWindowCount()
        {
            return Windows.Count;
        }
    }
}
