using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoLib.Results;
using TringoLib.DataSructures;

namespace TringoLib.DataProcessing
{
    public interface IDataProcessor
    {
        IResult Process(ISetOfMovements data);
    }
}
