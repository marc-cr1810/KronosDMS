using ImGuiNET;
using KronosDMS_Client.Render.Controls;
using KronosDMS_Client.Render.ImGUI;
using KronosDMS_Client.Render.Windows.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render
{
    public class MainWindow : Window
    {
        MenuStrip Menu;
        MenuStripMenuItem MenuFile;
        MenuStripMenuItem MenuParts;
        MenuStripMenuItem MenuSetup;
        MenuStripMenuItem MenuTools;
        MenuStripItem MenuToolsConsole;

        public MainWindow(string title, int width = 1280, int height = 720) : base(title, width, height)
        {
            // Initialization
            Menu = new MenuStrip("Menu");
            MenuFile = new MenuStripMenuItem("MenuFile", "File");
            MenuParts = new MenuStripMenuItem("MenuParts", "Parts");
            MenuSetup = new MenuStripMenuItem("MenuSetup", "Setup");
            MenuTools = new MenuStripMenuItem("MenuTools", "Tools");
            MenuToolsConsole = new MenuStripItem("MenuToolsConsole", "Console");

            // Menu
            Menu.Items.AddRange(new MenuStripItem[]
            {
                MenuFile, MenuParts, MenuSetup, MenuTools
            });

            // MenuTools
            MenuTools.MenuItems.Add(MenuToolsConsole);

            // MenuToolsConsole
            MenuToolsConsole.Click = MenuToolsConsole_Clicked;
        }

        protected override void Draw()
        {
            // Dockspace settings
            bool dockspaceOpen = true;
            bool opt_fullscreen_persistant = true;
            bool opt_fullscreen = opt_fullscreen_persistant;
            ImGuiDockNodeFlags dockspaceFlags = ImGuiDockNodeFlags.None;

            // We are using the ImGuiWindowFlags_NoDocking flag to make the parent window not dockable into,
            // because it would be confusing to have two docking targets within each others.
            ImGuiWindowFlags window_flags = ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoDocking;
            if (opt_fullscreen)
            {
                ImGuiViewportPtr viewport = ImGui.GetMainViewport();
                ImGui.SetNextWindowPos(viewport.Pos);
                ImGui.SetNextWindowSize(viewport.Size);
                ImGui.SetNextWindowViewport(viewport.ID);
                ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
                ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);
                window_flags |= ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove;
                window_flags |= ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus;
            }

            // When using ImGuiDockNodeFlags_PassthruCentralNode, DockSpace() will render our background and handle the pass-thru hole, so we ask Begin() to not render a background.
            if (dockspaceFlags.HasFlag(ImGuiDockNodeFlags.PassthruCentralNode))
                window_flags |= ImGuiWindowFlags.NoBackground;

            // Important: note that we proceed even if Begin() returns false (aka window is collapsed).
            // This is because we want to keep our DockSpace() active. If a DockSpace() is inactive, 
            // all active windows docked into it will lose their parent and become undocked.
            // We cannot preserve the docking relationship between an active window and an inactive docking, otherwise 
            // any change of dockspace/settings would lead to windows being stuck in limbo and never being visible.
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, 0.0f);
            ImGui.Begin("Dockspace", ref dockspaceOpen, window_flags);
            ImGui.PopStyleVar();

            if (opt_fullscreen)
                ImGui.PopStyleVar(1);

            // Dockspace
            ImGuiIOPtr io = ImGui.GetIO();
            ImGuiStylePtr style = ImGui.GetStyle();
            float minWinSizeX = style.WindowMinSize.X;
            style.WindowMinSize.X = 370.0f;
            if (io.ConfigFlags.HasFlag(ImGuiConfigFlags.DockingEnable))
            {
                uint dockspaceID = ImGui.GetID("EditorDockspace");
                ImGui.DockSpace(dockspaceID, new Vector2(0.0f, 0.0f), dockspaceFlags);
            }

            style.WindowMinSize.X = minWinSizeX;

            Menu.Draw();

            WindowManager.Render();

            // End the dockspace
            ImGui.End();
        }

        protected override void Update()
        {
            WindowManager.Update();
        }

        #region EventHandlers

        private void MenuToolsConsole_Clicked()
        {
            WindowManager.Open(new ConsoleWindow());
        }

        #endregion
    }
}
