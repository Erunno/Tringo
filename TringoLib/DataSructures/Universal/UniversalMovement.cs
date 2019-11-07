using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures.Universal
{
    public class UniversalMovement : IMovement
    {
        public UniversalMovement(IMovement baseMovement, GraphModifierDelegate graphModifier)
        {
            Sensors = new List<ISensor>(capacity: baseMovement.Sensors.Count);

            for (int i = 0; i < baseMovement.Sensors.Count; i++)
                Sensors.Add(new UniversalSensor(baseMovement.Sensors[i], graphModifier));
        }

        public IList<ISensor> Sensors { get; }
    }
}
