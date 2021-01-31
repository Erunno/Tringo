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
using ViewingUtils.Canvases;

namespace MovementsCreation
{
    public partial class MovementCreatorForm : Form
    {
        public ISetOfMovements Result { get; private set; }

        public MovementCreatorForm(ISetOfSensors sensorsToParse)
        {
            InitializeComponent();

            sensors = sensorsToParse;
            oldSize = this.Size;

            RenderComponents();
        }

        private Size oldSize;

        private ISetOfSensors sensors;
        private EventsManager eventsManager;
        private IMovementsCreator movementsCreator;

        private ComponentsContainer<MovementCreationCanvas> externComponents;

        private void RenderComponents()
        {
            int selected = cbListOfGraphs.SelectedIndex != -1
                ? cbListOfGraphs.SelectedIndex
                : 0;

            CreateComponents();

            CreateMovementsCreator();
            CreateEventsManager();

            cbListOfGraphs.SelectedIndex = selected;
        }

        private void CreateComponents()
        {
            flowLayoutPanel.Controls.Clear();
            cbListOfGraphs.Items.Clear();

            var builder = new BaseFormBuilder<MovementCreationCanvas>(
                sensors.Sensors, flowLayoutPanel, cbListOfGraphs,
                pb => new MovementCreationCanvas(pb));

            decimal requstedWidth = graphWidh.Value;

            int width = (int)(requstedWidth * flowLayoutPanel.Width - 10);
            width = Math.Max(100, width); // min width is 100;

            externComponents = builder.GetInicializedComponents(width);
            externComponents.ComboBox.SelectedIndex = 0;
        }

        private void CreateMovementsCreator()
        {
            movementsCreator = new MovementsCreator(sensors);
        }

        private void CreateEventsManager()
        {
            eventsManager = new EventsManager(externComponents.SensorCanvas, movementsCreator);
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
            EnableAllButtons();
        }

        private void EnableAllButtons()
        {
            bAddBorder.Enabled = true;
            bRemoveLastBorder.Enabled = true;
            bFinish.Enabled = true;
            bModifyMovement.Enabled = true;
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MovementCreatorForm_SizeChanged(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void ChangeSize()
        {
            int xDelta = this.Size.Width - oldSize.Width;
            int yDelta = this.Size.Height - oldSize.Height;

            oldSize = this.Size;

            flowLayoutPanel.Size = new Size(
                width: flowLayoutPanel.Size.Width + xDelta,
                height: flowLayoutPanel.Size.Height + yDelta
                );

            bFinish.Top += yDelta;

            RenderComponents();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            ChangeSize();
        }

        private void graphWidh_ValueChanged(object sender, EventArgs e)
        {
            RenderComponents();
        }
    }
}
