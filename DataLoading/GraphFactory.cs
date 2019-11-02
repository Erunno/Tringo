using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;

namespace DataLoading
{
    class GraphFactory
    {
        public GraphFactory(IGraphInfo graphInfo)
        {
            this.graphInfo = graphInfo;
            samples = new double[graphInfo.SamplesCount];
        }

        IGraphInfo graphInfo;
        double[] samples;
        bool valuesWasReturned = false;
        int currIndex = 0;

        public void RegisterNextValue(double value)
        {
            samples[currIndex++] = value;
        }

        public RawGraph GetRawGraph()
        {
            if (currIndex != samples.Length)
                throw new MissingValuesExceptions();

            double[] valuesToReturn = GetValues();

            return new RawGraph(graphInfo, samples);
        }

        private double[] GetValues()
        {
            if(!valuesWasReturned)
            {
                valuesWasReturned = true;
                return samples;
            }

            return GetCopyOfValues();
        }

        private double[] GetCopyOfValues()
        {
            double[] newArray = new double[samples.Length];
            samples.CopyTo(newArray, index: 0);

            return newArray;
        }

    }

    class MissingValuesExceptions : Exception { }
}
