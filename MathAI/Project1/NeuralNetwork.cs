using SharpDX;
using System;

namespace Project1 {
    internal class NeuralNetwork {
        public Layer[] layers;

        public NeuralNetwork (int inputNodes, int outputNodes, int midLayers, int midLayersNodes) {
            layers = new Layer[midLayers + 2];
            layers[0] = new Layer (inputNodes, 0);
            layers[midLayers + 1] = new Layer (outputNodes, outputNodes * midLayersNodes);
            for (int i = 1; i < layers.Length -1; i++) {
                layers[i] = new Layer (midLayersNodes, layers[i-1].nodes.Length * midLayersNodes);
            }
        }
    }

    internal class Layer {
        public float[] nodes, biases, weights;
        public Layer(int nodesNbr, int weightsNbr) {
            nodes = new float[nodesNbr];
            biases = new float[nodesNbr];
            weights = new float[weightsNbr];

            for (int i = 0; i < nodesNbr; i++) {
                biases[i] = AIManager.random.NextFloat (-1f, 1f); ;
            }
            for (int i = 0; i < weightsNbr; i++) {
                weights[i] = AIManager.random.NextFloat (-1f, 1f); ;
            }
        }
    }
}
