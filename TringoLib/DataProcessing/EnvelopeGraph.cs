using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;
using TringoModel.DataSructures.DataCache;
using TringoModel.DataSructures.Simple;

namespace TringoLib.DataProcessing
{

    public class EnvelopeGraph
    {
        private readonly IGraph baseGraph;
        private readonly double windowSize;
        private readonly double samplingPeriod;

        public struct Vertex 
        {
            public double Time { get; set; }
            public double Value { get; set; }

            public override string ToString()
                => $"{"{"} Time={Time}, Value={Value} {"}"}";
        }

        public EnvelopeGraph(IGraph baseGraph, double windowSize, double samplingPeriod)
        {
            this.baseGraph = baseGraph;
            this.windowSize = windowSize;
            this.samplingPeriod = samplingPeriod;

            Length = baseGraph.Length;

            Fill(UpperVerticies, GetMax);
            Fill(LowerVerticies,  GetMin);

            baseGraph = null; //dont need reference any more --> preventing memory leaks
        }

        private void Fill(List<Vertex> vertices, Func<double, Vertex> selector)
        {
            double start = 0;
            vertices.Add(new Vertex() { Time = 0, Value = baseGraph[0] });

            while (start + windowSize < baseGraph.Length)
            {
                var vertex = selector(start);
                vertices.Add(vertex);
                start = vertex.Time + samplingPeriod;
            }

            vertices.Add(new Vertex() { Time = baseGraph.Length, Value = baseGraph[baseGraph.Length] });
        }

        private Vertex GetMin(double start)
        {
            Vertex min = new Vertex()
            {
                Time = start,
                Value = baseGraph[start],
            };

            for (
                double time = start; 
                time < start + windowSize && time < baseGraph.Length; 
                time += samplingPeriod)
            {
                var val = baseGraph[time];

                if(val < min.Value)
                {
                    min.Value = val;
                    min.Time = time;
                }
            }

            return min;
        }

        private Vertex GetMax(double start)
        {
            Vertex max = new Vertex()
            {
                Time = start,
                Value = baseGraph[start],
            };

            for (
                double time = start;
                time < start + windowSize && time < baseGraph.Length;
                time += samplingPeriod)
            {
                var val = baseGraph[time];

                if (val > max.Value)
                {
                    max.Value = val;
                    max.Time = time;
                }
            }

            return max;
        }

        private List<Vertex> UpperVerticies { get; } = new List<Vertex>();
        private List<Vertex> LowerVerticies { get; } = new List<Vertex>();

        public double Length { get; }
        public IEnumerable<Vertex> Upper => UpperVerticies;
        public IEnumerable<Vertex> Lower => LowerVerticies;
        public IEnumerable<Vertex> LowerReverse
        {
            get
            {
                for (int i = 0; i < LowerVerticies.Count; i++)
                    yield return LowerVerticies[LowerVerticies.Count - i - 1];
            }
        }

        public IGraph GetAreaSumsGraph()
        {
            int upIndex = 0, downIndex = 0;
            int samples =(int)(baseGraph.Length / samplingPeriod);

            var dataPoints = new double[samples];

            for (int i = 0; i < dataPoints.Length; i++)
            {
                var time = i * samplingPeriod;

                if (UpperVerticies[upIndex + 1].Time < time)
                    upIndex++;
                if (LowerVerticies[downIndex + 1].Time < time)
                    downIndex++;

                var upValue   = GetValueFor(UpperVerticies[upIndex], UpperVerticies[upIndex + 1], time);
                var downValue = GetValueFor(LowerVerticies[downIndex], LowerVerticies[downIndex + 1], time);

                dataPoints[i] = upValue - downValue;
            }

            return new RawGraph(
                new MutableGraphInfo
                {
                    Name = "",
                    SamplesCount = dataPoints.Length,
                    SamplingFrequency = 1 / samplingPeriod
                },
                dataPoints);
        }

        private double GetValueFor(Vertex from, Vertex to, double time)
        {
            if (to.Time == from.Time)
                return (to.Value + from.Value) / 2;

            double valueDifference = to.Value - from.Value;
            double timeProgress = (time - from.Time) / (to.Time - from.Time);

            return valueDifference * timeProgress + from.Value;
        }

        public struct MinMaxValue
        {
            public double Max { get; set; }
            public double Min { get; set; }

            public double GetIntersection(MinMaxValue other)
            {
                MinMaxValue biggerMax, smallerMax;

                if(Max > other.Max)
                {
                    biggerMax = this;
                    smallerMax = other;
                }
                else
                {
                    biggerMax = other;
                    smallerMax = this;
                }

                if (biggerMax.Min > smallerMax.Max)
                    return 0.0;
                else if (biggerMax.Min > smallerMax.Min)
                    return smallerMax.Max - biggerMax.Min;
                else
                    return smallerMax.Max - smallerMax.Min;
            }
        }

        public IEnumerable<MinMaxValue> GetValuesOfGraph(double samplingPeriodOfValues)
        {
            var upper = GetValuesFrom(UpperVerticies, samplingPeriod);
            var lower = GetValuesFrom(LowerVerticies, samplingPeriod);

            return upper.Zip(lower, (u, l) => new MinMaxValue() { Max = u, Min = l });
        }

        private IEnumerable<double> GetValuesFrom(List<Vertex> vertices, double samplingPeriodOfValues)
        {
            Vertex left = vertices[0], right = vertices[1];
            int nextIndexToVerticies = 2;


            for (double time = 0; time < Length; time += samplingPeriodOfValues)
            {
                if(time > right.Time)
                {
                    left = right;
                    right = vertices[nextIndexToVerticies];
                    nextIndexToVerticies++;
                }

                double distanceFromLeft = (time - left.Time) / (right.Time - left.Time);
                double distanceFromRight = 1 - distanceFromLeft;

                yield return (left.Value * distanceFromRight) + (right.Value * distanceFromLeft);
            }
        }

    }
}
