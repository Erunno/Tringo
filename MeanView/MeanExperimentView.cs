using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

            AdjustFLowLayoutPanel();
            CreateOrRefreshSensorVisualiser();
            FillComboBoxes();

            
            cbSensorSelection.SelectedIndex = 0;
            cbExperiments.SelectedIndex = 0;

            cbChangeColor_Resize(null, null);
        }

        IExperiment meanExperiment;
        ISetOfExperiments baseExperiments;

        SensorVisualiser sensorVisualiser;

        List<SensorVisualiser> sensorVisualisers;
        List<Control> oldPictures { get; set; } = new List<Control>();

        double width, height, envelopWinSizeSec;

        bool ShouldDrawAllSensors => cbSensorSelection.SelectedIndex == cbSensorSelection.Items.Count - 1;

        private void FillComboBoxes()
        {
            //Sensors
            foreach (var sensor in meanExperiment.Movements[0].Sensors)
                cbSensorSelection.Items.Add(sensor.SensorInfo);

            cbSensorSelection.Items.Add("<Vykreslit všechny sensory>");

            //experiments
            foreach (var exp in baseExperiments.Experiments)
                cbExperiments.Items.Add(exp);
            cbExperiments.Items.Add("<Průměr experimetů>");
            cbExperiments.Items.Add("<Rozdílový graf>");
        }

        private int GraphWidth  => cbAutosize.Checked ? Math.Max(0, flowLayoutPanel.Width - 15) : (int)nWidth.Value;
        private int GraphHeight => cbAutosize.Checked ? flowLayoutPanel.Height / 4 - 10 : (int)nHeight.Value;
        private double EnvelopWinSize_sec => (double)nEnvelopWinSize.Value / 1000.0; //numbox is in ms

        private void CreateOrRefreshSensorVisualiser()
        {
            flowLayoutPanel.Controls.Clear();
            
            var oldVisualiser = sensorVisualiser;
            sensorVisualiser = new SensorVisualiser(flowLayoutPanel, GraphWidth, GraphHeight, EnvelopWinSize_sec); //TODO add custom size

            if(oldVisualiser == null)
                for (int i = 0; i < baseExperiments.Experiments.Count; i++)
                    sensorVisualiser.ColorsForMinorGraphs.Add(MultipleGraphsCanvas.DefaultMinorGraphPen.Color);
            else
                CopyVisualiser(oldVisualiser, sensorVisualiser);

            nWidth.Value = GraphWidth;
            nHeight.Value = GraphHeight;
        }

        private void CopyVisualiser(SensorVisualiser oldVisualiser, SensorVisualiser newVisualiser)
        {
            newVisualiser.ColorOfDiffGraph = oldVisualiser.ColorOfDiffGraph;
            newVisualiser.ColorOfMainGraph = oldVisualiser.ColorOfMainGraph;
            newVisualiser.ColorsForMinorGraphs.AddRange(oldVisualiser.ColorsForMinorGraphs);
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
            if(ShouldDrawAllSensors)
            {
                DrawAllSensors();
                return;
            }

            sensorVisualisers = null;

            if(oldPictures.Count != 0)
            {
                flowLayoutPanel.Controls.Clear();
                flowLayoutPanel.Controls.AddRange(oldPictures.ToArray());
                oldPictures.Clear();
            }


            int indexOfMovement = 0; //there is just one movement in every experiment
            int indexOfSensor = cbSensorSelection.SelectedIndex;

            sensorVisualiser.ShowMainGraph = GetShowMeanGraph();
            sensorVisualiser.ShowDiffGraph = GetShowDiffGraph();

            if (indexOfMovement == -1 || indexOfSensor == -1)
                return;

            sensorVisualiser.DrawSensor(
                sensor: meanExperiment.Movements[indexOfMovement].Sensors[indexOfSensor], 
                minorSensors: ExtractSensors(indexOfMovement, indexOfSensor)
                );
        }

        bool GetShowMeanGraph() => !sensorVisualiser.IgnoredMinorGraphs.Exists(index => index == cbExperiments.Items.Count - 2); //one before last index belogs to mean
        bool GetShowDiffGraph() => !sensorVisualiser.IgnoredMinorGraphs.Exists(index => index == cbExperiments.Items.Count - 1); //last index belogs to diff graph;


        private void DrawAllSensors()
        {
            PrepareVisualisers();

            int indexOfMovement = 0; //there is just one movement in every experiment

            var showMeanGraph = GetShowMeanGraph();
            var showDiffGraph = GetShowDiffGraph();

            int i = 0;
            foreach(var vis in sensorVisualisers)
            {
                vis.ShowMainGraph = showMeanGraph;
                vis.ShowDiffGraph = showDiffGraph;

                vis.DrawSensor(
                    sensor: meanExperiment.Movements[indexOfMovement].Sensors[i],
                    minorSensors: ExtractSensors(indexOfMovement, indexOfSensor: i)
                    );
                i++;
            }
        }

        private void PrepareVisualisers()
        {
            flowLayoutPanel.Controls.Clear();
            sensorVisualisers = new List<SensorVisualiser>();

            for (int i = 0; i < baseExperiments.Experiments[0].Movements[0].Sensors.Count; i++)
                sensorVisualisers.Add(new SensorVisualiser(flowLayoutPanel, GraphWidth, GraphHeight, EnvelopWinSize_sec));

            foreach (var vis in sensorVisualisers)
                CopyVisualiser(oldVisualiser: sensorVisualiser, newVisualiser: vis);
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

            if (cbExperiments.SelectedIndex == cbExperiments.Items.Count - 2)
                sensorVisualiser.ColorOfMainGraph = colorDialog1.Color;
            else if (cbExperiments.SelectedIndex == cbExperiments.Items.Count - 1)
                sensorVisualiser.ColorOfDiffGraph = colorDialog1.Color;
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

        private void cbChangeColor_Resize(object sender, EventArgs e)
        {
            if (ClientSize.Height == 0 && ClientSize.Width == 0)
                return;

            AdjustFLowLayoutPanel();

            if (flowLayoutPanel.Controls.Count != 4)
                return;

            if(sensorVisualiser != null)
            {
                CreateOrRefreshSensorVisualiser();
                RefreshGraphs();
            }
        }

        private void AdjustFLowLayoutPanel()
        {
            var padding = 17;

            int newHeigth = ClientSize.Height - flowLayoutPanel.Location.Y - padding;
            int newWidth = ClientSize.Width - flowLayoutPanel.Location.X - padding;

            flowLayoutPanel.Size = new Size(width: newWidth, height: newHeigth);
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            CreateOrRefreshSensorVisualiser();
            RefreshGraphs();
        }

        private void cbAutosize_CheckedChanged(object sender, EventArgs e)
        {
            nWidth.Enabled = nHeight.Enabled = !cbAutosize.Checked;
        }

        private void bExportInOne_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            int gap = 10;

            int width = flowLayoutPanel.Controls[0].Width;
            int height = flowLayoutPanel.Controls[0].Height + gap;

            Bitmap result = new Bitmap(width, height * flowLayoutPanel.Controls.Count - gap);

            using (Graphics g = Graphics.FromImage(result))
            {
                for (int i = 0; i < flowLayoutPanel.Controls.Count; i++)
                {
                    var graphPicture = ((PictureBox)flowLayoutPanel.Controls[i]).Image;
                    g.DrawImage(graphPicture, 0, i * height);
                }
            }

            result.Save(saveFileDialog1.FileName, ImageFormat.Png);
        }
    }
}
