using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNN
{
	//в этом классе описаны методы для работы с обучающей выборкой
	public class TrainingSample
	{
		public static DigitImage[] LoadData(string pixelFile, string labelFile)
		{
			int numImages = 60000;
			DigitImage[] result = new DigitImage[numImages];
			byte[][] pixels = new byte[28][];
			for (int i = 0; i < pixels.Length; ++i)
				pixels[i] = new byte[28];
			FileStream ifsPixels = new FileStream(pixelFile, FileMode.Open);
			FileStream ifsLabels = new FileStream(labelFile, FileMode.Open);
			BinaryReader brImages = new BinaryReader(ifsPixels);
			BinaryReader brLabels = new BinaryReader(ifsLabels);
			int magic1 = brImages.ReadInt32(); // обратный порядок байтов
			magic1 = ReverseBytes(magic1); // преобразуем в формат Intel
			int imageCount = brImages.ReadInt32();
			imageCount = ReverseBytes(imageCount);
			int numRows = brImages.ReadInt32();
			numRows = ReverseBytes(numRows);
			int numCols = brImages.ReadInt32();
			numCols = ReverseBytes(numCols);
			int magic2 = brLabels.ReadInt32();
			magic2 = ReverseBytes(magic2);
			int numLabels = brLabels.ReadInt32();
			numLabels = ReverseBytes(numLabels);
			for (int di = 0; di < numImages; ++di)
			{
				for (int i = 0; i < 28; ++i) // получаем пиксельные
											 // значения 28x28
				{
					for (int j = 0; j < 28; ++j)
					{
						byte b = brImages.ReadByte();
						pixels[i][j] = b;
					}
				}
				byte lbl = brLabels.ReadByte(); // получаем маркеры
				DigitImage dImage = new DigitImage(28, 28, pixels, lbl);
				result[di] = dImage;
			} // по каждому изображению
			ifsPixels.Close(); brImages.Close();
			ifsLabels.Close(); brLabels.Close();
			return result;
		}

		public static int ReverseBytes(int v)
		{
			byte[] intAsBytes = BitConverter.GetBytes(v);
			Array.Reverse(intAsBytes);
			return BitConverter.ToInt32(intAsBytes, 0);
		}

		public static double[] GetPixelValues(DigitImage dImage)
		{
			double[] s = new double[dImage.height * dImage.width];
			int count = 0;
			for (int i = 0; i < dImage.height; ++i)
			{
				for (int j = 0; j < dImage.width; ++j)
				{
					s[count] = Math.Round(((double)dImage.pixels[i][j] / 255), 2);
					++count;
				}
			}
			return s;
		}

		public static Bitmap MakeBitmap(DigitImage dImage)
		{
			int width = dImage.width;
			int height = dImage.height;
			Bitmap result = new Bitmap(width, height);
			Graphics gr = Graphics.FromImage(result);
			for (int i = 0; i < dImage.height; ++i)
			{
				for (int j = 0; j < dImage.width; ++j)
				{
					int pixelColor = 255 - dImage.pixels[i][j]; // Черные цифры
					Color c = Color.FromArgb(pixelColor, pixelColor, pixelColor);
					SolidBrush sb = new SolidBrush(c);
					gr.FillRectangle(sb, j, i, 10, 10);
				}
			}
			return result;
		}
	}
}
