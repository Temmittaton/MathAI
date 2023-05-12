using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1 {
    internal class TrainingManager {
        private NeuralNetwork[] neuralNetworks;
        private float[] costs;
        private int inputSize, batchSize;
        private int testNbr = 8;

        public void TrainingInit (int batchSize, int inputNodes, int outputNodes, int midLayers, int midLayersNodes) {
            neuralNetworks = new NeuralNetwork[batchSize];
            costs = new float[batchSize];
            for (int i = 0; i < batchSize; i++) {
                neuralNetworks[i] = new NeuralNetwork(inputNodes, outputNodes, midLayers, midLayersNodes);
            }
            inputSize = inputNodes;
            this.batchSize = batchSize;
        }

        private float[] GetFunction () {
            float[] _f = new float[inputSize/2];
            for (int i = 0; i < inputSize; i++) {
                _f[i] = AIManager.random.NextFloat (-1000f, 1000f);
            }
            return _f;
        }

        private Vector2[] GetPoints (float[] function) {
            Vector2[] points = new Vector2[batchSize];
            for (int i = 0; i < batchSize; i++) {
                float _x = AIManager.random.NextFloat (-512f, 512f);
                float _y = function[0];
                for (int j = 1; j < function.Length; j++) {
                    _y += function[j] * MathF.Pow (_x, j);
                }

                points[i] = new Vector2 (_x, _y);
            }

            return points;
        }

        public float GetCost (float[] function, float[] result) {
            float cost = MathF.Pow (function[0] - result[0], 2);
            for (int i = 1; i < function.Length; i++) {
                cost += MathF.Pow (function[i] - result[i], 2);
            }

            return cost;
        }

        public void Train () {
            // Get function, points and inputs
            float[] function = GetFunction ();
            Vector2[] points = GetPoints (function);

            float[] inputs = new float[inputSize];
            for (int i = 0; i < inputSize; i++) {
                inputs[i] = points[i].X;
                i++;
                inputs[i] = points[i].Y;
            }

            // Get results and cost
            float[,] results = new float[batchSize, inputSize];
            for (int i = 0; i < batchSize; i++) {
                float[] _res = neuralNetworks[i].GetOutputs (inputs);
                costs[i] += GetCost (function, _res);

                for (int j = 0; j < inputSize; j++) {
                    results[i, j] = _res[j];
                }
            }
        }

        public void TrainingUpdate () {
            for (int i = 0; i < testNbr; i++) {
                Train ();
            }


        }
    }
}
