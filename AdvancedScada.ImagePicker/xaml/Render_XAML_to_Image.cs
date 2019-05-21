using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;

namespace AdvancedScada.ImagePicker.xaml
{
    public class Render_XAML_to_Image
    {
        public static void GetPNG()
        {
            var dpiX = 96.0;
            var dpiY = 96.0;

            var xaml =
                "<Page\r\n" +
                " xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\r\n" +
                " xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">\r\n" +
                " <Canvas>\r\n" +
                " <Rectangle Width=\"220\" Height=\"100\"\r\n" +
                " RadiusX=\"10\" RadiusY=\"10\" Fill=\"#90d0ff\"/>\r\n" +
                " <TextBlock Canvas.Left=\"25CaCanvas.Top=\"25\"\r\n" +
                " FontSize=\"16\" Foreground=\"White\">Mike Coxeter's .Net Blog</TextBlock>\r\n" +
                " <TextBlock Opacity=\".5\" Canvas.Left=\"26CaCanvas.Top=\"50\"\r\n" +
                " FontSize=\"16\" Foreground=\"White\" >C#, .Net, WPF</TextBlock>\r\n" +
                " </Canvas>\r\n" +
                "</Page>";

            var xmlReader = new XmlTextReader(new StringReader(xaml));
            using (Stream imageStream = File.Create(@"c:\dotNetBlog.png"))
            {
                XamlToImageSteam(xmlReader, new PngBitmapEncoder(), imageStream, dpiX, dpiY);
            }
        }

        public static Stream XamlToImageSteam(
            XmlTextReader xmlReader, BitmapEncoder encoder, Stream outputStream,
            double dpiX, double dpiY)
        {
            var wind = new Window();
            wind.WindowStyle = WindowStyle.None;
            wind.ShowInTaskbar = false;
            wind.ShowActivated = false;

            // Create Minimized so the window does not show.
            wind.WindowState = WindowState.Minimized;
            wind.SizeToContent = SizeToContent.WidthAndHeight;

            wind.Content = (UIElement) XamlReader.Load(xmlReader);
            wind.Show(); // The window needs to be created for the XAML elements to be rendered. 
            var bitmapSrc = visualToBitmap(wind, dpiX, dpiY);

            encoder.Frames.Clear();
            encoder.Frames.Add(BitmapFrame.Create(bitmapSrc));
            encoder.Save(outputStream);

            outputStream.Flush();

            wind.Hide();
            return outputStream;
        }

        private static BitmapSource visualToBitmap(Visual target, double dpiX, double dpiY)
        {
            if (target == null) return null;

            var bounds = VisualTreeHelper.GetDescendantBounds(target);

            var width = (int) (bounds.Width * dpiX / 96.0);
            var height = (int) (bounds.Height * dpiX / 96.0);

            var renderer = new RenderTargetBitmap(
                width, height, dpiX,
                dpiY, PixelFormats.Pbgra32);

            renderer.Render(target);

            return renderer;
        }

        private Image GetImageFromResource(string s)
        {
            // s is a XAML resource stored in the Window or in the Application
            var db = Application.Current.Resources[s] as DrawingBrush;

            if (db != null)
            {
                // Create an image (wrong kind of Image though)
                var i = new System.Windows.Controls.Image
                {
                    Height = 300,
                    Width = 300,
                    Source = new DrawingImage(db.Drawing)
                };

                // Need to render this into a bitmap.  First setting up a DrawingVisual.
                var drawingVisual = new DrawingVisual();
                var drawingContext = drawingVisual.RenderOpen();
                drawingContext.DrawImage(i.Source, new Rect(0, 0, 300, 300));
                drawingContext.Close();

                // Now rendering
                var bmp = new RenderTargetBitmap(300, 300, 96, 96, PixelFormats.Pbgra32);
                bmp.Render(drawingVisual);

                // Encode to get the stream
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));

                // The stream will contain the image
                using (var stream = new MemoryStream())
                {
                    encoder.Save(stream);

                    // Now generate the correct type of image from this stream
                    return Image.FromStream(stream);
                }
            }

            return null;
        }
    }
}