﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

namespace KronosDMS_Client.Render
{
    public class Window
    {
        private Sdl2Window SDLWindow;
        private GraphicsDevice GD;
        private CommandList CL;
        private ImGuiController Controller;

        private bool InitializedImGui = false;
        private bool Sleeping = false;

        private Vector3 ClearColor = Vector3.Zero;

        private WindowCreateInfo WindowCreationInfo;
        private GraphicsDeviceOptions GDOptions;

        public Window(string title, int width = 1280, int height = 720)
        {
            WindowCreationInfo = new WindowCreateInfo(50, 50, width, height, WindowState.Normal, title);
            GDOptions = new GraphicsDeviceOptions(false, null, true, ResourceBindingModel.Improved, true, true);

            Vector4 background = Client.ActiveTheme.Colors.ImGuiColors["DockingEmptyBg"];
            ClearColor = new Vector3(background.X, background.Y, background.Z);

            OnLoad();
        }

        public bool Show()
        {
            Create();
            Init();

            Logger.Log("Running application loop");
            while (SDLWindow.Exists)
            {
                try
                {
                    InputSnapshot snapshot = SDLWindow.PumpEvents();
                    if (!SDLWindow.Exists) { break; }
                    Controller.Update(1f / 60f, snapshot); // Feed the input events to our ImGui controller, which passes them through to ImGui.

                    if (Sleeping && GD.BackendType == GraphicsBackend.OpenGL)
                        continue;

                    FontManager.PushFont(Client.ActiveTheme.Settings.Font);
                    Draw();
                    FontManager.PopFont();

                    CL.Begin();
                    CL.SetFramebuffer(GD.MainSwapchain.Framebuffer);
                    CL.ClearColorTarget(0, new RgbaFloat(ClearColor.X, ClearColor.Y, ClearColor.Z, 1f));
                    Controller.Render(GD, CL);
                    CL.End();
                    GD.SubmitCommands(CL);
                    GD.SwapBuffers(GD.MainSwapchain);
                    Controller.SwapExtraWindows(GD);
                }
                catch (Exception ex)
                {
                    string msg = "An error occured during the application runtime";
                    LogLevel level = LogLevel.FATAL;

                    // Handle errors here

                    if (level == LogLevel.FATAL)
                        msg = "A fatal error occured during the application runtime";

                    Logger.LogException(msg, ex, level);

                    if (level == LogLevel.FATAL)
                        return false;
                }
            }

            Dispose();
            return true;
        }

        public void Close()
        {
            Logger.Log("Closing application");
            OnClose();

            if (SDLWindow != null)
                SDLWindow.Close();
            Dispose();
        }

        private void Dispose()
        {
            // Clean up Veldrid resources
            GD.WaitForIdle();
            Controller.Dispose();
            CL.Dispose();
            GD.Dispose();
        }

        protected virtual void OnLoad() { }

        protected virtual void OnClose() { }

        protected virtual void Draw() { }

        private bool Create()
        {
            // Create window, GraphicsDevice, and all resources necessary
            Logger.Log("Creating window and graphics device", LogLevel.INFO, $"Window width: {WindowCreationInfo.WindowWidth}\n" +
                $"Window height: {WindowCreationInfo.WindowHeight}\n" +
                $"Graphics backend setting: \"{Client.Config.GraphicsBackend}\"");

            string details = $"Graphics Backend: \"{GetGraphicsBackendVer()}\"\n";

            try
            {
                VeldridStartup.CreateWindowAndGraphicsDevice(
                    WindowCreationInfo,
                    GDOptions,
                    Client.Config.GetGraphicsBackend(),
                    out SDLWindow,
                    out GD);

                // Check if the DirectX version on Windows is supported (aka DirectX 11 or newer)
                if (GD != null)
                {
                    if (GD.BackendType == GraphicsBackend.Direct3D11 && GD.ApiVersion.Major < 11)
                    {
                        Logger.Log("Unsupported DirectX version", LogLevel.ERROR, $"DirectX Version: {GD.ApiVersion.Major}.{GD.ApiVersion.Minor}\n" +
                            "Minimum Required: 11.0\n" +
                            "Switching from DirectX to OpenGL and saving changes to the config");
                        Client.Config.GraphicsBackend = "OpenGL";
                        Client.Config.Save();
                        SDLWindow.Close();
                        GD.Dispose();
                        return Create();
                    }
                }
            }
            catch (Exception ex)
            {
                if (GD.BackendType == GraphicsBackend.Direct3D11 && GD.ApiVersion.Major < 11)
                {
                    Logger.Log("Unsupported DirectX version", LogLevel.ERROR, $"DirectX Version: {GD.ApiVersion.Major}.{GD.ApiVersion.Minor}\n" +
                        "Minimum Required: 11.0\n" +
                        "Switching from DirectX to OpenGL and saving changes to the config");
                    Client.Config.GraphicsBackend = "OpenGL";
                    Client.Config.Save();
                    SDLWindow.Close();
                    GD.Dispose();
                    return Create();
                }
                else
                {
                    Logger.LogException("Failed to create window and graphics device", ex, LogLevel.FATAL, details);
                    return false;
                }
            }

            details = $"Graphics Backend: \"{GetGraphicsBackendVer()}\"\nGraphics Device: \"{GD.DeviceName}\"";
            Logger.Log("Successfully created window and setup graphics device", LogLevel.OK, details);

            return true;
        }

        private bool Init()
        {
            SDLWindow.Resized += () =>
            {
                if (SDLWindow.WindowState == WindowState.Minimized && GD.BackendType == GraphicsBackend.OpenGL)
                    Sleeping = true;
                else
                    Sleeping = false;
                GD.MainSwapchain.Resize((uint)SDLWindow.Width, (uint)SDLWindow.Height);
                Controller.WindowResized(SDLWindow.Width, SDLWindow.Height);
            };

            CL = GD.ResourceFactory.CreateCommandList();
            Controller = new ImGuiController(GD, SDLWindow, GD.MainSwapchain.Framebuffer.OutputDescription, SDLWindow.Width, SDLWindow.Height);
            InitializedImGui = true;
            Random random = new Random();

            Client.ActiveTheme.Load(); // Load active theme after ImGui init

            return true;
        }

        protected string GetGraphicsBackendVer()
        {
            if (GD is null)
            {
                GraphicsBackend graphicsBackend = Client.Config.GetGraphicsBackend();
                switch (graphicsBackend)
                {
                    case GraphicsBackend.Direct3D11:
                        return "DirectX 11";
                    case GraphicsBackend.OpenGL:
                    case GraphicsBackend.OpenGLES:
                        {
                            int profile = (int)SDL_GLProfile.Core;
                            int major = 0;
                            int minor = 0;
                            unsafe
                            {
                                Sdl2Native.SDL_GL_GetAttribute(SDL_GLAttribute.ContextProfileMask, &profile);
                                Sdl2Native.SDL_GL_GetAttribute(SDL_GLAttribute.ContextMajorVersion, &major);
                                Sdl2Native.SDL_GL_GetAttribute(SDL_GLAttribute.ContextMinorVersion, &minor);
                            }
                            string p = profile == (int)SDL_GLProfile.Core ? "Core" : profile == (int)SDL_GLProfile.Compatibility ? "Compatibility" : "ES";
                            return $"OpenGL {p} {major}.{minor}";
                        }
                    case GraphicsBackend.Vulkan:
                        return "Vulkan";
                    case GraphicsBackend.Metal:
                        return "Metal";
                }
            }
            else
            {
                return $"{GD.BackendType} {GD.ApiVersion.Major}.{GD.ApiVersion.Minor}";
            }
            return "NULL";
        }

        public bool ImGuiInitialized()
        {
            return InitializedImGui;
        }
    }
}
