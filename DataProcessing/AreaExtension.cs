using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;

namespace DataProcessing
{
    public static class IGraphExtensions
    {
        public static double GetAbsoluteArea(this IGraph graph, double samplingFrequenecy)
        {
            double sizeOfStep = 1 / samplingFrequenecy;
            int numOfSteps = (int)(samplingFrequenecy * graph.Length);

            double sum = 0;

            for (int i = 0; i < numOfSteps; i++)
                sum += Math.Abs(graph[i * sizeOfStep]);

            return sum * sizeOfStep;
        }
    }

    public static class ISensorExtensions
    {
        public static double GetSumOfAreasOfSubgraphs(this ISensor sensor, double sampligFrequency)
        {
            double sum = 0;

            sum += sensor.EMG.GetAbsoluteArea(sampligFrequency);
            sum += sensor.X.GetAbsoluteArea(sampligFrequency);
            sum += sensor.Y.GetAbsoluteArea(sampligFrequency);
            sum += sensor.Z.GetAbsoluteArea(sampligFrequency);

            return sum;
        }
    }

    public static class IMovementExtensions
    {
        public static double GetSumOfAreasOfSubgraphs(this IMovement movement, double sampligFrequency)
        {
            double sum = 0;

            foreach (var sensor in movement.Sensors)
                sum += sensor.GetSumOfAreasOfSubgraphs(sampligFrequency);

            return sum;
        }
    }


}
