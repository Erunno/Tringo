using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;
using TringoModel.DataProcessing.Normalization;
using TringoModel.DataSructures.Universal;
using TringoModel.DataProcessing.Arithmetics;

namespace DataProcessing
{
    public class VarianceCalculator
    {
        public VarianceCalculator(double samplingFrequency)
        {
            this.samplingFrequency = samplingFrequency;
        }

        private double samplingFrequency { get; }
        private double graphLength;

        public IVarinceData CompudeVariance(IMovement meanMovement, ISetOfMovements setOfMovements)
        {
            InitialiseData(meanMovement, setOfMovements);
            
            ComputeDeviations();
            ComputeNormalizedDeviations();

            ComputeVar();
            ComputeNormalizedVar();

            return DealockDataAndReturnThem();
        }

        VarianceData varianceData;

        private void InitialiseData(IMovement meanMovement, ISetOfMovements setOfMovements)
        {
            varianceData = new VarianceData();
            
            varianceData.MeanMovement = meanMovement;
            
            graphLength = meanMovement.Sensors.First().EMG.Length;  //all of them has to have same length
            varianceData.NormalizedSetOfMovements = new NormalizedSetOfMovements(setOfMovements, graphLength);

            int numOfMovements = setOfMovements.Movements.Count;
            varianceData.Deviations = new double[numOfMovements];
            varianceData.NormalizedDeviations = new double[numOfMovements];
        }

        private void ComputeDeviations()
        {
            for (int i = 0; i < varianceData.NormalizedSetOfMovements.Movements.Count; i++)
                varianceData.Deviations[i] += GetDeviation(varianceData.NormalizedSetOfMovements.Movements[i]);
        }

        private double GetDeviation(IMovement movement)
        {
            IMovement differenceMov = new BiUniversalMovement(varianceData.MeanMovement, movement, (g1, g2) => new DifferenceGraph(g1, g2));
            return differenceMov.GetSumOfAreasOfSubgraphs(samplingFrequency);
        }


        private void ComputeNormalizedDeviations()
        {
            for (int i = 0; i < varianceData.Deviations.Length; i++)
                varianceData.NormalizedDeviations[i] = varianceData.Deviations[i] / graphLength;

        }
        private void ComputeVar() => varianceData.Var = ComputeMeanOfSquares(varianceData.Deviations);

        private void ComputeNormalizedVar() => varianceData.NormalizedVar = ComputeMeanOfSquares(varianceData.NormalizedDeviations);

        private double ComputeMeanOfSquares(double[] values)
        {
            double sum = 0;

            foreach (var val in values)
                sum += val * val;

            return sum / values.Length;
        }

        private IVarinceData DealockDataAndReturnThem()
        {
            var data = varianceData;
            varianceData = null; //preventing memory leaks
            return data;
        }
    }

    public interface IVarinceData
    {
        IMovement MeanMovement { get; }
        ISetOfMovements NormalizedSetOfMovements { get; }

        /// <summary>
        /// Mean value of squares of deviations
        /// </summary>
        double Var { get; }
        double[] Deviations { get; }

        /// <summary>
        /// Mean value of squares of normalized deviations
        /// </summary>
        double NormalizedVar { get; }
        /// <summary>
        /// Deviation per second
        /// </summary>
        double[] NormalizedDeviations { get; } 
    }

    class VarianceData : IVarinceData
    {
        public IMovement MeanMovement { get; set; }
        public ISetOfMovements NormalizedSetOfMovements { get; set; }

        public double Var { get; set; }
        public double[] Deviations { get; set; }

        public double NormalizedVar { get; set; }
        public double[] NormalizedDeviations { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Variation: {Var}");
            
            sb.AppendLine("All deviations:");
            sb.AppendLine(Deviations.ToNiceString());

            sb.AppendLine();

            sb.AppendLine($"Normalized variation: {NormalizedVar}");
            
            sb.AppendLine("All normalized deviations:");
            sb.AppendLine(NormalizedDeviations.ToNiceString());

            return sb.ToString();
        }
    }

}
