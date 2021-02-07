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
        public SensorVisualiser(FlowLayoutPanel basePanel, int widthOfGraphs, int heigthOfgraphs, double envelopWinSizeSec)
        {
            width = widthOfGraphs;
            height = heigthOfgraphs;

            EMG = new MultipleGraphsCanvas(GetPictureBox(basePanel));
            EMG.ColorsForMinorGraphs = ColorsForMinorGraphs;
            EMG.IgnoredMinorGraphs = IgnoredMinorGraphs;
            EMG.DrawEnvelopes = true;
            EMG.EnvelopWinSize = envelopWinSizeSec;
            
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
            pb.Height = height; 
            
            basePanel.Controls.Add(pb);

            return pb;
        }

        private int width { get; }
        private int height { get; }

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

        public Color ColorOfDiffGraph
        {
            get => EMG.DiffGraphPen.Color;
            set
            {
                Pen p = new Pen(value);

                EMG.DiffGraphPen = p;
                X.DiffGraphPen = p;
                Y.DiffGraphPen = p;
                Z.DiffGraphPen = p;
            }
        }

        public Color BackGroundColor
        {
            get => EMG.BackgroudBrush.Color;
            set
            {
                SolidBrush b = new SolidBrush(value);

                EMG.BackgroudBrush = b;
                X.BackgroudBrush = b;
                Y.BackgroudBrush = b;
                Z.BackgroudBrush = b;
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

        public bool ShowDiffGraph
        {
            get => EMG.DrawDiffGraphIfPossible;
            set
            {
                EMG.DrawDiffGraphIfPossible = value;
                X.DrawDiffGraphIfPossible = value;
                Y.DrawDiffGraphIfPossible = value;
                Z.DrawDiffGraphIfPossible = value;
            }
        }

        public List<Color> ColorsForMinorGraphs { get; } = new List<Color>();
        public List<int> IgnoredMinorGraphs { get; } = new List<int>();
        public void DrawSensor(ISensor sensor, IEnumerable<ISensor> minorSensors)
        {
            DrawGraph(EMG, sensor.EMG, ExtractMinorGraphs(minorSensors, s => s.EMG), sensor.SensorInfo.Name + " - EMG");
            DrawGraph(X, sensor.X, ExtractMinorGraphs(minorSensors, s => s.X), sensor.SensorInfo.Name + " - X");
            DrawGraph(Y, sensor.Y, ExtractMinorGraphs(minorSensors, s => s.Y), sensor.SensorInfo.Name + " - Y");
            DrawGraph(Z, sensor.Z, ExtractMinorGraphs(minorSensors, s => s.Z), sensor.SensorInfo.Name + " - Z");
        }

        private void DrawGraph(MultipleGraphsCanvas canvas, IGraph graph, IEnumerable<IGraph> minorGraphs, string label)
        {
            canvas.Graph = graph;
            canvas.MinorGraphs = minorGraphs;

            canvas.GraphLabel = label;

            canvas.RefreshAllComponents();
            canvas.GraphLabel = null;
        }

        private IEnumerable<IGraph> ExtractMinorGraphs(IEnumerable<ISensor> sensors, Func<ISensor, IGraph> graphProvider)
        {
            foreach (var sensor in sensors)
                yield return graphProvider(sensor);
        }

    }
}
