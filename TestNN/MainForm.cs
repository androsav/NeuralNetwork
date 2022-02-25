using System;
using NeuralNetworkLibrary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestNN
{
	public partial class MainForm : Form
	{
		public static AskForLabelForm askForLabelForm;
		public static int lab;

		Bitmap bitmap = new Bitmap(28, 28); //создание холста или поля для рисования
		Color[,] colors = new Color[28,28];
		double[] mas = new double[100];
		int x1 = 0, y1 = 0;

		private string pixelFile = @"train-images.idx3-ubyte";
		private string labelFile = @"train-labels.idx1-ubyte";
		private DigitImage[] trainImages = null;

		private int nextIndex = 0;

		NeuralNetwork neuralNetwork;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			ImageConversion.FilldrawingBox(bitmap);
			drawingBox.Image = bitmap;
		}

		private void getNeuralNetworkButton_Click(object sender, EventArgs e)
		{
			saveButton.Enabled = true;
			learnButton.Enabled = true;
			loadNeuronNetworkButton.Enabled = true;
			enterButton.Enabled = true;
			clearButton.Enabled = true;
			int[] mas = { 16 };
			GetNeuralNetwork(100, mas, 10, 0.25);
			getNeuralNetworkButton.Enabled = false;
		}

		private void GetNeuralNetwork(int inputCount, int[] hiddenCount, int outputCount, double learningRate)
		{
			Topology topology = new Topology(inputCount, hiddenCount, outputCount, learningRate);
			neuralNetwork = new NeuralNetwork(topology);
		}

		private void Predict(double[] pixelVals)
		{
			neuralNetwork.Predict(ImageConversion.GetBinaryStates(pixelVals));
		}

		private void learnButton_Click(object sender, EventArgs e)
		{
			learnButton.Enabled = false;
			for (int j = 0; j < 3; j++)
			{
				for (int i = 0; i < 60000; i++)
				{
					int index = GetMaxNeuronIndex();
					//сравние метки с индексом нейрона с наибольшим state
					if (trainImages[i].label != index)
						Learn(trainImages[i]);
				}
			}

			//SaveNeuronNetwork();
		}

		private void Learn(DigitImage trainImage)
		{
			Bitmap image = ImageConversion.RemoveWhitePixels(TrainingSample.MakeBitmap(trainImage));
			int[,] clipArr = ImageConversion.CutImageToArray(image, new Point(28, 28));
			int[,] arr = ImageConversion.LeadArray(clipArr, new int[10, 10]);

			double[] pixelVals = new double[arr.Length];
			int count = 0;
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					pixelVals[count] = arr[i, j];
					count++;
				}
			}

			Predict(pixelVals);
			double[] expectedStates = GetExpectedStates(trainImage);
			neuralNetwork.Learn(expectedStates, neuralNetwork.Topology.LearningRate);
		}

		private void Learn(double[] pixelVals, int label)
		{
			Predict(pixelVals);
			double[] expectedStates = GetExpectedStates(label);
			neuralNetwork.Learn(expectedStates, 1);
		}

		private void SaveNeuronNetwork()
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			using (FileStream fileStream = new FileStream("neuralNetwork.txt", FileMode.OpenOrCreate))
			{
				binaryFormatter.Serialize(fileStream, neuralNetwork);
			}
		}

		private int GetMaxNeuronIndex()
		{
			double[] mas = neuralNetwork.Layers.Last().GetStates();
			double buf = mas[0];
			int index = 0;
			for (int k = 1; k < mas.Length; k++)
			{
				if (buf < mas[k])
				{
					buf = mas[k];
					index = k;
				}
			}
			return index;
		}



		private double[] GetExpectedStates(DigitImage trainImage)
		{
			//double[] mas = new double[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
			double[] expectedStates = new double[neuralNetwork.Layers.Last().NeuronCount];
			for (int j = 0; j < expectedStates.Count(); j++)
			{
				if (trainImage.label == j)
				{
					expectedStates[j] = 1;
				}
				else
				{
					expectedStates[j] = 0;
				}
			}

			return expectedStates;
		}

		private double[] GetExpectedStates(int label)
		{
			double[] expectedStates = new double[neuralNetwork.Layers.Last().NeuronCount];
			for (int j = 0; j < expectedStates.Count(); j++)
			{
				if (label == j)
				{
					expectedStates[j] = 1;
				}
				else
				{
					expectedStates[j] = 0;
				}
			}
			return expectedStates;
		}


		private void clearButton_Click(object sender, EventArgs e)
		{
			bitmap = new Bitmap(28, 28);
			ImageConversion.FilldrawingBox(bitmap);
			drawingBox.Image = bitmap;
		}

		private void enterButton_Click(object sender, EventArgs e)
		{
			statesListBox.Items.Clear();

			int[,] clipArr = ImageConversion.CutImageToArray((Bitmap)drawingBox.Image, new Point(drawingBox.Width, drawingBox.Height));
			if (clipArr == null) return;
			int[, ]arr = ImageConversion.LeadArray(clipArr, new int[10, 10]);
			croppedImageBox.Image = ImageConversion.GetBitmapFromArr(clipArr);
			compressedImageBox.Image = ImageConversion.GetBitmapFromArr(arr);

			int count = 0;

			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					mas[count] = arr[i, j];
					count++;
				}
			}
			Predict(mas);
			foreach (var neuron in neuralNetwork.Layers.Last().Neurons)
			{
				statesListBox.Items.Add(neuron.State);
			}

			DialogResult askResult = MessageBox.Show($"Результат распознавания - {GetMaxNeuronIndex()}?", "", MessageBoxButtons.YesNo);

			if (askResult == DialogResult.No)
			{
				askForLabelForm = new AskForLabelForm();
				askForLabelForm.Show();
				while (true)
				{
					if (AskForLabelForm.label == lab)
						break;
				}
				statesListBox.Items.Add(lab);
				Learn(mas, lab);
				Predict(mas);
			}
		}

		private void drawingBox_MouseMove(object sender, MouseEventArgs e)
		{
			Pen pen1 = new Pen(Color.Black,2);
			Pen pen2 = new Pen(Color.White, 4);
			Graphics g = Graphics.FromImage(bitmap);//привязка к холсту
			g.SmoothingMode = SmoothingMode.HighQuality;

			if (e.Button == MouseButtons.Left)
			{
				g.DrawLine(pen1, x1 / 10, y1 / 10, e.X / 10, e.Y / 10);//поскольку размер pictureBox1 в 10 раз больше bitmap, уменьшаем значения координат в 10 раз
				drawingBox.Image = bitmap;//мы не можем напрямую рисовать в pictureBox1. мы используем промежуточную картинку, изменив которую, помещаем в pictureBox1
			}
			if (e.Button == MouseButtons.Right)
			{
				g.DrawLine(pen2, x1 / 10, y1 / 10, e.X / 10, e.Y / 10);//поскольку размер pictureBox1 в 10 раз больше bitmap, уменьшаем значения координат в 10 раз
				drawingBox.Image = bitmap;//мы не можем напрямую рисовать в pictureBox1. мы используем промежуточную картинку, изменив которую, помещаем в pictureBox1
			}
			x1 = e.X;
			y1 = e.Y;
		}

		private void loadNeuronNetworkButton_Click(object sender, EventArgs e)
		{
			learnButton.Enabled = false;
			loadNeuronNetworkButton.Enabled = false;
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			using (FileStream fileStream = new FileStream("neuralNetwork.txt", FileMode.OpenOrCreate))
			{
				neuralNetwork = (NeuralNetwork)binaryFormatter.Deserialize(fileStream);
			}
		}

		/// <summary>
		/// Отсюда начинается описание всего, что связано с вводом обучающей выборки
		/// </summary>

		private void GetMNIST_Click(object sender, EventArgs e)
		{
			nextImage.Enabled = true;
			this.trainImages = TrainingSample.LoadData(pixelFile, labelFile);
			statesListBox.Items.Add("MNIST images loaded into memory");
			getMNISTButton.Enabled = false;
		}

		private void nextImage_Click(object sender, EventArgs e)
		{
			// Отображаем следующее изображение
			DigitImage currImage = trainImages[nextIndex];
			statesListBox.Items.Clear();

			Bitmap Bitmap = ImageConversion.RemoveWhitePixels(TrainingSample.MakeBitmap(currImage));
			int[,] clipArr = ImageConversion.CutImageToArray(Bitmap, new Point(28, 28));
			int[,] arr = ImageConversion.LeadArray(clipArr, new int[10, 10]);
			croppedImageBox.Image = ImageConversion.GetBitmapFromArr(clipArr);
			compressedImageBox.Image = ImageConversion.GetBitmapFromArr(arr);

			drawingBox.Image = Bitmap;
			double[] pixelVals = new double[arr.Length];
			int count = 0;
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					pixelVals[count] = arr[i, j];
					count++;
				}
			}
			Predict(pixelVals);

			foreach (var neuron in neuralNetwork.Layers.Last().Neurons)
			{
				statesListBox.Items.Add(neuron.State);
			}
			DialogResult askResult = MessageBox.Show($"Результат распознавания - {GetMaxNeuronIndex()}.");
			nextIndex++;
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			SaveNeuronNetwork();
		}
	}
}