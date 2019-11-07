using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TringoModel.DataSructures;
using ViewingUtils.Canvases;

namespace ViewingUtils
{
    public class ComboBoxManager
    {
        public ComboBoxManager(ComboBox comboBox, Canvas canvas, IList<ISensor> sensors)
        {
            this.comboBox = comboBox;
            this.canvas = canvas;
            comboBox.SelectedIndexChanged += SelectedIndexChanged;
            FillComboBox(sensors);
        }

        ComboBox comboBox;
        Canvas canvas;

        private void FillComboBox(IList<ISensor> sensors)
        {
            foreach (var sensor in sensors)
            {
                comboBox.Items.Add(
                    new GraphItemInComboBox(sensor.SensorInfo.Name + ":EMG", sensor, s => s.EMG));
                comboBox.Items.Add(
                    new GraphItemInComboBox(sensor.SensorInfo.Name + ":X", sensor, s => s.X));
                comboBox.Items.Add(
                    new GraphItemInComboBox(sensor.SensorInfo.Name + ":Y", sensor, s => s.Y));
                comboBox.Items.Add(
                    new GraphItemInComboBox(sensor.SensorInfo.Name + ":Z", sensor, s => s.Z));
            }
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            GraphItemInComboBox item = (GraphItemInComboBox)comboBox.SelectedItem;

            canvas.Graph = item.Graph;
            canvas.RefreshAllComponents();
        }

    }


    public class GraphItemInComboBox
    {
        public GraphItemInComboBox(string name,ISensor sensor, GraphProviderDelegate graphProvider)
        {
            this.Name = name;
            this.GraphProvider = graphProvider;
            this.Sensor = sensor;
        }

        public IGraph Graph => GraphProvider(Sensor);

        public GraphProviderDelegate GraphProvider { get; }

        public ISensor Sensor { get; }

        public string Name { get; }

        public override string ToString() => Name;

        public delegate IGraph GraphProviderDelegate(ISensor sensor);
    }
}
