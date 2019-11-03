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
using TringoModel.DataSructures.DataCache;
using Tringo.TestGraphs;
using TringoModel.DataProcessing.Mean;
using DataLoading;
using System.IO;
using TringoModel.DataSructures.Interval;
using MovementsCreation;

namespace Tringo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Canvas testCanvas; 

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MovementCreatorForm movementCreatorForm = new MovementCreatorForm();
            movementCreatorForm.ShowDialog();
            return;

            PictureBox testPictureBox = new PictureBox();
            testPictureBox.Height = flowLayoutPanel1.Height - 40;
            testPictureBox.Width = 20*flowLayoutPanel1.Width;

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(testPictureBox);

            testCanvas = new Canvas(testPictureBox);
            
            
            StreamReader input = new StreamReader(@"C:\Users\matya\Desktop\test_vse.csv");
            TextDataLoadingManager manager = new TextDataLoadingManager(input);
            ISetOfSensors result = manager.LoadSensors();
            
            
            GraphInterval smallerGraph = new GraphInterval(result.Sensors[4].EMG, new Interval(0,20));
            
            testCanvas.DrawGraphAutoscale(smallerGraph);
            
            return;

            IGraph sin0 = new SinGraph();
            IGraph sin1 = new SinGraph(shift: 1, scale: 1.50);
            IGraph sin2 = new SinGraph(shift: 1.4, scale: 0.75);
            IGraph sin3 = new SinGraph(shift: 2, scale: 0.68);
            IGraph sin4 = new SinGraph(shift: 5, scale: 0.90);
            IGraph sin5 = new SinGraph(shift: 2.5, scale: 0.30);

            List<IGraph> graphs = new List<IGraph>
            {
                sin0,sin1,sin2,sin3,sin4,sin5
            };



            testCanvas.DrawGraphAutoscale(sin0);

            testCanvas.DrawGraph(sin1);
            testCanvas.DrawGraph(sin2);
            testCanvas.DrawGraph(sin3);
            testCanvas.DrawGraph(sin4);
            testCanvas.DrawGraph(sin5);

            MeanGraph mg = new MeanGraph(graphs);

            testCanvas.GraphColor = Color.Green;
            testCanvas.DrawGraph(mg);
        }
    }
}
