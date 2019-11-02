using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoading
{
    interface IGraphPreprocessor
    {
        void ModifySamples(List<RawGraph> samples);
    }
}
