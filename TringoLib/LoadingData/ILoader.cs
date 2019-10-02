using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoLib.DataSructures;

namespace TringoLib.LoadingData
{
    public interface ILoader
    {
        ISetOfMovements LoadSetOfMovement();
    }
}
