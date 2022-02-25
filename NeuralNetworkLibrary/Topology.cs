using System;
using System.Collections.Generic;

namespace NeuralNetworkLibrary
{
	[Serializable]
	public class Topology
	{
		public int InputCount { get; }//кол-во входов в сеть (входных нейронов в слое)
		public int[] HiddenCount { get; }//кол-во нейронов в скрытых слоях (слое)
		public int OutputCount { get; }//кол-во выходов из сети
		public double LearningRate { get; }//скорость обучения

		public Topology(int inputCount, int[] hiddenCount, int outputCount, double learningRate)//hiddenCount - массив количества нейронов для каждого скрытого слоя
		{
			InputCount = inputCount;
			HiddenCount = hiddenCount;
			OutputCount = outputCount;
			LearningRate = learningRate;
		}
	}
}
