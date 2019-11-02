using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;
using System.IO;
using TringoModel.DataSructures.Simple;

namespace DataLoading
{
    public class LoadingManager
    {
        public LoadingManager()
        {
            preprocessors = new List<IGraphPreprocessor>();
            FillListOfPreprocessors();
        }

        List<IGraphPreprocessor> preprocessors;

        private void FillListOfPreprocessors() 
        {
            throw new NotImplementedException();
        }

        public ISetOfSensors LoadSensors(TextReader input)
        {
            Translator translator = new Translator(input);
            Loader loader = new Loader();

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

                SimpleSensor newSensor = new SimpleSensor();

                newSensor.EMG   = rawGraphs[i + 0];
                newSensor.X     = rawGraphs[i + 1];
                newSensor.Y     = rawGraphs[i + 2];
                newSensor.Z     = rawGraphs[i + 3];

                newSensor.SensorInfo = new SensorInfo(name: rawGraphs[i].GraphInfo.Name);
            }

            return sensors;
        }

        private bool AllGraphsHasSameName(List<RawGraph> graphs, int startingIndex)
        {
            for (int i = 0; i < GraphsInSensorCount - 1; i++)
                if (graphs[i].GraphInfo.Name != graphs[i + 1].GraphInfo.Name)
                    return false;

            return true;
        }
    }

    class UnvalidNumberOfGraphsException : Exception { }

    class GraphsDontHaveSameNameException : Exception { }
}
