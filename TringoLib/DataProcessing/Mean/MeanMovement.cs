using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;
using TringoModel.Results;

namespace TringoModel.DataProcessing.Mean
{
    public class MeanMovement : IMovement, IResult
    {
        public MeanMovement(ISetOfMovements set)
        {
            if (set.Movements.Count == 0)
                throw new EmptySetOfMovementsException();

            if (!SetHasCorrectFormat(set))
                throw new InccorectFormatOfSetOfMovementsException();

            Sensors = new List<ISensor>();

            FillListOfSensors(set);
        }

        private bool SetHasCorrectFormat(ISetOfMovements set)
        {
            int count = set.Movements[0].Sensors.Count;

            if (!set.Movements.All(mov => mov.Sensors.Count == count))
                return false;

            return true;
        }

        private void FillListOfSensors(ISetOfMovements set)
        {
            int count = set.Movements[0].Sensors.Count;

            for (int i = 0; i < count; i++)
            {
                var allSensorsOfCertainIndex = GetAllSensors(set, indexOfSensors: i);

                Sensors.Add(new MeanSensor(allSensorsOfCertainIndex));
            }
        }

        private IEnumerable<ISensor> GetAllSensors(ISetOfMovements set, int indexOfSensors)
            => from mov in set.Movements select mov.Sensors[indexOfSensors];

        public IList<ISensor> Sensors { get; }
    }

    public class EmptySetOfMovementsException : Exception { }
    public class InccorectFormatOfSetOfMovementsException : Exception { }
}
