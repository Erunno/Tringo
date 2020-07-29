using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;

namespace TringoLib.DataProcessing.Arithmetics
{
    public class TransformedGraph : IGraph
    {
        private readonly IGraph baseGraph;
        private readonly Func<double, double> transformFunc;

        public TransformedGraph(IGraph baseGraph, Func<double,double> transformFunc)
        {
            this.baseGraph = baseGraph;
            this.transformFunc = transformFunc;
        }

        public double this[double time] => transformFunc(baseGraph[time]);

        public double Length => baseGraph.Length;
    }
}
