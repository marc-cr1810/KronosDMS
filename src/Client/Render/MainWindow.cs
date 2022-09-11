using ImGuiNET;
using KronosDMS_Client.Render.Controls;
using KronosDMS_Client.Render.ImGUI;
using KronosDMS_Client.Render.Windows.Parts;
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
        MenuStripMenuItem MenuPartsQueries;
        MenuStripItem MenuPartsPartSearch;
        MenuStripItem MenuPartsMaintenance;

        MenuStripMenuItem MenuSetup;

        MenuStripMenuItem MenuTools;
        MenuStripItem MenuToolsHelloImGui;
        MenuStripItem MenuToolsConsole;
        MenuStripItem MenuToolsSwitchToLegacy;

        public MainWindow(string title, int width = 1280, int height = 720) : base(title, width, height)
        {
            // Initialize controls
            Menu = new MenuStrip("Menu");
            MenuFile = new MenuStripMenuItem("MenuFile", "File");
            MenuParts = new MenuStripMenuItem("MenuParts", "Parts");
            MenuPartsQueries = new MenuStripMenuItem("MenuPartsQueries", "Queries");
            MenuPartsPartSearch = new MenuStripItem("MenuPartsPartSearch", "Parts Search");
            MenuPartsMaintenance = new MenuStripItem("MenuPartsMaintenance", "Parts Maintenance");
            MenuSetup = new MenuStripMenuItem("MenuSetup", "Setup");
            MenuTools = new MenuStripMenuItem("MenuTools", "Tools");
            MenuToolsHelloImGui = new MenuStripItem("MenuToolsHelloImGui", "Show Hello ImGui");
            MenuToolsConsole = new MenuStripItem("MenuToolsConsole", "Console");
            MenuToolsSwitchToLegacy = new MenuStripItem("MenuToolsSwitchToLegacy", "Switch to Legacy");

            // Menu
            Menu.Items.AddRange(new MenuStripItem[]
            {
                MenuFile, MenuParts, MenuSetup, MenuTools
            });

            // MenuParts
            MenuParts.MenuItems.AddRange(new MenuStripItem[]
            {
                MenuPartsQueries, MenuPartsMaintenance
            });

            // MenuPartsQueries
            MenuPartsQueries.MenuItems.AddRange(new MenuStripItem[]
            {
                MenuPartsPartSearch
            });

            // MenuPartsPartSearch
            MenuPartsPartSearch.Click = MenuPartsPartSearch_Clicked;

            // MenuPartsMaintenance
            MenuPartsMaintenance.Click = MenuPartsMaintenance_Clicked;

            // MenuTools
            MenuTools.MenuItems.AddRange(new MenuStripItem[] 
            {
                MenuToolsHelloImGui, MenuToolsConsole, MenuToolsSwitchToLegacy
            });

            // MenuToolsHelloImGui
            MenuToolsHelloImGui.Click = MenuToolsHelloImGui_Clicked;

            // MenuToolsConsole
            MenuToolsConsole.Click = MenuToolsConsole_Clicked;

            // MenuToolsSwitchToLegacy
            MenuToolsSwitchToLegacy.Click = MenuToolsSwitchToLegacy_Clicked;
        }

        protected override void OnLoad()
        {
            SetStatusTitle($"Currently logged in as {Client.ActiveAccount.FirstName} {Client.ActiveAccount.LastName} ({Client.ActiveAccount.Username})");
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
        public void SetStatusTitle(string status = "")
        {
            if (status is null || status == "")
                SDLWindow.Title = $"KronosDMS v{Client.GetAppVersion()}";
            else
                SDLWindow.Title = $"KronosDMS v{Client.GetAppVersion()} | {status}";
        }

        #region EventHandlers

        private void MenuPartsPartSearch_Clicked()
        {
            WindowManager.Open(new PartsSearchForm());
        }

        private void MenuPartsMaintenance_Clicked()
        {
            WindowManager.Open(new PartMaintenanceForm());
        }

        private void MenuToolsHelloImGui_Clicked()
        {
            WindowManager.ShowImGuiDemoWindow = true;
        }

        private void MenuToolsConsole_Clicked()
        {
            WindowManager.Open(new ConsoleWindow());
        }

        private void MenuToolsSwitchToLegacy_Clicked()
        {
            Client.SwitchClientType = true;
            Close();
        }

        #endregion
    }
}
