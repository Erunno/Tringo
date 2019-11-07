using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;
using TringoModel.DataProcessing.Mean;
using TringoModel.DataProcessing.Normalization;
using TringoModel.DataSructures.Universal;
using TringoModel.DataSructures.Simple;

namespace ViewingUtils
{
    public class MeanMovementManager
    {
        public MeanMovementManager(ISetOfMovements movements)
        {
            this.baseSetOfMovements = movements;
        }

        ISetOfMovements baseSetOfMovements;

        public IMovement GetMeanMovement()
        {
            ISetOfMovements normalizedMovements = GetNormalizedMovements();

            return new MeanMovement(normalizedMovements);
        }

        private ISetOfMovements GetNormalizedMovements()
        {
            double meanLenght = GetMeanLength();
            ISetOfMovements normalizedMovements = new NormalizedSetOfMovements(baseSetOfMovements, meanLenght);

            return normalizedMovements;
        }

        private double GetMeanLength()
            => (from mov in baseSetOfMovements.Movements select mov.Sensors[0].EMG.Length).Sum() / baseSetOfMovements.Movements.Count;
    }

}
