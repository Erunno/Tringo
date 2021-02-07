using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoLib.DataProcessing.Arithmetics;
using TringoModel.DataProcessing.Normalization;
using TringoModel.DataSructures;

namespace DataProcessing
{
    public class DiffGraphInterpreter
    {
        private readonly double samplingFreq;

        public DiffGraphInterpreter(double numOfSamples)
        {
            this.samplingFreq = numOfSamples; //graph will be normalised to 1 so numOfSamples is equal to samplingFreq
        }


        public DiffGraphStatsNormalised GetStatsOf(IGraph diffGraph)
        {
            var result = new DiffGraphStatsNormalised();
            var normalisedGraph = new NormalizedGraph(diffGraph, newLength: 1);

            result.SumUnderGraph = normalisedGraph.GetAbsoluteArea(samplingFreq);
            result.RootedSqueredGraphSum = Math.Sqrt(
                new TransformedGraph(normalisedGraph, x => x * x).GetAbsoluteArea(samplingFreq)
                );

            return result;
        }
    }

    public class DiffGraphStatsNormalised
    {
        public double SumUnderGraph { get; set; }
        public double LogSum => Math.Log10(SumUnderGraph);
        public double LinearDiffNum => 1 / LogSum;

        public double RootedSqueredGraphSum { get; set; }
        public double LogSqueredGraphSum => Math.Log10(RootedSqueredGraphSum);
        public double SqueredDiffNum => 1 / LogSqueredGraphSum;
    }
}