using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures.Universal
{
    public class BiUniversalSensor : ISensor
    {
        public BiUniversalSensor(ISensor primary, ISensor secondary, GraphProviderDelegate graphProvider)
        {
            SensorInfo = primary.SensorInfo;
            EMG = graphProvider(primary.EMG, secondary.EMG);
            X = graphProvider(primary.X, secondary.X);
            Z = graphProvider(primary.Z, secondary.Z);
            Y = graphProvider(primary.Y, secondary.Y);
        }


        public IGraph X { get; }

        public IGraph Y { get; }

        public IGraph Z { get; }

        public IGraph EMG { get; }

        public ISensorInfo SensorInfo { get; }
    }
}
