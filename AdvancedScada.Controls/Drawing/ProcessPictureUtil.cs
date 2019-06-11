using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace AdvancedScada.HMIs.Drawing
{
	public class ProcessPictureUtil
	{
		public static Image CreateCircleImage(Image img, Size objSize, Color borderColor, int borderSize = 5)
		{
			Bitmap bitmap = new Bitmap(img);
			int num = (bitmap.Width <= bitmap.Height) ? bitmap.Width : bitmap.Height;
			Rectangle rect = new Rectangle(0, 0, num, num);
			bitmap = bitmap.Clone(rect, bitmap.PixelFormat);
			TextureBrush brush = new TextureBrush(bitmap);
			Bitmap bitmap2 = new Bitmap(num, num);
			Graphics graphics = Graphics.FromImage(bitmap2);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.FillEllipse(brush, 0, 0, num, num);
			graphics.DrawEllipse(new Pen(borderColor, borderSize), borderSize / 2, borderSize / 2, num - borderSize, num - borderSize);
			return new Bitmap(bitmap2, new Size(objSize.Width, objSize.Width));
		}

		public static byte[] ImageToByteArray(Image imageIn)
		{
			MemoryStream memoryStream = new MemoryStream();
			imageIn.Save(memoryStream, ImageFormat.Gif);
			return memoryStream.ToArray();
		}

		public static Image ByteArrayToImage(byte[] byteArrayIn)
		{
			return Image.FromStream(new MemoryStream(byteArrayIn));
		}
	}
}
