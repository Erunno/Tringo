using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures.Universal
{
    public class BiUniversalMovement : IMovement
    {
        public BiUniversalMovement(IMovement primary, IMovement secondary, GraphProviderDelegate graphProvider)
        {
            if (primary.Sensors.Count != secondary.Sensors.Count)
                throw new DifferentCountOfSensorsException();

            for (int i = 0; i < primary.Sensors.Count; i++)
                Sensors.Add(new BiUniversalSensor(primary.Sensors[i], secondary.Sensors[i], graphProvider));
        }

        public IList<ISensor> Sensors { get; } = new List<ISensor>();
    }

    public delegate IGraph GraphProviderDelegate(IGraph g1, IGraph g2);

    class DifferentCountOfSensorsException : Exception { }

}
