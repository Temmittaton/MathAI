using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1 {
    internal class AIManager {
        public static readonly Random random = new Random();
        public TrainingManager trainingManager;
        private readonly int batchSize, inputNodes, outputNodes, midLayers, midLayersNodes;
        public void Init () {
            trainingManager = new TrainingManager ();
            trainingManager.TrainingInit (batchSize, inputNodes, outputNodes, midLayers, midLayersNodes);
        }

        public void Update () {

        }

        public void Save () {

        }

        public void Load () {

        }
    }
}
