using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AdvancedScada.ImagePicker.xaml
{
    public enum ScaleTO
    {
        OriginalSize = 1,
        TargetSize = 2
    }

    /// <summary>
    ///     Source: http://blog.galasoft.ch/archive/2008/10/10/converting-and-customizing-xaml-to-png-with-server-side-wpf.aspx
    /// </summary>
    public class XamlToPngConverter
    {
        public void Convert(string xamlInput,
            double width,
            double height,
            double dpiX,
            double dpiY,
            ScaleTO thisScale,
            Stream pngOutput)
        {
            try
            {
                // Round width and height to simplify
                width = Math.Round(width);
                height = Math.Round(height);

                var pngCreationThread = new Thread((ThreadStart) delegate
                {
                    FrameworkElement element = null;

                    try
                    {
                        element = XamlReader.Parse(xamlInput) as FrameworkElement;
                    }
                    catch (XamlParseException)
                    {
                    }

                    if (element != null)
                    {
                        var renderingSize = new Size(width, height);
                        element.Measure(renderingSize);
                        var renderingRectangle = new Rect(renderingSize);
                        element.Arrange(renderingRectangle);

                        var xamlBitmap = RenderToBitmap(element, width, height, dpiX, dpiY, thisScale);
                        try
                        {
                            var enc = new PngBitmapEncoder();
                            enc.Frames.Add(BitmapFrame.Create(xamlBitmap));
                            enc.Save(pngOutput);
                        }
                        catch (ObjectDisposedException)
                        {
                            // IF the operation lasted too long, the object might be disposed already
                        }
                    }
                });

                pngCreationThread.IsBackground = true;
                pngCreationThread.SetApartmentState(ApartmentState.STA);
                pngCreationThread.Start();
                pngCreationThread.Join();
            }
            catch (Exception Exp)
            {
                throw Exp;
            }

            try
            {
                if (pngOutput.Length == 0) throw new TimeoutException();
            }
            catch (ObjectDisposedException)
            {
                // If the object was disposed, it means that the Stream is ready.
            }
        }

        public static BitmapSource RenderToBitmap(FrameworkElement target,
            double width,
            double height,
            double dpiX,
            double dpiY,
            ScaleTO thisScale)
        {
            Rect bounds;

            switch (thisScale)
            {
                case ScaleTO.OriginalSize:
                    bounds = VisualTreeHelper.GetDescendantBounds(target);
                    break;
                case ScaleTO.TargetSize:
                    bounds = new Rect(0, 0, width, height);
                    break;
                default:
                    throw new ArgumentException(string.Format("The scaling mode: {0} is not supported.",
                        thisScale.ToString()));
            }

            var renderBitmap = new RenderTargetBitmap((int) target.ActualWidth,
                (int) target.ActualHeight, dpiX, dpiY, PixelFormats.Pbgra32);

            var visual = new DrawingVisual();
            using (var context = visual.RenderOpen())
            {
                var brush = new VisualBrush(target);
                context.DrawRectangle(brush, null, new Rect(new Point(), bounds.Size));
            }

            renderBitmap.Render(visual);
            return renderBitmap;
        }
    }
}