using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkLibrary
{
	[Serializable]
	public class NeuralNetwork
	{
		public Topology Topology { get; }
		public Layer[] Layers { get; }

		private int count = 0;//вспомогательная переменная-счетчик для слоев

		public NeuralNetwork(Topology topology)
		{
			Topology = topology;

			int layersCount = 2;//переменная layersCount создается с заранее определенным занчением 2 - входный и выходный слои
			//здесь в layersCount добавляется 1 за каждый скрытый слой
			for (int i = 0; i< Topology.HiddenCount.Length; i++)
			{
				layersCount += 1;
			}

			Layers = new Layer[layersCount];
			CreateInputLayer(Topology.InputCount);
			for (int i = 0; i < Topology.HiddenCount.Length; i++)
			{
				CreateHiddenLayer(Topology.HiddenCount[i]);
			}
			CreateOutputLayer(Topology.OutputCount);
		}


		//Функция прямого распределдения. Вызывается для всех слоев сети, для каждого нейрона в слое
		public double[] Predict(double[] inputData)
		{
			SendSignalsToInputLayer(inputData);
			FeedForwardAllOtherLayers();

			return Layers.Last().GetStates();
		}

		//Обучение сети
		public void Learn(double[] expected, double learningRate)//expected - массив ожидаемых значений от выходного слоя сети. 10 значений: 1 единица и 9 нулей
		{
			//цикл для каждого слоя, начиная с последнего.
			for (int i = Layers.Length-1; i > 0; i--)
			{
				//цикл для каждого нейрона в слое
				for (int j = 0; j < Layers[i].Neurons.Length; j++)
				{
					//если нейрон имеет тип выходной
					if (Layers[i].Type == NeuronType.Output)
						Layers[i].Neurons[j].Backpropagation(expected[j], 0, learningRate);
					else
					{
						//здесь высчитывается сумма весов нейронов i+1 слоя, умноженных на дельту этого нейрона.
						//здесь j - индекс нейрона в текущем слое и индекс весов, от которых будет распространяться ошибка. 
						//индекс нейрона и весов, в него входящих в данном случае совпадает
						double error = 0;
						foreach (Neuron neuron in Layers[i + 1].Neurons)
						{
							error += neuron.Weights[j] * neuron.Delta;
						}
						//после чего для нейрона запускается обратное распространение ошибки
						Layers[i].Neurons[j].Backpropagation(0, error, learningRate);
					}
				}
			}
		}

		private void FeedForwardAllOtherLayers()
		{
			for (int i = 1; i < Layers.Length; i++)
			{
				double[] previousLayerSingals = Layers[i - 1].GetStates();

				for (int j = 0; j < Layers[i].Neurons.Length; j++)
				{
					Layers[i].Neurons[j].FeedForward(previousLayerSingals);
				}
			}
		}

		private void SendSignalsToInputLayer(double[] inputSignals)
		{
			var signals = new double[1];
			for (int i = 0; i < inputSignals.Length; i++)
			{
				signals[0] = inputSignals[i];
				Layers[0].Neurons[i].FeedForward(signals);
			}
		}

		private void CreateInputLayer(int inputCount)
		{
			var inputNeurons = new Neuron[inputCount];
			for (int i = 0; i < inputCount; i++)
			{
				var neuron = new Neuron(1, NeuronType.Input);
				inputNeurons[i] = neuron;
			}
			var inputLayer = new Layer(inputNeurons, NeuronType.Input);
			Layers[count] = inputLayer;
			count++;
		}

		private void CreateHiddenLayer(int hiddenCount)
		{
			var hiddenNeurons = new Neuron[hiddenCount];
			var lastLayer = Layers[count-1];
			for (int i = 0; i < hiddenCount; i++)
			{
				var neuron = new Neuron(lastLayer.NeuronCount, NeuronType.Hidden);//входов в нейроне столько, сколько нейронов в предыдущем слое
				hiddenNeurons[i] = neuron;
			}
			var hiddenLayer = new Layer(hiddenNeurons, NeuronType.Hidden);
			Layers[count] = hiddenLayer;
			count++;
		}

		private void CreateOutputLayer(int outputCount)
		{
			var outputNeurons = new Neuron[outputCount];
			var lastLayer = Layers[count - 1];
			for (int i = 0; i < outputCount; i++)
			{
				var neuron = new Neuron(lastLayer.NeuronCount, NeuronType.Output);
				outputNeurons[i] = neuron;
			}
			var outputLayer = new Layer(outputNeurons, NeuronType.Output);
			Layers[count] = outputLayer;
		}

	}
}
