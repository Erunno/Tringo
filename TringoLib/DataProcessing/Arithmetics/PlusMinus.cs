using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoLib.DataProcessing;
using TringoLib.DataProcessing.Arithmetics;
using TringoModel.DataSructures;
using TringoModel.DataSructures.DataCache;

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

        public double Length => Math.Min(graph.Length, minusGraph.Length);

        public double this[double time] => graph[time] - minusGraph[time];
    }

    public class EnvelopeDifferenceGraph : IGraph
    {
        public EnvelopeDifferenceGraph(EnvelopeGraph envelope, EnvelopeGraph minusEnvelope, double samplingPeriod)
        {
            var values = ComputeValues(envelope, minusEnvelope, samplingPeriod);
            baseGraph = new CachedGraph(values, 1.0 / samplingPeriod);
        }

        private double[] ComputeValues(EnvelopeGraph envelope, EnvelopeGraph minusEnvelope, double samplingPeriod)
        {
            var minmaxes = envelope.GetValuesOfGraph(samplingPeriod)
                .Zip(minusEnvelope.GetValuesOfGraph(samplingPeriod), (val, minusVal) => (val, minusVal));

            var result = minmaxes.Select(
                x =>
                {
                    var first = x.Item1;
                    var second = x.Item2;

                    double maxmax = Math.Max(first.Max, second.Max);
                    double minmin = Math.Min(first.Min, second.Min);

                    double intersection = first.GetIntersection(second);

                    return (maxmax - minmin) - intersection;
                });

            return result.ToArray();
        }

        private CachedGraph baseGraph;

        public double this[double time] => baseGraph[time];

        public double Length => baseGraph.Length;
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
