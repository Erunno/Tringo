using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoLib.DataSructures
{
    public interface ISetOfMovements
    {
        ICollection<IMovement> Movements { get; }
    }
}
