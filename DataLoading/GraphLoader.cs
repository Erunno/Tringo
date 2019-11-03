using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TringoModel.DataSructures;

namespace DataLoading
{
    class GraphLoader
    {
        private Parser parser;
        private List<GraphFactory> factories;

        public List<RawGraph> LoadGraphs(TextReader input)
        {
            parser = new Parser(input);
            factories = new List<GraphFactory>();

            CreateGraphFactories();
            FillFactoriesWithSamples();
            List<RawGraph> loadedData = GetDataFromFactories();

            return loadedData;
        }
        
        private void CreateGraphFactories()
        {
            IGraphInfo graphInfo;

            while ((graphInfo = parser.GetNextGraphInfo()) != null)
                factories.Add(new GraphFactory(graphInfo));
        }

        private void FillFactoriesWithSamples()
        {
            parser.SkipUnwantedLines();
            parser.UpdateLineOfSamples();

            while(parser.LineOfSamples != null)
            {
                RegisterLineOfSamples(parser.LineOfSamples);
                parser.UpdateLineOfSamples();
            }
        }

        private void RegisterLineOfSamples(double?[] lineOfSamples)
        {
            for (int i = 0; i < factories.Count; i++) //TODO discuss what X[s] column means ... there are lot of them
                if (lineOfSamples[i * 2 + 1].HasValue)
                    factories[i].RegisterNextValue(lineOfSamples[i * 2 + 1].Value);
        }

        private List<RawGraph> GetDataFromFactories()
        {
            List<RawGraph> data = new List<RawGraph>();

            foreach (var factory in factories)
                data.Add(factory.GetRawGraph());

            return data;
        }
    }
}
