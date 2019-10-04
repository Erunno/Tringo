using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;

namespace TringoModel.DataProcessing.Normalization
{
    public class NormalizedGraph : IGraph
    {
        public NormalizedGraph(IGraph baseGraph, double newLength)
        {
            Length = newLength;
            this.baseGraph = baseGraph;

            timeModifier = newLength / baseGraph.Length;
        }

        private IGraph baseGraph { get; }
        private double timeModifier { get; }


        public double this[double time] => baseGraph[timeModifier * time];

        public double Length { get; }
    }
}
