using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;

namespace TringoModel.DataProcessing.Arithmetics
{
    public class DifferenceGraph : IGraph
    {
        public DifferenceGraph(IGraph graph, IGraph minusGraph)
        {
            if (graph.Length != graph.Length)
                throw new DifferentLengthOfGraphsException();

            this.graph = graph;
            this.minusGraph = minusGraph;
        }

        IGraph graph;
        IGraph minusGraph;

        public double Length => graph.Length;

        public double this[double time] => graph[time] - minusGraph[time];
    }

    public class AdditonGraph : IGraph
    {
        public AdditonGraph(IGraph graph, IGraph plusGraph)
        {
            if (graph.Length != graph.Length)
                throw new DifferentLengthOfGraphsException();

            this.graph = graph;
            this.plusGraph = plusGraph;
        }

        IGraph graph;
        IGraph plusGraph;

        public double Length => graph.Length;

        public double this[double time] => graph[time] + plusGraph[time];
    }


    class DifferentLengthOfGraphsException : Exception { }
}
