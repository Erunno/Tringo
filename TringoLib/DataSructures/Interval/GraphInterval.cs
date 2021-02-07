using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures.Simple;

namespace TringoModel.DataSructures.Interval
{
    public class GraphInterval : IGraph
    {
        public GraphInterval(IGraph baseGraph,Interval interval)
        {
            this.baseGraph = baseGraph;
            this.interval = interval;

            toleratedLenght = baseGraph.Length * 1.001; // ~0.1% error can occure during division and multiplication

            if (!IntervalFitsToGraph())
                throw new UnvalidIntervalProvidedException();
        }

        private bool IntervalFitsToGraph() => 0 <= interval.From && interval.To <= baseGraph.Length;

        private IGraph baseGraph { get; }
        private Interval interval { get; }


        public double this[double time] => TimeIsInRange(time) ? baseGraph[GetRealTime(time) + interval.From] : throw new TimeOfRangeException();

        private readonly double toleratedLenght;
        private bool TimeIsInRange(double time) => 0 <= time && time <= toleratedLenght;

        private double GetRealTime(double originalTime) => Math.Min(originalTime, toleratedLenght);

        public double Length => interval.Length;
    }

    public struct Interval
    {
        public Interval(double from, double to)
        {
            this.From = from;
            this.To = to;
        }

        public double From { get; }
        public double To { get; }

        public double Length => To - From;

        public bool ValueIsInClosedInterval(double value) => From <= value && value <= To; 

        public bool ValueIsInOpenInterval(double value) => From < value && value < To;

        public static bool operator ==(Interval i1, Interval i2) => i1.From == i2.From && i1.To == i2.To;
        public static bool operator !=(Interval i1, Interval i2) => !(i1 == i2);


        public override bool Equals(object obj) => obj is Interval && (Interval)obj == this;
        public override int GetHashCode() => From.GetHashCode() + To.GetHashCode();
    }

    class UnvalidIntervalProvidedException : ArgumentException { }
}
