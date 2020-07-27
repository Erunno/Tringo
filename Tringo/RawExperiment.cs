using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;

namespace Tringo
{
    class RawExperiment
    {
        public RawExperiment(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public List<ISensor> SensorData { get; private set; } = new List<ISensor>();

        public override string ToString() => MovementsCreated ? "✓ " + Name : Name;

        public void AppendNewData(ISetOfSensors sensors)
        {
            foreach (var sensor in sensors.Sensors)
                SensorData.Add(sensor);

            var sortedData = from sensor in SensorData orderby sensor.SensorInfo.Name select sensor;
            SensorData = sortedData.ToList();
        }

        public bool MovementsCreated { get; set; } = false;

    }
}
