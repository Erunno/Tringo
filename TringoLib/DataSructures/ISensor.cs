using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TringoModel.DataSructures
{
    public interface ISensor
    {
        IGraph X { get; }
        IGraph Y { get; }
        IGraph Z { get; }
        IGraph EMG { get; }

        SensorInfo SensorInfo { get; }
    }

    public abstract class SensorInfo
    {
        abstract public string Name { get; }

        public static bool operator ==(SensorInfo s1, SensorInfo s2)
            => s1.Name == s2.Name;


        public static bool operator !=(SensorInfo s1, SensorInfo s2)
            => !(s1 == s2);

        public override bool Equals(object obj)
            => obj is SensorInfo && (SensorInfo)obj == this;

        public override int GetHashCode() => Name.GetHashCode();
    }
}
