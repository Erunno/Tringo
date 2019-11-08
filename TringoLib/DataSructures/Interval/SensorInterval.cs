using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures.Interval
{
    public class SensorInterval : ISensor
    {
        public SensorInterval(ISensor baseSensor, Interval interval)
        {
            SensorInfo = baseSensor.SensorInfo;

            X = new GraphInterval(baseSensor.X, interval);
            Y = new GraphInterval(baseSensor.Y, interval);
            Z = new GraphInterval(baseSensor.Z, interval);
            EMG = new GraphInterval(baseSensor.EMG, interval);
        }

        public IGraph X { get; }

        public IGraph Y { get; }

        public IGraph Z { get; }

        public IGraph EMG { get; }

        public SensorInfo SensorInfo { get; }
    }
}
