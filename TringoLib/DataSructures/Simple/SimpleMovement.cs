using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;

namespace TringoModel.DataSructures
{
    public class SimpleMovement : IMovement
    {
        public IList<ISensor> Sensors { get; } = new List<ISensor>();
    }
}
