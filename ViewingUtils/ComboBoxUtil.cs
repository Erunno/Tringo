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
    public class ComboBoxManager<Canvas> where Canvas : GraphCanvas
    {
        public ComboBoxManager(ComboBox comboBox, SensorCanvas<Canvas> canvas, IList<ISensor> sensors)
        {
            this.comboBox = comboBox;
            this.canvas = canvas;
            comboBox.SelectedIndexChanged += SelectedIndexChanged;
            FillComboBox(sensors);
        }

        ComboBox comboBox;
        SensorCanvas<Canvas> canvas;

        private void FillComboBox(IList<ISensor> sensors)
        {
            foreach (var sensor in sensors)
                comboBox.Items.Add(new GraphItemInComboBox(sensor));
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            GraphItemInComboBox item = (GraphItemInComboBox)comboBox.SelectedItem;

            canvas.Sensor = item.Sensor;
            canvas.RefreshAllSubgraphs();
        }

    }


    public class GraphItemInComboBox
    {
        public GraphItemInComboBox(ISensor sensor)
        {
            this.Sensor = sensor;
        }

        public ISensor Sensor { get; }

        public string Name => Sensor.SensorInfo.Name;

        public override string ToString() => Name;
    }
}
