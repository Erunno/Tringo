using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures
{
    public interface IExperiment : ISetOfMovements
    {
        string Name { get; }
    }
}
