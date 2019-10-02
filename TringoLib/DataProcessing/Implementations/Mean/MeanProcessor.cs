using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoLib.DataSructures;
using TringoLib.Results;

namespace TringoLib.DataProcessing.Implementations
{
    class MeanProcessor : IDataProcessor
    {
        public IResult Process(ISetOfMovements data)
        {
            throw new NotImplementedException();
        }



    }

    class MeanMovement : IResult, IMovement
    {
        public ICollection<ISensor> Sensors => throw new NotImplementedException();
    }
}
