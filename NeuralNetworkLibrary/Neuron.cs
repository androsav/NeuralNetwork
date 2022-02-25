using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkLibrary
{
	[Serializable]
	public class Neuron
    {
		//весовые коэффициенты, на которые будут умножаться входящие данные
		public double[] Weights { get; set; }

		//Хранит в себе один элемент - цвет пиксела, если нейрон входной и набор состояний нейронов предыдущего слоя, если это нейрон скрытого или выходного слоя
		public double[] Input { get; set; }

		//состояние нейрона от 0 до 1
		public double State { get; set; }

		//величина, на которую будут уменьшены веса, идущие к нейрону
		public double Delta { get; set; }

		public NeuronType NeuronType { get; }

			//конструктор нейрона, принимающий на вход кол-во входов inputCount и тип нейрона
		public Neuron(int inputCount, NeuronType type)
		{
			Weights = new double[inputCount];
			Input = new double[inputCount];
			State = 0;
			Delta = 0;
			NeuronType = type;

			SetRandomWeights();
		}

		public Neuron(Neuron neuron)
		{

			double[] weights = neuron.Weights; Weights = weights;
			double[] input = neuron.Input; Input = input;
			double state = neuron.State; State = state;
			double delta = neuron.Delta; Delta = delta;

			NeuronType = neuron.NeuronType;

			SetRandomWeights();
		}

		//Функция прямого распределения. Вызывается для каждого нейрона в слое
		public void FeedForward(double[] inputs)//inputs - массив цветов пикселей (1 элемент - единица) или массив состояний нейрона (каждый элемент - состояние нейрона предыдущего слоя)
		{
			for (int i = 0; i < Input.Length; i++)
			{
				Input[i] = inputs[i];
			}

			double sum = 0;
			for (int i = 0; i < Input.Length; i++)
			{
				sum += Input[i] * Weights[i];
			}

			//здесь определяется состояние нейрона в зависимости от его типа ЭТО ИДЕТ В INPUT СЛЕДУЮЩИМ НЕЙРОНАМ
			if (NeuronType != NeuronType.Input)
			{
				State = Sigmoid(sum);
			}
			else
			{
				State = sum;
			}
		}

		//Обратное распространение  
		public void Backpropagation(double expected, double data, double learningRate)//data - сумма произведений весов нейронов предыдущего слоя на их дельту
		{
			if (NeuronType == NeuronType.Output)
			{
				double error = State - expected;//здесь вычисляется расхождение текущего результата с ожидаемым
				WeightsCorrection(error, learningRate);
			}
			//эта часть кода будет выполняться в цикле (метод BackPropagation будет вызываться для каждого нейрона в скрытом слое)
			else
			{
				double error = data;
				WeightsCorrection(error, learningRate);
			}
		}

		private void WeightsCorrection(double error, double learningRate)
		{
			double sum = 0;
			for (int i = 0; i < Input.Length; i++)
			{
				sum += Input[i] * Weights[i];
			}
			Delta = error * SigmoidDx(sum);

			for (int i = 0; i < Input.Length; i++)
			{
				double buf = Weights[i];
				Weights[i] = buf - Input[i] * Delta * learningRate;
			}
		}

		//для каждого входа в нейрон присваивается весовой коэфицент
		public void SetRandomWeights()
		{
			if (NeuronType == NeuronType.Input)
			{
				for (int i = 0; i < Weights.Length; i++)
				{
					Weights[i] = 1;
				}
			}
			else
			{
				for (int i = 0; i < Weights.Length; i++)
				{
					Random rnd = new Random(DateTime.Now.Millisecond*i+i);
					Weights[i] = rnd.NextDouble() - rnd.NextDouble();
				}
			}

		}

		private double Sigmoid(double x)
		{
			var result = 1.0 / (1.0 + Math.Pow(Math.E, -x));
			return result;
		}

		private double SigmoidDx(double x)
		{
			var sigmoid = Sigmoid(x);
			var result = sigmoid * (1 - sigmoid);
			return result;
		}

		public override string ToString()
		{
			return NeuronType.ToString();
		}
	}
}
