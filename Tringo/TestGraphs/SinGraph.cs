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

        public double this[double time] => Math.Sin(time);


        public double Length { get; } = 10;
    }
}
