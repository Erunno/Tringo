using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;

namespace ViewingUtils
{
    public class SinGraph : IGraph
    {
        Random rnd = new Random();

        public SinGraph() { }

        public SinGraph(double shift, double scale)
        {
            this.scale = scale;
            this.shift = shift;
        }

        private double shift { get; } = 0;
        private double scale { get; } = 1;

        public double this[double time] => scale * (Math.Sin(time + shift));

        public double Length { get; } = 30;
    }
}
