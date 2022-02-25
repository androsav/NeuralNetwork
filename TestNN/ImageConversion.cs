using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNN
{
	// в этом классе собраны функции для преобразования изображений, работы с ними
	public class ImageConversion
	{
		//метод очистки поля для рисования
		public static void FilldrawingBox(Bitmap bitmap)
		{
			for (int i = 0; i < 28; i++)
			{
				for (int j = 0; j < 28; j++)
				{
					bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
				}
			}
		}

		//преобразование массива пикселей в массив, состоящий из элементов 0 и 1, где 1 заменяются все отличные от белых пикселы
		public static double[] GetBinaryStates(double[] pixelVals)
		{
			for (int i = 0; i < pixelVals.Length; i++)
			{
				var buf = pixelVals[i];
				if (buf > 0)
					pixelVals[i] = 1;
				else
					pixelVals[i] = 0;
			}
			return pixelVals;
		}

		public static Bitmap RemoveWhitePixels(Bitmap image)
		{
			for (int i = 0; i < 28; i++)
			{
				for (int j = 0; j < 28; j++)
				{

					if (image.GetPixel(i, j) == Color.FromArgb(255, 255, 255, 255))
					{
						image.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
					}
				}
			}
			return image;
		}

		// преобразовать массив в рисунок
		public static Bitmap GetBitmapFromArr(int[,] array)
		{
			Bitmap bitmap = new Bitmap(array.GetLength(0), array.GetLength(1));
			for (int x = 0; x < array.GetLength(0); x++)
				for (int y = 0; y < array.GetLength(1); y++)
					if (array[x, y] == 0)
						bitmap.SetPixel(x, y, Color.White);
					else
						bitmap.SetPixel(x, y, Color.Black);
			return bitmap;
		}

		// обрезать рисунок по краям и преобразовать в массив
		public static int[,] CutImageToArray(Bitmap b, Point max)
		{
			int x1 = 0;
			int y1 = 0;
			int x2 = max.X;
			int y2 = max.Y;

			for (int y = 0; y < b.Height && y1 == 0; y++)
				for (int x = 0; x < b.Width && y1 == 0; x++)
					if (b.GetPixel(x, y).ToArgb() != 0) y1 = y;
			for (int y = b.Height - 1; y >= 0 && y2 == max.Y; y--)
				for (int x = 0; x < b.Width && y2 == max.Y; x++)
					if (b.GetPixel(x, y).ToArgb() != 0) y2 = y;
			for (int x = 0; x < b.Width && x1 == 0; x++)
				for (int y = 0; y < b.Height && x1 == 0; y++)
					if (b.GetPixel(x, y).ToArgb() != 0) x1 = x;
			for (int x = b.Width - 1; x >= 0 && x2 == max.X; x--)
				for (int y = 0; y < b.Height && x2 == max.X; y++)
					if (b.GetPixel(x, y).ToArgb() != 0) x2 = x;

			if (x1 == 0 && y1 == 0 && x2 == max.X && y2 == max.Y) return null;

			int size = x2 - x1 > y2 - y1 ? x2 - x1 + 1 : y2 - y1 + 1;
			int dx = y2 - y1 > x2 - x1 ? ((y2 - y1) - (x2 - x1)) / 2 : 0;
			int dy = y2 - y1 < x2 - x1 ? ((x2 - x1) - (y2 - y1)) / 2 : 0;

			int[,] res = new int[size, size];
			for (int x = 0; x < res.GetLength(0); x++)
				for (int y = 0; y < res.GetLength(1); y++)
				{
					int pX = x + x1 - dx;
					int pY = y + y1 - dy;
					if (pX < 0 || pX >= max.X || pY < 0 || pY >= max.Y)
						res[x, y] = 0;
					else
						res[x, y] = b.GetPixel(x + x1 - dx, y + y1 - dy).ToArgb() == 0 ? 0 : 1;
				}
			return res;
		}

		// пересчитать массив source в массив res - используется для 
		// приведения произвольного массива данных к массиву стандартных размеров
		public static int[,] LeadArray(int[,] source, int[,] res)
		{
			for (int n = 0; n < res.GetLength(0); n++)
				for (int m = 0; m < res.GetLength(1); m++) res[n, m] = 0;

			double pX = (double)res.GetLength(0) / (double)source.GetLength(0);
			double pY = (double)res.GetLength(1) / (double)source.GetLength(1);

			for (int n = 0; n < source.GetLength(0); n++)
				for (int m = 0; m < source.GetLength(1); m++)
				{
					int posX = (int)(n * pX);
					int posY = (int)(m * pY);
					if (res[posX, posY] == 0) res[posX, posY] = source[n, m];
				}
			return res;
		}
	}
}
