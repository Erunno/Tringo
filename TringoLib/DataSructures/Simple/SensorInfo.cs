using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures.Simple
{
    public class SensorInfo : ISensorInfo
    {
        public SensorInfo(string name)
        {
            Name = name;
        }

        public SensorInfo() { }

        public string Name { get; set; }
    }
}
