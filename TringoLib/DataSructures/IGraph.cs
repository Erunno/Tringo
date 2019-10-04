using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures
{
    public interface IGraph
    {
        /// <summary>
        /// Gives access to values in certain time
        /// </summary>
        /// <param name="time">Time in second from start of graph</param>
        /// <returns>Value in given time</returns>
        double this[double time] { get; }

        /// <summary>
        /// Length of graph
        /// </summary>
        double Length { get; }
    }
}
