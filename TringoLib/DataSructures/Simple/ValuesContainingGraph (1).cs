using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;

namespace TringoModel.DataSructures.Simple
{
    public class ValuesContainingGraph : IGraph
    {
        public ValuesContainingGraph() { }

        public ValuesContainingGraph(IGraphInfo graphInfo, double[] samples)
        {
            this.graphInfo = graphInfo;
            this.samples = samples;
        }

        public double this[double time]
        {
            get
            {
                double hypotheticalIndex = time * graphInfo.SamplingFrequency;

                int realIndex = (int)hypotheticalIndex;
                double difference = hypotheticalIndex % 1;

                if (realIndex == samples.Length - 1 && time <= Length) //correct index but it would cause exception due to "samples[realIndex + 1]"
                    return samples[realIndex];

                try
                {
                    return samples[realIndex] * (1 - difference) + samples[realIndex + 1] * difference;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new TimeOfRangeException();
                }
            }
        }
        public double Length { get; protected set; }

        protected double[] samples;
        protected IGraphInfo graphInfo;
    }

    public class TimeOfRangeException : Exception { }
}
