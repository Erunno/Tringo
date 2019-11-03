using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures.Simple
{
    public class SimpleSetOfMovements : ISetOfMovements
    {
        public SimpleSetOfMovements(IList<IMovement> movements)
        {
            this.Movements = movements;
        }

        public IList<IMovement> Movements { get; }
    }
}
