using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using Color = System.Windows.Media.Color;
using Image = System.Drawing.Image;
using Rectangle = System.Windows.Shapes.Rectangle;
using Size = System.Windows.Size;

namespace AdvancedScada.ImagePicker.xaml
{
    public class ClassResXResourceReade
    {
        public static Canvas previewTarget;
        public int _bmpHeight;
        public int _bmpWidth;

        private int _currentX;
        private int _currentY;
        public Bitmap _targetBitmap;

        public static Image ConvertXamltoImage2(string XamlString, double Width, double Height)
        {
            // Round width and height to simplify
            Width = Math.Round(Width);
            Height = Math.Round(Height);
            FrameworkElement element = null;
            var streamOut = new MemoryStream();
            try
            {
                element = XamlReader.Parse(XamlString) as FrameworkElement;

                if (element != null)
                {
                    var renderingSize = new Size(Width, Height);
                    element.Measure(renderingSize);
                    var renderingRectangle = new Rect(renderingSize);
                    element.Arrange(renderingRectangle);

                    var xamlBitmap =
                        XamlToPngConverter.RenderToBitmap(element, Width, Height, 90, 90, ScaleTO.OriginalSize);
                    try
                    {
                        var enc = new PngBitmapEncoder();
                        enc.Frames.Add(BitmapFrame.Create(xamlBitmap));
                        enc.Save(streamOut);
                    }
                    catch (ObjectDisposedException)
                    {
                        // IF the operation lasted too long, the object might be disposed already
                    }
                }
            }
            catch (XamlParseException)
            {
            }


            var img = Image.FromStream(streamOut);
            streamOut.Close();
            return img;


            //}
        }

        private void ProcessPixel(object sender, EventArgs e)
        {
            if (_currentX < _bmpWidth)
            {
                var pixel = _targetBitmap.GetPixel(_currentX, _currentY);
                var rectangle = new Rectangle();
                rectangle.Fill = new SolidColorBrush(Color.FromArgb(pixel.A, pixel.R, pixel.G, pixel.B));
                rectangle.Height = rectangle.Width = 1.0;
                rectangle.SetValue(Canvas.LeftProperty, (double) _currentX);
                rectangle.SetValue(Canvas.TopProperty, (double) _currentY);
                rectangle.SnapsToDevicePixels = true;
                ++_currentX;
            }
            else
            {
                _currentX = 0;
                if (_currentY + 1 == _bmpHeight)
                {
                    CompositionTarget.Rendering -= ProcessPixel;
                    WriteXaml();
                }
                else
                {
                    ++_currentY;
                }
            }
        }

        public static string ProcessBitmapSynchronous(string fileURL)
        {
            previewTarget = new Canvas();
            Rectangle rectangle = null;
            var bitmap = new Bitmap(Image.FromFile(fileURL));
            previewTarget.Height = bitmap.Height;
            previewTarget.Width = bitmap.Width;
            var xamlOutputText = string.Empty;

            for (var y = 0; y < bitmap.Height; ++y)
            for (var x = 0; x < bitmap.Width; ++x)
            {
                var pixel = bitmap.GetPixel(x, y);
                rectangle = new Rectangle();
                rectangle.Fill = new SolidColorBrush(Color.FromArgb(pixel.A, pixel.R, pixel.G, pixel.B));
                rectangle.Height = rectangle.Width = 1.0;
                rectangle.SetValue(Canvas.LeftProperty, (double) x);
                rectangle.SetValue(Canvas.TopProperty, (double) y);
                rectangle.SnapsToDevicePixels = true;
                previewTarget.Children.Add(rectangle);
            }

            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            var output = new StringBuilder();
            XamlWriter.Save(previewTarget, XmlWriter.Create(output, settings));
            xamlOutputText = output.ToString();
            return xamlOutputText;
        }

        public static string ProcessBitmapSynchronous(PictureBox fileURL)
        {
            previewTarget = new Canvas();
            Rectangle rectangle = null;
            var bitmap = new Bitmap(fileURL.Image);
            previewTarget.Height = bitmap.Height;
            previewTarget.Width = bitmap.Width;
            var xamlOutputText = string.Empty;

            for (var y = 0; y < bitmap.Height; ++y)
            for (var x = 0; x < bitmap.Width; ++x)
            {
                var pixel = bitmap.GetPixel(x, y);
                rectangle = new Rectangle();
                rectangle.Fill = new SolidColorBrush(Color.FromArgb(pixel.A, pixel.R, pixel.G, pixel.B));
                rectangle.Height = rectangle.Width = 1.0;
                rectangle.SetValue(Canvas.LeftProperty, (double) x);
                rectangle.SetValue(Canvas.TopProperty, (double) y);
                rectangle.SnapsToDevicePixels = true;
                previewTarget.Children.Add(rectangle);
            }

            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            var output = new StringBuilder();
            XamlWriter.Save(previewTarget, XmlWriter.Create(output, settings));
            xamlOutputText = output.ToString();
            return xamlOutputText;
        }

        private void WriteXaml()
        {
            var xamlOutputText = string.Empty;
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            var output = new StringBuilder();
            XamlWriter.Save(XmlWriter.Create(output, settings));
            xamlOutputText = output.ToString();
        }
    }
}