using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures.Simple
{
    public class SimpleSetOfExperiments : ISetOfExperiments
    {
        public List<IExperiment> Experiments { get; set; } = new List<IExperiment>();

        IList<IExperiment> ISetOfExperiments.Experiments => Experiments;
    }
}
