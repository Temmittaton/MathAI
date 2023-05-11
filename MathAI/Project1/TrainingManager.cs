using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1 {
    internal class TrainingManager {
        public NeuralNetwork[] neuralNetworks;

        public TrainingManager () {

        }

        public void TrainingInit (int batchSize, int inputNodes, int outputNodes, int midLayers, int midLayersNodes) {
            neuralNetworks = new NeuralNetwork[batchSize];
            for (int i = 0; i < batchSize; i++) {
                neuralNetworks[i] = new NeuralNetwork(inputNodes, outputNodes, midLayers, midLayersNodes);
            }
        }
    }
}
