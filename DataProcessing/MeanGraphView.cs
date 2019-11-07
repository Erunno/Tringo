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

namespace ViewingUtils
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

            int width = flowLayoutPanel.Width - 5; //TODO add custom

            externComponents = builder.GetInicializedComponents(width);
            
            externComponents.ComboBox.SelectedIndex = 0;
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            externComponents.Canvas.MinorGraphs = GetGraphsFor((GraphItemInComboBox)comboBox.SelectedItem);
        }

        private IEnumerable<IGraph> GetGraphsFor(GraphItemInComboBox item)
        {
            foreach (var listOfSensors in (from movement in baseSetOfMovements.Movements select movement.Sensors))
                foreach (var sensor in listOfSensors)
                    if(sensor.SensorInfo == item.Sensor.SensorInfo)
                    {
                        yield return item.GraphProvider(sensor);
                        break;
                    }
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
