using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures.DataCache
{
    class CachedGraph : IGraph
    {
        /// <summary>
        /// Constructor of CachedGraph
        /// </summary>
        /// <param name="graph">Graph to be cached</param>
        /// <param name="SamplingFrequency">Means number of samples in one second</param>
        public CachedGraph(IGraph graph, double SamplingFrequency)
        {
            samplingFrequency = SamplingFrequency;

            int numberOfSamples = (int)(graph.Length * samplingFrequency);
            samples = new double[numberOfSamples];

            Length = graph.Length;

            CreateSamples(graph);
        }

        private void CreateSamples(IGraph graph)
        {
            double period = 1.0 / samplingFrequency;

            for (int i = 0; i < samples.Length; i++)
                samples[i] = graph[period * i];
        }

        private double[] samples { get; }
        private double samplingFrequency { get; }

        public double this[double time]
        {
            get
            {
                double hypotheticalIndex = time * samplingFrequency;

                int realIndex = (int)hypotheticalIndex;
                double difference = hypotheticalIndex % 1;

                try
                {
                    return samples[realIndex] * (1 - difference) + samples[realIndex + 1] * difference;
                }
                catch(IndexOutOfRangeException)
                {
                    throw new TimeOfRangeException();
                }
            }
        }

        public double Length { get; }
    }

    public class TimeOfRangeException : Exception { }
}
