using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;
using TringoModel.DataSructures.DataCache;
using TringoModel.DataSructures.Simple;

namespace DataLoading
{
    public class ExcelLoadingManagerV2 : ILoadingManager
    {
        private readonly string filePath;

        static ExcelLoadingManagerV2()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public ExcelLoadingManagerV2(string filePath)
        {
            this.filePath = filePath;
        }

        private DataTable table;

        public ISetOfSensors LoadSensors()
        {
            columsCount = 0;
            columnsDone = 0;

            var sensors = new List<ISensor>();
            
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();

                    foreach (var indexOfTableWithData in FindTablesWithData(result))
                    {
                        table = result.Tables[indexOfTableWithData];

                        columsCount = table.Columns.Count;

                        for (int i = 0; i < table.Columns.Count; i += 8)
                            sensors.Add(CreateSensor(startIndex: i));
                    }
                }
            }

            return new SimpleSetOfSensors(sensors);
        }

        private string[] graphNames = new string[]
        {
            "EMG", "X", "Y", "Z"
        };

        private ISensor CreateSensor(int startIndex)
        {
            var graphs = new List<RawGraph>();
            var name = ((string)table.Rows[0][startIndex + 1]).Split(':')[0];

            for (int i = 0; i < 8; i += 2)
                graphs.Add(CreateGraph(startIndex: startIndex + i, name: graphNames[i / 2]));

            var normalizedGraphs = NormalizeGraphs(graphs);

            return new SimpleSensor
            {
                EMG = normalizedGraphs[0],
                X = normalizedGraphs[1],
                Y = normalizedGraphs[2],
                Z = normalizedGraphs[3],
                SensorInfo = new SimpleSensorInfo(name)
            };
        }


        private RawGraph CreateGraph(int startIndex, string name)
        {
            var count = table.Rows.Count - 1;
            var period = (double)table.Rows[2][startIndex];

            var info = new MutableGraphInfo
            {
                Name = name,
                SamplesCount = count,
                SamplingFrequency = 1 / period,
            };

            var dataValues = new double[count];

            for (int i = 1; i < count; i++)
                dataValues[i] = (double)table.Rows[i][startIndex + 1];

            columnsDone += 2;

            return new RawGraph(info, dataValues);
        }

        private List<RawGraph> NormalizeGraphs(List<RawGraph> graphs)
        {
            var minTime = graphs.Select(g => g.Length).Min();

            var normalizedGraphs = graphs.Select(g =>
            {
                var samplesCount = (int)(minTime / g.Length * g.Samples.Length);
                var newGraphInfo = new MutableGraphInfo
                {
                    Name = g.GraphInfo.Name,
                    SamplesCount = samplesCount,
                    SamplingFrequency = g.GraphInfo.SamplingFrequency
                };

                return new RawGraph(
                    newGraphInfo,
                    g.Samples.Take(samplesCount).ToArray());
            }).ToList();

            return normalizedGraphs;
        }

        public int columsCount = 0;
        public int columnsDone = 0;
        public double GetProgress() => columsCount != 0 ? ((double)columnsDone / columsCount) : 0;


        private IEnumerable<int> FindTablesWithData(DataSet ds)
        {
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                bool cell00IsPresent =
                    ds.Tables[i].Rows.Count != 0 &&
                    ds.Tables[i].Rows[0].ItemArray.Length != 0;

                if (cell00IsPresent && ds.Tables[i].Rows[0][0].ToString() == "X[s]")
                    yield return i;
            }
        }
    }
}
