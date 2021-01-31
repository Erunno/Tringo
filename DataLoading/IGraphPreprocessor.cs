using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures.DataCache;

namespace DataLoading
{
    interface IGraphPreprocessor
    {
        void ModifySamples(List<RawGraph> data);
    }
}
