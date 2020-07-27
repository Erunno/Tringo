using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures.Simple
{
    public class SimpleExperiment : IExperiment
    {
        public SimpleExperiment(string name)
        {
            Name = name;
            Movements = new List<IMovement>();
        }

        public SimpleExperiment(string name, IList<IMovement> movements)
        {
            Name = name;
            Movements = movements;
        }

        public string Name { get; }

        public IList<IMovement> Movements { get; }

        public override string ToString() => Name;
    }
}
