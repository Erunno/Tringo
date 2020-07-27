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
    class SensorVisualiser
    {
        public SensorVisualiser(FlowLayoutPanel basePanel, int widthOfGraphs)
        {
            width = widthOfGraphs;

            EMG = new MultipleGraphsCanvas(GetPictureBox(basePanel));
            EMG.ColorsForMinorGraphs = ColorsForMinorGraphs;
            EMG.IgnoredMinorGraphs = IgnoredMinorGraphs;
            
            X = new MultipleGraphsCanvas(GetPictureBox(basePanel));
            X.ColorsForMinorGraphs = ColorsForMinorGraphs;
            X.IgnoredMinorGraphs = IgnoredMinorGraphs;

            Y = new MultipleGraphsCanvas(GetPictureBox(basePanel));
            Y.ColorsForMinorGraphs = ColorsForMinorGraphs;
            Y.IgnoredMinorGraphs = IgnoredMinorGraphs;

            Z = new MultipleGraphsCanvas(GetPictureBox(basePanel));
            Z.ColorsForMinorGraphs = ColorsForMinorGraphs;
            Z.IgnoredMinorGraphs = IgnoredMinorGraphs;
        }

        private PictureBox GetPictureBox(FlowLayoutPanel basePanel)
        {
            PictureBox pb = new PictureBox();
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            pb.Width = width;
            pb.Height = basePanel.Height / 4 - 2;
            
            basePanel.Controls.Add(pb);

            return pb;
        }

        private int width { get; }

        MultipleGraphsCanvas EMG;
        MultipleGraphsCanvas X;
        MultipleGraphsCanvas Y;
        MultipleGraphsCanvas Z;

        public Color ColorOfMainGraph
        {
            get => EMG.GraphPen.Color;
            set
            {
                Pen p = new Pen(value);

                EMG.GraphPen = p;
                X.GraphPen = p;
                Y.GraphPen = p;
                Z.GraphPen = p;
            }
        }

        public bool ShowMainGraph { 
            get => EMG.DrawMainGraph;
            set {
                EMG.DrawMainGraph = value;
                X.DrawMainGraph = value;
                Y.DrawMainGraph = value;
                Z.DrawMainGraph = value;
            }
        }

        public List<Color> ColorsForMinorGraphs { get; } = new List<Color>();
        public List<int> IgnoredMinorGraphs { get; } = new List<int>();
        public void DrawSensor(ISensor sensor, IEnumerable<ISensor> minorSensors)
        {
            DrawGraph(EMG, sensor.EMG, ExtractMinorGraphs(minorSensors, s => s.EMG));
            DrawGraph(X, sensor.X, ExtractMinorGraphs(minorSensors, s => s.X));
            DrawGraph(Y, sensor.Y, ExtractMinorGraphs(minorSensors, s => s.Y));
            DrawGraph(Z, sensor.Z, ExtractMinorGraphs(minorSensors, s => s.Z));
        }

        private void DrawGraph(MultipleGraphsCanvas canvas, IGraph graph, IEnumerable<IGraph> minorGraphs)
        {
            canvas.Graph = graph;
            canvas.MinorGraphs = minorGraphs;

            canvas.RefreshAllComponents();
        }

        private IEnumerable<IGraph> ExtractMinorGraphs(IEnumerable<ISensor> sensors, Func<ISensor, IGraph> graphProvider)
        {
            foreach (var sensor in sensors)
                yield return graphProvider(sensor);
        }

    }
}
