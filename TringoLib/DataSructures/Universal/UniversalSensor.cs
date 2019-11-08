using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures.Universal
{
    public class UniversalSensor : ISensor
    {
        public UniversalSensor(ISensor baseSensor, GraphModifierDelegate graphModifier)
        {
            SensorInfo = baseSensor.SensorInfo;

            X = graphModifier(baseSensor.X);
            Y = graphModifier(baseSensor.Y);
            Z = graphModifier(baseSensor.Z);
            EMG = graphModifier(baseSensor.EMG);
        }


        public IGraph X { get; }

        public IGraph Y { get; }

        public IGraph Z { get; }

        public IGraph EMG { get; }

        public SensorInfo SensorInfo { get; }
    }
}
