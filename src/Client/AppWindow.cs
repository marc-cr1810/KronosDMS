using ImGuiNET;
using KronosDMS_Client.Render;
using KronosDMS_Client.Render.Windows;
using KronosDMS_Client.Render.Windows.Forms.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Veldrid;

namespace KronosDMS_Client
{
    public class AppWindow : Window
    {
        private bool DockspaceOpen = true;
        private bool OptFullscreenPersistant = true;
        private bool OptFullscreen;

        public AppWindow(string title, int width = 1280, int height = 720) : base(title, width, height)
        {
            WindowState windowState = Client.Config.StartMaximized ? WindowState.Maximized : WindowState.Normal;            
            WindowCreationInfo.WindowInitialState = windowState;

            OptFullscreen = OptFullscreenPersistant;
        }

        protected override void Draw()
        {
            ImGuiDockNodeFlags dockspaceFlags = ImGuiDockNodeFlags.None;

            // We are using the ImGuiWindowFlags_NoDocking flag to make the parent window not dockable into,
            // because it would be confusing to have two docking targets within each others.
            ImGuiWindowFlags windowFlags = ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoDocking;
            if (OptFullscreen)
            {
                ImGuiViewportPtr viewport = ImGui.GetMainViewport();
                ImGui.SetNextWindowPos(viewport.Pos);
                ImGui.SetNextWindowSize(viewport.Size);
                ImGui.SetNextWindowViewport(viewport.ID);
                ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
                ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);
                windowFlags |= ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove;
                windowFlags |= ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus;
            }

            // When using ImGuiDockNodeFlags_PassthruCentralNode, DockSpace() will render our background and handle the pass-thru hole, so we ask Begin() to not render a background.
            if (dockspaceFlags.HasFlag(ImGuiDockNodeFlags.PassthruCentralNode))
                windowFlags |= ImGuiWindowFlags.NoBackground;

            // Important: note that we proceed even if Begin() returns false (aka window is collapsed).
            // This is because we want to keep our DockSpace() active. If a DockSpace() is inactive, 
            // all active windows docked into it will lose their parent and become undocked.
            // We cannot preserve the docking relationship between an active window and an inactive docking, otherwise 
            // any change of dockspace/settings would lead to windows being stuck in limbo and never being visible.
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, 0.0f);
            ImGui.Begin("Dockspace", ref DockspaceOpen, windowFlags);
            ImGui.PopStyleVar();

            if (OptFullscreen)
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

            DrawMenu();

            WindowManager.Render();

            // End the Dockspace
            ImGui.End();
        }

        protected override void Update()
        {
            Client.Update();
        }

        private void DrawMenu()
        {
            if (ImGui.BeginMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Parts"))
                {
                    if (ImGui.BeginMenu("Service Kits"))
                    {
                        if (ImGui.MenuItem("Recalls"))
                            WindowManager.Open(new RecallForm());
                        ImGui.EndMenu();
                    }
                    if (ImGui.BeginMenu("Queries"))
                    {
                        if (ImGui.MenuItem("Parts Search"))
                            WindowManager.Open(new PartsSearchForm());
                        if (ImGui.MenuItem("Recalls Search"))
                            WindowManager.Open(new RecallsSearchForm());
                        if (ImGui.MenuItem("Kits Search"))
                            WindowManager.Open(new KitsSearchForm());
                        ImGui.EndMenu();
                    }
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Setup"))
                {
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Tools"))
                {
                    if (ImGui.MenuItem("Config"))
                        WindowManager.Open(new ConfigWindow());
                    if (ImGui.MenuItem("Console"))
                        WindowManager.Open(new ConsoleWindow());
                    if (GD.BackendType != GraphicsBackend.OpenGL)
                    {
                        if (ImGui.MenuItem("Render Debug"))
                            WindowManager.ShowMetricsWindow = true;
                    }
                    ImGui.EndMenu();
                }
                ImGui.EndMenuBar();
            }
        }
    }
}
