using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures
{
    public interface IMovement
    {
        /// <summary>
        /// Colection of all sensors
        /// </summary>
        IList<ISensor> Sensors { get; }
    }
}
