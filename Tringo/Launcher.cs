using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tringo.Monitor;
using TringoModel.DataSructures;
using TringoModel.DataSructures.Simple;
using TringoModel.DataSructures.DataCache;
using Tringo.TestGraphs;
using TringoModel.DataProcessing.Mean;
using DataLoading;
using System.IO;
using TringoModel.DataSructures.Interval;
using MovementsCreation;
using ViewingUtils;
using MeanView;
using DataProcessing;

namespace Tringo
{
    public partial class TringoApp : Form
    {
        public TringoApp()
        {
            InitializeComponent();

            lwSensorsInfo.View = View.Details;

            lwSensorsInfo.Columns.Add(new ColumnHeader());
            lwSensorsInfo.Columns[0].Width = lwSensorsInfo.Width - 5;

            //bring cursor to textbox
            tbNewNameOfExperiment.Focus();
            tbNewNameOfExperiment.TabIndex = 1;
        }

        ISetOfExperiments experiments = new SimpleSetOfExperiments();
        private void bCreateExperiment_Click(object sender, EventArgs e)
        {
            if (tbNewNameOfExperiment.Text.Length == 0)
                return;

            foreach (var exp in cbSelectedExperiment.Items)
                if (((RawExperiment)exp).Name == tbNewNameOfExperiment.Text)
                {
                    MessageBox.Show($"Jméno \"{((RawExperiment)exp).Name}\" již existuje");
                    return;
                }

            RawExperiment newExp = new RawExperiment(tbNewNameOfExperiment.Text);

            cbSelectedExperiment.Items.Add(newExp);
            cbSelectedExperiment.SelectedIndex = cbSelectedExperiment.Items.Count - 1;
            
            bLoading.Enabled = true;
            bLoading.Focus();
        }

        private void bLoading_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            LoadingVisualisation loadingForm = new LoadingVisualisation(openFileDialog1.FileName);
            loadingForm.ShowDialog();

            if (!loadingForm.LoadingWasSuccesful || !loadingForm.LoadingIsDone)
                return;

            RawExperiment selectedExperiment = (RawExperiment)cbSelectedExperiment.SelectedItem;

            selectedExperiment.AppendNewData(loadingForm.Result);
            bCreateMovements.Enabled = true;
            
            RefreshListView();
        }

        private void bCreateMovements_Click(object sender, EventArgs e)
        {
            RawExperiment selectedExp = (RawExperiment)cbSelectedExperiment.SelectedItem;

            IMovementsCreationManager movCr = new FormMovementCreatorManager();
            ISetOfMovements setOfMovements = movCr.CreateSetOfMovements(new SimpleSetOfSensors(selectedExp.SensorData));

            if (setOfMovements == null) //user hasnt created set of movements
                return;
            
            CreateOrReplaceExperiment(setOfMovements);

            bMeanComputation.Enabled = selectedExp.MovementsCreated
                = setOfMovements != null && setOfMovements.Movements.Count != 0;

            RefreshComboBox();
        }


        private void CreateOrReplaceExperiment(ISetOfMovements setOfMovements)
        {
            string newName = ((RawExperiment)cbSelectedExperiment.SelectedItem).Name;

            for (int i = 0; i < experiments.Experiments.Count; i++)
                if(experiments.Experiments[i].Name == newName) //experiment already exists
                {
                    experiments.Experiments.RemoveAt(i);
                    continue;
                }

            experiments.Experiments.Add(new SimpleExperiment(newName, setOfMovements.Movements));
        }

        private void bMeanComputation_Click(object sender, EventArgs e)
        {
            //TODO add check
            IExperiment mean = new MeanExperiment(experiments);

            cbChangeColor meanExperimentView = new cbChangeColor(mean, experiments);

            meanExperimentView.ShowDialog();
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSelectedExperiment_SelectedIndexChanged(object sender, EventArgs e)
        {
            RawExperiment selectedExp = (RawExperiment)cbSelectedExperiment.SelectedItem;

            bCreateMovements.Enabled = selectedExp.SensorData.Count > 0;
            bMeanComputation.Enabled = selectedExp.MovementsCreated;

            RefreshListView();
        }


        private void RefreshComboBox() //TODO try to do it better
        {
            int selectedItemIndex = cbSelectedExperiment.SelectedIndex;

            List<object> items = new List<object>();

            foreach (var item in cbSelectedExperiment.Items)
                items.Add(item);

            cbSelectedExperiment.Items.Clear();

            foreach (var item in items)
                cbSelectedExperiment.Items.Add(item);

            cbSelectedExperiment.SelectedIndex = selectedItemIndex;
        }

        private void RefreshListView()
        {
            RawExperiment selectedExp = (RawExperiment)cbSelectedExperiment.SelectedItem;

            lwSensorsInfo.Items.Clear();
            foreach (var sensorInfo in from sensor in selectedExp.SensorData select sensor.SensorInfo)
                lwSensorsInfo.Items.Add(sensorInfo.ToString());
        }

        private void tbNewNameOfExperiment_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                bCreateExperiment_Click(sender, e);
        }
    }
}
