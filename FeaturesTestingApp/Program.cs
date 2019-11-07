using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLoading;
using System.IO;
using TringoModel.DataSructures;
using DataProcessing;
using ViewingUtils;
using TringoModel.DataProcessing.Arithmetics;

namespace FeaturesTestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SinGraph s1 = new SinGraph();
            SinGraph s2 = new SinGraph(0,2);

            DifferenceGraph diff = new DifferenceGraph(s2, s1);

            Console.WriteLine(diff.GetAbsoluteArea(100000));

        }
    }
}
