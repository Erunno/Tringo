using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures.Simple
{
    class MutableGraphInfo : IGraphInfo
    {
        public string Name { get; set; }
        public double SamplingFrequency { get; set; }
        public int SamplesCount { get; set; }
    }
}
