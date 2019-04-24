using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public class HandleImage
    {
        public static BitmapImage byteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                var image = new BitmapImage();
                using (var ms = new MemoryStream(byteArrayIn))
                {
                    ms.Position = 0;
                    image.BeginInit();
                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = null;
                    image.StreamSource = ms;
                    image.EndInit();
                }
                image.Freeze();
                return image;
            }
            catch
            {
                throw new Exception("Erreur lors de la récupération de l'image");
            }
        }
    }
}
