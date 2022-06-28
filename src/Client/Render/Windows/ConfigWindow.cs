using ImGuiNET;
using KronosDMS_Client.Render.Windows.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client.Render.Windows
{
    public class ConfigWindow : Window
    {
        private TextBox IPAddress;
        private ComboBox Theme;
        private ComboBox StartMaximized;
        private ComboBox GraphicsBackend;
        private HelpMarker GBHint;

        private ComboBox ThemeFont;
        private HelpMarker FontSizeHint;

        public ConfigWindow() : base("Config", 640, 528)
        {
            IPAddress = new TextBox("IP Address", Client.Config.IPAddress);
            IPAddress.ReadOnly = true;

            Theme = new ComboBox(ThemeManager.GetThemes(), "Theme");
            Theme.SetItem(Client.Config.Theme);
            Theme.SelectionChanged = ThemeChanged;

            StartMaximized = new ComboBox(new string[] { "True", "False" }, "Start Maximized");
            StartMaximized.SetItem(Client.Config.StartMaximized ? "True" : "False");
            StartMaximized.SelectionChanged = StartMaximizedChanged;

            GraphicsBackend = new ComboBox(new string[] { "Platform Default", "DirectX3D11", "OpenGL", "Vulkan", "Metal" }, "Graphics Backend");
            GraphicsBackend.SetItem(Client.Config.GraphicsBackend);
            GraphicsBackend.SelectionChanged = GBChanged;
            GBHint = new HelpMarker("For changes to happen you have to restart the application.\n" +
                "This setting changes the backend graphics API for this application.\n" +
                "You should only change this if you know what you are doing and are having issues with the current backend.\n" +
                "Note:\n" +
                " - DirectX3D11 is only for Windows platforms\n" +
                " - Metal is only for MacOS platforms");

            ThemeFont = new ComboBox(FontManager.GetFontNames(), "Font");
            ThemeFont.SetItem(Client.ActiveTheme.Settings.Font);
            ThemeFont.SelectionChanged = FontChanged;
            FontSizeHint = new HelpMarker("Have to restart the application for changes to apply.");
        }

        protected override void Draw()
        {
            ImGui.Text("Application Settings");
            if (ImGui.BeginTabBar("settings_tabs"))
            {
                if (ImGui.BeginTabItem("Settings"))
                {
                    IPAddress.Draw();
                    StartMaximized.Draw();
                    GraphicsBackend.Draw();
                    ImGui.SameLine();
                    GBHint.Draw();
                    ImGui.EndTabItem();
                }
                if (ImGui.BeginTabItem("Theme"))
                {
                    Theme.Draw();
                    ImGui.SameLine();
                    if (ImGui.Button("Save"))
                    {
                        Client.ActiveTheme.Save();
                    }
                    ImGui.Spacing();

                    if (ImGui.BeginTabBar("config_theme_values_tab"))
                    {
                        ImGui.Spacing();
                        ImGuiStylePtr style = ImGui.GetStyle();

                        if (ImGui.BeginTabItem("Font"))
                        {
                            ThemeFont.Draw();
                            ImGui.EndTabItem();
                        }

                        if (ImGui.BeginTabItem("Colors"))
                        {
                            ImGui.Text("ImGui Colors");
                            ImGui.Separator();
                            ImGui.BeginChild("config_theme_values", new Vector2(0.0f, 350));
                            for (int i = 0; i < style.Colors.Count; i++)
                            {
                                string name = ImGui.GetStyleColorName((ImGuiCol)i);
                                ImGui.ColorEdit4(name, ref style.Colors[i]);
                            }
                            ImGui.EndChild();
                            ImGui.Separator();
                            ImGui.EndTabItem();
                        }

                        if (ImGui.BeginTabItem("Rendering"))
                        {
                            ImGui.Text("Borders:");
                            { bool border = (style.WindowBorderSize > 0.0f); if (ImGui.Checkbox("Window Border", ref border)) { style.WindowBorderSize = border ? 1.0f : 0.0f; } }
                            { bool border = (style.FrameBorderSize > 0.0f); if (ImGui.Checkbox("Frame Border", ref border)) { style.FrameBorderSize = border ? 1.0f : 0.0f; } }
                            { bool border = (style.PopupBorderSize > 0.0f); if (ImGui.Checkbox("Popup Border", ref border)) { style.PopupBorderSize = border ? 1.0f : 0.0f; } }
                            ImGui.Spacing();

                            ImGui.Text("Anti-Aliasing:");
                            ImGui.Checkbox("Anti-Aliased Lines", ref style.AntiAliasedLines);
                            ImGui.Checkbox("Anti-Aliased Lines Use Tex", ref style.AntiAliasedLinesUseTex);
                            ImGui.Checkbox("Anti-Aliased Fill", ref style.AntiAliasedFill);
                            ImGui.Spacing();
                        }
                        ImGui.EndTabBar();
                    }
                }
                ImGui.EndTabBar();
            }
        }

        private void StartMaximizedChanged()
        {
            Client.Config.StartMaximized = StartMaximized.Text == "True" ? true : false;
            Client.Config.Save();
        }

        private void GBChanged()
        {
            Client.Config.GraphicsBackend = GraphicsBackend.Text;
            Client.Config.Save();
        }

        private void ThemeChanged()
        {
            Client.Config.Theme = Theme.Text;
            Client.ActiveTheme  = ThemeManager.LoadTheme(Theme.Text);
            Client.Config.Save();
        }

        private void FontChanged()
        {
            ThemeFont.SetItem(FontManager.SetThemeFont(ThemeFont.Text, ref Client.ActiveTheme), false);
            Client.Config.Save();
        }

        protected override void OnClose()
        {
            // Set the ImGui style settings to be what the active theme's settings are
            Client.ActiveTheme.SetImGuiStyle();
            Client.ActiveTheme.SetImGuiColors();
        }
    }
}
