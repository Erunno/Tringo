using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.Results;
using TringoModel.DataSructures;

namespace TringoModel.DataProcessing
{
    public interface IDataProcessor
    {
        IResult Process(ISetOfMovements data);
    }
}
