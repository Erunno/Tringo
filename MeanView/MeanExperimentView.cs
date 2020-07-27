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
    public partial class cbChangeColor : Form
    {
        public cbChangeColor(IExperiment meanExperiment, ISetOfExperiments baseExperiments)
        {
            InitializeComponent();
            this.meanExperiment = meanExperiment;
            this.baseExperiments = baseExperiments;

            sensorVisualiser = new SensorVisualiser(flowLayoutPanel, flowLayoutPanel.Width - 5); //TODO add custom size
            FillComboBoxes();

            for (int i = 0; i < baseExperiments.Experiments.Count; i++)
                sensorVisualiser.ColorsForMinorGraphs.Add(MultipleGraphsCanvas.DefaultMinorGraphPen.Color);

            cbIndexOfMovementSelection.SelectedIndex = 0;
            cbSensorSelection.SelectedIndex = 0;
            cbExperiments.SelectedIndex = 0;
        }

        IExperiment meanExperiment;
        ISetOfExperiments baseExperiments;

        SensorVisualiser sensorVisualiser;

        private void FillComboBoxes()
        {
            //index of movement
            for (int i = 0; i < meanExperiment.Movements.Count; i++)
                cbIndexOfMovementSelection.Items.Add(i + 1);

            //Sensors
            foreach (var sensor in meanExperiment.Movements[0].Sensors)
                cbSensorSelection.Items.Add(sensor.SensorInfo);

            //experiments
            foreach (var exp in baseExperiments.Experiments)
                cbExperiments.Items.Add(exp);
            cbExperiments.Items.Add("<Průměr experimetů>");
        }

        private void cbSensorSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGraphs();
        }

        private void cbIndexOfMovementSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGraphs();
        }

        private void RefreshGraphs()
        {
            int indexOfMovement = cbIndexOfMovementSelection.SelectedIndex;
            int indexOfSensor = cbSensorSelection.SelectedIndex;

            sensorVisualiser.ShowMainGraph 
                = !sensorVisualiser.IgnoredMinorGraphs.Exists(index => index == baseExperiments.Experiments.Count); //last index belogs to mean

            if (indexOfMovement == -1 || indexOfSensor == -1)
                return;

            sensorVisualiser.DrawSensor(
                sensor: meanExperiment.Movements[indexOfMovement].Sensors[indexOfSensor], 
                minorSensors: ExtractSensors(indexOfMovement, indexOfSensor)
                );
        }

        private IEnumerable<ISensor> ExtractSensors(int indexOfMovement, int indexOfSensor)
        {
            foreach (var experiment in baseExperiments.Experiments)
                yield return experiment.Movements[indexOfMovement].Sensors[indexOfSensor];
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bChangeColor_Click(object sender, EventArgs e)
        {
            
            if (colorDialog1.ShowDialog() != DialogResult.OK)
                return;

            if (cbExperiments.SelectedIndex == cbExperiments.Items.Count - 1)
                sensorVisualiser.ColorOfMainGraph = colorDialog1.Color;
            else
                sensorVisualiser.ColorsForMinorGraphs[cbExperiments.SelectedIndex] = colorDialog1.Color;
            
            RefreshGraphs();
        }


        private static string ShowMinorGraph = "Zobrazit";
        private static string HideMinorGraph = "Skrýt";

        private void cbExperiments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sensorVisualiser.IgnoredMinorGraphs.Exists(index => cbExperiments.SelectedIndex == index))
                bShowExperiment.Text = HideMinorGraph;
            else
                bShowExperiment.Text = ShowMinorGraph;

            bChangeColor.Enabled = true;
            bShowExperiment.Enabled = true;
        }

        private void bShowExperiment_Click(object sender, EventArgs e)
        {
            if(sensorVisualiser.IgnoredMinorGraphs.Exists(index => cbExperiments.SelectedIndex == index))
            {
                sensorVisualiser.IgnoredMinorGraphs.Remove(cbExperiments.SelectedIndex);
                bShowExperiment.Text = HideMinorGraph;
            }
            else
            {
                sensorVisualiser.IgnoredMinorGraphs.Add(cbExperiments.SelectedIndex);
                bShowExperiment.Text = ShowMinorGraph;
            }

            RefreshGraphs();
        }
    }
}
