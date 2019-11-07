using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;

namespace TringoModel.DataProcessing.Mean
{
    public class MeanSensor : ISensor
    {
        public MeanSensor(IEnumerable<ISensor> sensors)
        {
            if (!GivenDataSetIsCorrect(sensors))
                throw new UncorrectSensorSetException();

            this.sensors = sensors;
            
            SetSensorInfo();

            X = GetMeanGraph(s => s.X);
            Y = GetMeanGraph(s => s.Y);
            Z = GetMeanGraph(s => s.Z);
            EMG = GetMeanGraph(s => s.EMG);
        }

        private IEnumerable<ISensor> sensors;

        private MeanGraph GetMeanGraph(Func<ISensor, IGraph> propertyAccessor)
        {
            IEnumerable<IGraph> graphs = from sensor in sensors select propertyAccessor(sensor);

            return new MeanGraph(graphs);
        }

        private bool GivenDataSetIsCorrect(IEnumerable<ISensor> sensors)
        {
            if (!sensors.Any())
                return false;

            ISensorInfo sensorInfo = sensors.First().SensorInfo;

            if (sensors.All(s => s.SensorInfo == sensorInfo))
                return true;
            else
                return false;
        }

        private void SetSensorInfo()
        {
            SensorInfo = sensors.First().SensorInfo;
        }

        public IGraph X { get; }

        public IGraph Y { get; }

        public IGraph Z { get; }

        public IGraph EMG { get; }

        public ISensorInfo SensorInfo { get; private set; }
    }

    public class UncorrectSensorSetException : Exception { }
}