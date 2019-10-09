using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;

namespace Tringo.TestGraphs
{
    class SinGraph : IGraph
    {
        Random rnd = new Random();

        public double this[double time] => (Math.Sin(time));// + lastValue)/2 + rnd.NextDouble()*0.06-0.003;

        private double lastValue = 0;
        public double Length { get; } = 10;
    }
}
