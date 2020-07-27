using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewingUtils;
using TringoModel.DataSructures;

namespace ViewingUtils
{
    static class GraphExtensions
    {
        public static Scale GetScale<G>(this G graph, double freq) where G : IGraph
        {
            double step = 1 / freq;
            double position = 0;
            int counter = 0;

            double max = double.MinValue, min = double.MaxValue;
            while (position < graph.Length)
            {
                double value = graph[position];

                if (value > max)
                    max = value;

                if (value < min)
                    min = value;

                position = ++counter * step;
            }

            double correction = 0.01;
            return new Scale(
                MaxValue: max * (1 + correction),
                MinValue: min * (1 + correction)
                );
        }

    }
}
