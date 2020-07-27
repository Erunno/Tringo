using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures.Simple
{
    public class SimpleSetOfSensors : ISetOfSensors
    {
        public SimpleSetOfSensors(IList<ISensor> sensors)
        {
            this.Sensors = sensors;
        }

        public IList<ISensor> Sensors { get; set; }
    }

}
