using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLoading;
using System.IO;
using TringoModel.DataSructures;

namespace FeaturesTestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader input = new StreamReader(@"C:\Users\matya\Desktop\test_vse.csv");

            TextDataLoadingManager manager = new TextDataLoadingManager(input);

            ISetOfSensors result = manager.LoadSensors();
        }
    }
}
