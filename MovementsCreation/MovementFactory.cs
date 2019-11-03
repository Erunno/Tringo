using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures.Interval;
using TringoModel.DataSructures;

namespace MovementsCreation
{
    class MovementFactory
    {
        public MovementFactory(ISetOfSensors setOfSensors, Interval interval)
        {
            this.Interval = interval;
            this.setOfSensors = setOfSensors;
        }

        public Interval Interval { get; }
        private ISetOfSensors setOfSensors { get; }

        public IMovement GetMovement()
        {
            IMovement movement = new SimpleMovement();

            foreach (var sensor in setOfSensors.Sensors)
                movement.Sensors.Add(new SensorInterval(baseSensor: sensor, Interval));

            return movement;
        }
    }
}
