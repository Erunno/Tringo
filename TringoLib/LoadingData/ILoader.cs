using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;

namespace TringoModel.LoadingData
{
    public interface ILoader
    {
        ISetOfMovements LoadSetOfMovement();
    }
}
