using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TringoModel.DataSructures;
using ViewingUtils;
using ViewingUtils.Canvases;

namespace MeanView
{
    public partial class MeanGraphView : Form
    {
        public MeanGraphView(IMovement meanMovement, ISetOfMovements baseSensors)
        {
            InitializeComponent();

            this.meanMovement = meanMovement;
            this.baseSetOfMovements = baseSensors;

            CreateComponents();
        }

        IMovement meanMovement;
        ISetOfMovements baseSetOfMovements;
        ComponentsContainer<MultipleGraphsCanvas> externComponents;


        private void CreateComponents()
        {
            BaseFormBuilder<MultipleGraphsCanvas> builder = new BaseFormBuilder<MultipleGraphsCanvas>(
                meanMovement.Sensors, flowLayoutPanel, comboBox,
                pb => new MultipleGraphsCanvas(pb));

            int width = flowLayoutPanel.Width - 20; //TODO add custom

            externComponents = builder.GetInicializedComponents(width);
            
            externComponents.ComboBox.SelectedIndex = 0;
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            externComponents.SensorCanvas.GraphCanvases.EMG.MinorGraphs
                = GetGraphsFor((GraphItemInComboBox)comboBox.SelectedItem, s => s.EMG);

            externComponents.SensorCanvas.GraphCanvases.X.MinorGraphs
                = GetGraphsFor((GraphItemInComboBox)comboBox.SelectedItem, s => s.X);

            externComponents.SensorCanvas.GraphCanvases.Y.MinorGraphs
                = GetGraphsFor((GraphItemInComboBox)comboBox.SelectedItem, s => s.Y);

            externComponents.SensorCanvas.GraphCanvases.Z.MinorGraphs
                = GetGraphsFor((GraphItemInComboBox)comboBox.SelectedItem, s => s.Z);
        }

        private IEnumerable<IGraph> GetGraphsFor(GraphItemInComboBox item, GraphProvider graphProvider)
        {
            foreach (var listOfSensors in (from movement in baseSetOfMovements.Movements select movement.Sensors))
                foreach (var sensor in listOfSensors)
                    if(sensor.SensorInfo == item.Sensor.SensorInfo)
                    {
                        yield return graphProvider(sensor);
                        break;
                    }
        }

        delegate IGraph GraphProvider(ISensor sensor); 

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
