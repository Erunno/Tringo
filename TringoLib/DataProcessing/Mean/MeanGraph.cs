using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;

namespace TringoModel.DataProcessing.Mean
{
    public class MeanGraph : IGraph
    {
        public double Length { get; }

        private List<IGraph> listedGraphs { get; }

        public MeanGraph(IEnumerable<IGraph> graphs)
        {
            listedGraphs = graphs.ToList(); //It will be quicker to have it listed

            Length = graphs.Min(g => g.Length);
        }

        public double this[double time] 
        {
            get
            {
                double sum = 0;

                foreach (var graph in listedGraphs)
                    sum += graph[time];

                return sum / listedGraphs.Count;
            }
        }

    }
}
