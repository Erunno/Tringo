using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;
using TringoModel.DataSructures.Universal;

namespace TringoModel.DataProcessing.Normalization
{
    public class NormalizedSetOfMovements : ISetOfMovements
    {
        public NormalizedSetOfMovements(ISetOfMovements setOfMovements, double newLength)
        {
            Movements = new List<IMovement>();
            NormalizeAllMovements(setOfMovements, newLength);
        }

        private void NormalizeAllMovements(ISetOfMovements setOfMovements, double newLength)
        {
            foreach (var mov in setOfMovements.Movements)
                Movements.Add(new UniversalMovement(mov, g => new NormalizedGraph(g, newLength)));
        }

        public IList<IMovement> Movements { get; }
    }
}
