using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures
{
    public interface ISensor
    {
        IGraph X { get; }
        IGraph Y { get; }
        IGraph Z { get; }
        IGraph EMG { get; }

        ISensorInfo SensorInfo { get; }
    }

    public interface ISensorInfo
    {
        string Name { get; }
    }
}
