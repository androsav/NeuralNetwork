using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkLibrary
{
	[Serializable]
	public class Layer
	{
		public Neuron[] Neurons { get; }
		public int NeuronCount { get { return Neurons.Length; } }
		public NeuronType Type { get; }

		public Layer(Neuron[] neurons, NeuronType type)
		{
			Neurons = new Neuron[neurons.Length];
			for (int i = 0; i< Neurons.Length; i++)
			{
				Neuron n = new Neuron(neurons[i]);
				Neurons[i] = n;
			}

			Type = type;
		}

		//метод получения состояний нейронов в слое
		public double[] GetStates()
		{
			var result = new double[NeuronCount];
			for (int i = 0; i< NeuronCount; i++)
			{
				result[i] = Neurons[i].State;
			}
			return result;
		}

		public override string ToString()
		{
			return Type.ToString();
		}
	}
}
