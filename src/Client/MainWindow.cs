﻿using ImGuiNET;
using KronosDMS_Client.Render;
using KronosDMS_Client.Render.Windows;
using KronosDMS_Client.Render.Windows.Forms.Parts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

namespace KronosDMS_Client
{
    public class MainWindow
    {
        private bool InitializedImGUI = false;

        private Sdl2Window _window;
        private GraphicsDevice _gd;
        private CommandList _cl;
        private ImGuiController _controller;

        // UI state test stuff
        private Vector3 _clearColor = new Vector3(0.45f, 0.55f, 0.6f);

        static void SetThing(out float i, float val) { i = val; }

        // Acutal variables
        private WindowCreateInfo WindowCreationInfo { get; set; }
        private GraphicsDeviceOptions GDOptions { get; set; }

        public MainWindow(string title = "KronosDMS Client", int width = 1280, int height = 720)
        {
            WindowState windowState = Client.Config.StartMaximized ? WindowState.Maximized : WindowState.Normal;

            WindowCreationInfo = new WindowCreateInfo(50, 50, width, height, windowState, title);
            GDOptions = new GraphicsDeviceOptions(false, null, true, ResourceBindingModel.Improved, true, true);

            Color background = Client.ActiveTheme.Colors.Background;
            _clearColor = new Vector3((float)background.R / 255, (float)background.G / 255, (float)background.B / 255);
        }

        public void Show()
        {
            // Create window, GraphicsDevice, and all resources necessary for the demo.
            Logger.Log("Creating window and graphics device", LogLevel.INFO, $"Window width: {WindowCreationInfo.WindowWidth}\n" +
                $"Window height: {WindowCreationInfo.WindowHeight}\n" +
                $"Graphics backend setting: \"{Client.Config.GraphicsBackend}\"");

            VeldridStartup.CreateWindowAndGraphicsDevice(
                WindowCreationInfo,
                GDOptions,
                Client.Config.GetGraphicsBackend(),
                out _window,
                out _gd);

            _window.Resized += () =>
            {
                _gd.MainSwapchain.Resize((uint)_window.Width, (uint)_window.Height);
                _controller.WindowResized(_window.Width, _window.Height);
            };

            _cl = _gd.ResourceFactory.CreateCommandList();
            _controller = new ImGuiController(_gd, _window, _gd.MainSwapchain.Framebuffer.OutputDescription, _window.Width, _window.Height);
            InitializedImGUI = true;
            Random random = new Random();

            SetStatusTitle();

            Client.ActiveTheme.Load(); // Load active theme after ImGui init

            Logger.Log("Starting application");
            // Main application loop
            while (_window.Exists)
            {
                InputSnapshot snapshot = _window.PumpEvents();
                if (!_window.Exists) { break; }
                _controller.Update(1f / 60f, snapshot); // Feed the input events to our ImGui controller, which passes them through to ImGui.

                SubmitUI();

                _cl.Begin();
                _cl.SetFramebuffer(_gd.MainSwapchain.Framebuffer);
                _cl.ClearColorTarget(0, new RgbaFloat(_clearColor.X, _clearColor.Y, _clearColor.Z, 1f));
                _controller.Render(_gd, _cl);
                _cl.End();
                _gd.SubmitCommands(_cl);
                _gd.SwapBuffers(_gd.MainSwapchain);
                _controller.SwapExtraWindows(_gd);
            }

            Dispose();
        }

        private unsafe void SubmitUI()
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
            ImGui.Begin("Editor Dockspace", ref dockspaceOpen, window_flags);
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
                    if (ImGui.MenuItem("Render Debug"))
                        WindowManager.ShowMetricsWindow = true;
                    ImGui.EndMenu();
                }
                ImGui.EndMenuBar();
            }

            Client.Update();
            WindowManager.Render();

            SetThing(out io.DeltaTime, 2f);

            ImGui.End();
        }

        public void SetStatusTitle(string status = "$DEFAULT_VAL")
        {
            if (status is null || status.Length == 0)
                _window.Title = $"KronosDMS v{Application.ProductVersion}";
            else if (status == "$DEFAULT_VAL")
                _window.Title = $"Currently logged in as {Client.ActiveAccount.FirstName} {Client.ActiveAccount.LastName} ({Client.ActiveAccount.Username})";
            else
                _window.Title = $"KronosDMS v{Application.ProductVersion} | {status}";
        }

        public bool ImGuiInitialized()
        {
            return InitializedImGUI;
        }

        public void Close()
        {
            if (_window != null)
            { 
                _window.Close();
                Dispose();
            }
        }

        public void Dispose()
        {
            Logger.Log("Closing application");
            // Clean up Veldrid resources
            _gd.WaitForIdle();
            _controller.Dispose();
            _cl.Dispose();
            _gd.Dispose();
        }
    }
}
