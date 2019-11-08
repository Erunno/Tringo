using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;

namespace TringoModel.DataSructures
{
    public class SimpleSensor : ISensor
    {
        public IGraph EMG { get; set; }

        public IGraph X { get; set; }

        public IGraph Y { get; set; }

        public IGraph Z { get; set; }

        public SensorInfo SensorInfo { get; set; }
    }
}
