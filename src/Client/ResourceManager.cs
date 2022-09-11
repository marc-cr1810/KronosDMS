using KronosDMS.Utils;
using KronosDMS_Client.Properties;
using KronosDMS_Client.Render.ImGUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veldrid;
using Veldrid.ImageSharp;

namespace KronosDMS_Client
{
    public class Image
    {
        private IntPtr ID;

        public Image(string path, ImGuiController controller, GraphicsDevice gd)
        {
            Logger.Log($"Loading image \"{Path.GetFileName(path)}\"", LogLevel.INFO, $"Path: {path}");

            ImageSharpTexture img = new ImageSharpTexture(path);
            Texture dimg = img.CreateDeviceTexture(gd, gd.ResourceFactory);

            TextureViewDescription viewDesc = new TextureViewDescription(dimg, PixelFormat.R8_G8_B8_A8_UNorm);
            TextureView texView = gd.ResourceFactory.CreateTextureView(viewDesc);

            ID = controller.GetOrCreateImGuiBinding(gd.ResourceFactory, texView);
        }

        public IntPtr GetID() { return ID; }
    }

    public static class ResourceManager
    {
        public static Image ImageSaveIcon;

        public static void Load(ImGuiController controller, GraphicsDevice gd)
        {
            Logger.Log("Loading resources");

            ImageSaveIcon = new Image("themes/images/save_icon.png", controller, gd);

            Logger.Log("Completed loading resources", LogLevel.OK);
        }
    }
}
