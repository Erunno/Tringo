using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;
using TringoModel.DataSructures.Simple;
using TringoModel.DataProcessing.Normalization;

namespace TringoModel.DataProcessing.Mean
{

    public class MeanExperiment : IExperiment
    {
        public MeanExperiment(ISetOfExperiments setOfExperiments)
        {
            Movements = new List<IMovement>();

            CreateMeanMovements(setOfExperiments);

            Name = "MeanExperiment of:";
            foreach (var exp in setOfExperiments.Experiments)
                Name += $" <{exp.Name}> ";
        }
       
        public string Name { get; }


        private void CreateMeanMovements(ISetOfExperiments setOfExperiments)
        {
            int numberOfMovements = GetNumOfMovements(setOfExperiments);

            for (int i = 0; i < numberOfMovements; i++)
                Movements.Add(new MeanMovement(AccumulateMovementsFrom(indexOfMovement: i, setOfExperiments)));
        }


        private int GetNumOfMovements(ISetOfExperiments setOfExperiments)
            => setOfExperiments.Experiments.Min((setOfMovement) => setOfMovement.Movements.Count);

        private ISetOfMovements AccumulateMovementsFrom(int indexOfMovement, ISetOfExperiments setOfExperiments)
        {
            List<IMovement> result = new List<IMovement>();

            foreach (var experiment in setOfExperiments.Experiments)
                result.Add(experiment.Movements[indexOfMovement]);

            var setOfMovements = new SimpleSetOfMovements(result);
            return new NormalizedSetOfMovements(setOfMovements, GetMeanLength(result));
        }

        private double GetMeanLength(List<IMovement> movements)
            => (from mov in movements
                select mov.Sensors[0].EMG.Length).Sum() 
                    / movements.Count;


        public IList<IMovement> Movements { get; }
    }


}
