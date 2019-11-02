using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLoading;

namespace FeaturesTestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = "ahoj_blbe_kokote".GetStartIndexOf("kokote");

            Console.WriteLine(start);

        }
    }
}
