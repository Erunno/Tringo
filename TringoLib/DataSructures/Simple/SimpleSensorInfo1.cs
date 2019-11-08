using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures.Simple
{
    public class SimpleSensorInfo : SensorInfo
    {
        public SimpleSensorInfo(string name)
        {
            Name = name;
        }

        public SimpleSensorInfo() { }

        public override string Name { get; }
    }
}
