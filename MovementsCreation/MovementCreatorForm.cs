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

            CreateComponents();

            CreateMovementsCreator();
            CreateEventsManager();
        }

        private ISetOfSensors sensors;
        private EventsManager eventsManager;
        private IMovementsCreator movementsCreator;

        private ComponentsContainer<MovementCreationCanvas> externComponents;

        private void CreateComponents()
        {
            var builder = new BaseFormBuilder<MovementCreationCanvas>(
                sensors.Sensors, flowLayoutPanel, cbListOfGraphs,
                pb => new MovementCreationCanvas(pb));

            int width = 3 * flowLayoutPanel.Width; //TODO add custom size

            externComponents = builder.GetInicializedComponents(width);
            externComponents.ComboBox.SelectedIndex = 0;
        }

        private void CreateMovementsCreator()
        {
            movementsCreator = new MovementsCreator(sensors);
        }

        private void CreateEventsManager()
        {
            eventsManager = new EventsManager(externComponents.Canvas, externComponents.PictureBox, movementsCreator);
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
    }
}
