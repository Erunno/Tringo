using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;
using TringoModel.DataSructures.Simple;

namespace TringoModel.DataSructures.DataCache
{
    public class RawGraph : ValuesContainingGraph
    {
        public RawGraph(IGraphInfo graphInfo, double[] values) : base(graphInfo, values) { }

        public double[] Samples => samples;
        public IGraphInfo GraphInfo => graphInfo;
    }
}
