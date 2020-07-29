using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures.Simple
{
    public class SimpleSetOfExperiments : ISetOfExperiments
    {
        public IList<IExperiment> Experiments { get; set; } = new List<IExperiment>();
    }
}
