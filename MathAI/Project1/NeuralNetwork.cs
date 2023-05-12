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

        public float[] GetOutputs (float[] inputs) {
            layers[0].nodes = inputs;

            for (int i = 1; i < layers.Length; i++) {
                for (int j = 0; j < layers[i].nodes.Length; j++) {
                    for (int k = 0; k < layers[i - 1].nodes.Length; k++) {
                        layers[i].nodes[j] += layers[i - 1].nodes[k] * layers[i].weights[k * layers[i].nodes.Length + j];
                    }
                    layers[i].nodes[j] += layers[i].biases[j];
                }
            }

            return layers[^1].nodes;
        }

        public void Mutate () {

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
