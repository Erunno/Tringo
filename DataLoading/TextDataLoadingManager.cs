using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;
using System.IO;
using TringoModel.DataSructures.Simple;
using TringoModel.DataSructures.DataCache;

namespace DataLoading
{
    public interface ILoadingManager
    {
        ISetOfSensors LoadSensors();
        double GetProgress();
    }


    public class TextDataLoadingManager : ILoadingManager
    {
        public TextDataLoadingManager(TextReader input)
        {
            this.input = input;
            preprocessors = new List<IGraphPreprocessor>();
            FillListOfPreprocessors();
        }

        List<IGraphPreprocessor> preprocessors;
        TextReader input { get; }

        private void FillListOfPreprocessors() 
        {
            //TODO discuss good blur
            preprocessors.Add(new GraphBlurPreprocessor(new double[] { 0.125, 0.25, 0.25, 0.25, 0.125 }));
        }

        public ISetOfSensors LoadSensors()
        {
            Translator translator = new Translator(input);
            GraphLoader loader = new GraphLoader();

            List<RawGraph> rawData = loader.LoadGraphs(translator);
            PreprocessAllData(rawData);

            List<ISensor> sensors = MergeGraphsToSensors(rawData);

            return new SimpleSetOfSensors(sensors);
        }

        private void PreprocessAllData(List<RawGraph> rawData)
        {
            foreach (var preprocessor in preprocessors)
                preprocessor.ModifySamples(rawData);
        }

        private const int GraphsInSensorCount = 4;

        private List<ISensor> MergeGraphsToSensors(List<RawGraph> rawGraphs)
        {
            if (rawGraphs.Count % GraphsInSensorCount != 0)
                throw new UnvalidNumberOfGraphsException();

            List<ISensor> sensors = new List<ISensor>();

            for (int i = 0; i < rawGraphs.Count; i+=GraphsInSensorCount)
            {
                if (!AllGraphsHasSameName(rawGraphs, startingIndex: i))
                    throw new GraphsDontHaveSameNameException();

                ISensor newSensor = GetSensor(rawGraphs, index: i);

                sensors.Add(newSensor);
            }

            return sensors;
        }

        private ISensor GetSensor(List<RawGraph> rawGraphs, int index) 
            => new SimpleSensor
                {
                    EMG = rawGraphs[index + 0],
                    X   = rawGraphs[index + 1],
                    Y   = rawGraphs[index + 2],
                    Z   = rawGraphs[index + 3],

                    SensorInfo = new SimpleSensorInfo(name: rawGraphs[index].GraphInfo.Name)
                };

        private bool AllGraphsHasSameName(List<RawGraph> graphs, int startingIndex)
        {
            for (int i = 0; i < GraphsInSensorCount - 1; i++)
                if (graphs[i].GraphInfo.Name != graphs[i + 1].GraphInfo.Name)
                    return false;

            return true;
        }

        public double GetProgress() => 0;
    }

    class UnvalidNumberOfGraphsException : Exception { }

    class GraphsDontHaveSameNameException : Exception { }
}
