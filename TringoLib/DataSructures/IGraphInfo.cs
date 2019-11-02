using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures
{
    public interface IGraphInfo
    {
        string Name { get; }
        double SamplingFrequency { get; }
        int SamplesCount { get; }
    }
}
