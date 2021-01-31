using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures.Simple;

namespace TringoModel.DataSructures.DataCache
{
    public class CachedGraph : ValuesContainingGraph
    {
        /// <summary>
        /// Constructor of CachedGraph
        /// </summary>
        /// <param name="baseGraph">Graph to be cached</param>
        /// <param name="SamplingFrequency">Means number of samples in one second</param>
        public CachedGraph(IGraph baseGraph, double samplingFrequency)
        {
            CreateGraphInfo(baseGraph, samplingFrequency);

            samples = new double[graphInfo.SamplesCount]; //one extra as protection againts indexOutOfRange in indexer

            CreateSamples(baseGraph);
        }

        public CachedGraph(double[] samples, double samplingFrequency)
        {
            graphInfo = new MutableGraphInfo()
            {
                Name = "",
                SamplesCount = samples.Length,
                SamplingFrequency = samplingFrequency
            };

            this.samples = samples;

            MaxValue = samples.Max();
            MinValue = samples.Min();
        }

        private void CreateGraphInfo(IGraph baseGraph, double samplingFrequency)
        {
            MutableGraphInfo newGraphInfo = new MutableGraphInfo();

            newGraphInfo.Name = ""; //dont need it
            newGraphInfo.SamplesCount = (int)(baseGraph.Length * samplingFrequency);
            newGraphInfo.SamplingFrequency = samplingFrequency;

            graphInfo = newGraphInfo;
        }

        private void CreateSamples(IGraph graph)
        {
            double period = 1.0 / graphInfo.SamplingFrequency;

            for (int i = 0; i < samples.Length - 1; i++)
            {
                samples[i] = graph[period * i];
                TryUpdateMinMax(samples[i]);
            }
        }

        private void TryUpdateMinMax(double value)
        {
            if (value > MaxValue)
                MaxValue = value;

            if (value < MinValue)
                MinValue = value;
        }

        public double MaxValue { get; private set; } = double.MinValue;
        public double MinValue { get; private set; } = double.MaxValue;
    }

    
}
