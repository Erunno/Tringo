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
using TringoModel.DataSructures.Interval;

namespace MovementsCreation
{
    public partial class MovementCreatorForm : Form
    {
        public ISetOfMovements Result { get; private set; }

        public MovementCreatorForm(ISetOfSensors sensorsToParse)
        {
            InitializeComponent();

            sensors = sensorsToParse;

            CreateMovementsCreator();
            CreateCanvas();
            CreatePictureBox();
            CreateEventsManager();

            FillComboBox();
        }

        private Canvas canvas;
        private ISetOfSensors sensors;
        private EventsManager eventsManager;
        private PictureBox pictureBox;
        private IMovementsCreator movementsCreator;

        private void CreateCanvas()
        {
            canvas = new Canvas();

            int padding = 25;

            canvas.SetImage(new Bitmap( //TODO custum size of graph
                width: 10 * flowLayoutPanel.Width,
                height: flowLayoutPanel.Height - padding
                ));

            canvas.GraphPen = Pens.Red;
            canvas.IntervalsPen = Pens.Green;
            canvas.BordersPen = Pens.Blue;
        }

        private void CreatePictureBox()
        {
            pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            pictureBox.Image = canvas.BitmapImage;
            flowLayoutPanel.Controls.Add(pictureBox);
        }

        private void CreateMovementsCreator()
        {
            movementsCreator = new MovementsCreator(sensors);
        }

        private void FillComboBox()
        {
            foreach (var sensor in sensors.Sensors)
            {
                cbListOfGraphs.Items.Add(new GraphItemInComboBox(sensor.SensorInfo.Name + ":EMG", sensor.EMG));
                cbListOfGraphs.Items.Add(new GraphItemInComboBox(sensor.SensorInfo.Name + ":X", sensor.X));
                cbListOfGraphs.Items.Add(new GraphItemInComboBox(sensor.SensorInfo.Name + ":Y", sensor.Y));
                cbListOfGraphs.Items.Add(new GraphItemInComboBox(sensor.SensorInfo.Name + ":Z", sensor.Z));
            }
        }

        private void CreateEventsManager()
        {
            eventsManager = new EventsManager(canvas, pictureBox, movementsCreator);
        }

        private void bAddBorder_Click(object sender, EventArgs e)
        {
            eventsManager.ChangeCurrentAction(EventsManager.ClickAction.AddingBorder);
        }

        private void bRemoveLastBorder_Click(object sender, EventArgs e)
        {
            eventsManager.RemoveLastBorder();
        }

        private void bModifyMovement_Click(object sender, EventArgs e)
        {
            eventsManager.ChangeCurrentAction(EventsManager.ClickAction.ModifingIntervals);
        }

        private void bFinish_Click(object sender, EventArgs e)
        {
            Result = movementsCreator.GetCreatedSetOfMovements();
            this.Close();
        }

        private void cbListOfGraphs_SelectedIndexChanged(object sender, EventArgs e)
        {
            GraphItemInComboBox item = (GraphItemInComboBox)cbListOfGraphs.SelectedItem;

            canvas.Graph = item.Graph;
            canvas.RefreshAllComponents();
            pictureBox.Refresh();

            EnableAllButtons();
        }

        private void EnableAllButtons()
        {
            bAddBorder.Enabled = true;
            bRemoveLastBorder.Enabled = true;
            bFinish.Enabled = true;
            bModifyMovement.Enabled = true;
        }
    }

    class GraphItemInComboBox
    {
        public GraphItemInComboBox(string name, IGraph graph)
        {
            this.Name = name;
            this.Graph = graph;
        }

        public IGraph Graph { get; }
        public string Name { get; }

        public override string ToString() => Name;

    }
}
