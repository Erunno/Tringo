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
        public MeanMovement(IList<IMovement> movements)
        {
            Init(movements);
        }

        public MeanMovement(ISetOfMovements set) 
        {
            Init(set.Movements);
        }

        private void Init(IList<IMovement> movements)
        {
            if (movements.Count == 0)
                throw new EmptySetOfMovementsException();

            if (!SetHasCorrectFormat(movements))
                throw new InccorectFormatOfSetOfMovementsException();

            Sensors = new List<ISensor>();

            FillListOfSensors(movements);
        }

        private bool SetHasCorrectFormat(IList<IMovement> movements)
        {
            int count = movements[0].Sensors.Count;

            if (!movements.All(mov => mov.Sensors.Count == count))
                return false;

            return true;
        }

        private void FillListOfSensors(IList<IMovement> movements)
        {
            int count = movements[0].Sensors.Count;

            for (int i = 0; i < count; i++)
            {
                var allSensorsOfCertainIndex = GetAllSensors(movements, indexOfSensors: i);

                Sensors.Add(new MeanSensor(allSensorsOfCertainIndex));
            }
        }

        private IEnumerable<ISensor> GetAllSensors(IList<IMovement> movements, int indexOfSensors)
            => from mov in movements select mov.Sensors[indexOfSensors];

        public IList<ISensor> Sensors { get; private set; }
    }

    public class EmptySetOfMovementsException : Exception { }
    public class InccorectFormatOfSetOfMovementsException : Exception { }
}
