using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TringoModel.DataSructures;
using System.Drawing;
using ViewingUtils;
using System.Xml.Schema;
using TringoModel.DataProcessing.Arithmetics;
using TringoLib.DataProcessing.Arithmetics;
using TringoLib.DataProcessing;

namespace ViewingUtils.Canvases
{
    public class MultipleGraphsCanvas : GraphCanvas
    {
        public MultipleGraphsCanvas(PictureBox pictureBox) : base(pictureBox) 
        {
            envelopeDrawer = new EnvelopeDrawer(BitmapImage);
        }

        public IEnumerable<IGraph> MinorGraphs { get; set; } = new List<IGraph>();

        public Pen MinorGraphsPen { get; set; } = DefaultMinorGraphPen;
        
        public static Pen DefaultMinorGraphPen { get; } = new Pen(Color.FromArgb(40, 40, 40));

        public Pen DiffGraphPen { get; set; } = DefaultDiffGraphPen;
        public static Pen DefaultDiffGraphPen { get; set; } = new Pen(Color.Aqua);

        public string GraphLabel { get; set; }

        public bool DrawEnvelopes { get; set; } = false;
        public double EnvelopWinSize { get; set; }

        public override void RefreshAllComponents()
        {
            if (AutoscaleGraph)
            {
                var scale = GetScale();
                envelopeDrawer.Scale = scale;
                graphDrawer.Scale = scale;
            }

            ClearImage();
            DrawGrid();

            if(GraphLabel != null)
                DrawLabel(GraphLabel);

            if (DrawEnvelopes)
                RenderMinorEnvelopes();
            else
                RenderMinorGraphs();

            DrawDiffGraph();

            if (DrawMainGraph)
            {
                graphDrawer.GraphPen = GraphPen;
                envelopeDrawer.EnvelopPen = GraphPen;

                if (DrawEnvelopes)
                    envelopeDrawer.DrawEnvelop(Graph, EnvelopWinSize);
                else
                    graphDrawer.DrawGraph(Graph);
            }

            PictureBox.Refresh();  
        }

        private List<EnvelopeGraph> envelopeGraphs = new List<EnvelopeGraph>();

        private void RenderMinorEnvelopes()
        {
            envelopeGraphs.Clear();

            foreach (var mGraphAndPen in MinorGraphsToBeDrawnAndItsPen)
            {
                envelopeDrawer.EnvelopPen = mGraphAndPen.Item2;
                var usedEnvelopGraph = envelopeDrawer.DrawEnvelop(mGraphAndPen.Item1, EnvelopWinSize);
                envelopeGraphs.Add(usedEnvelopGraph);
            }
        }

        public List<Color> ColorsForMinorGraphs { get; set; }
        public List<int> IgnoredMinorGraphs { get; set; }

        private void RenderMinorGraphs()
        {
            foreach (var mGraphAndPen in MinorGraphsToBeDrawnAndItsPen)
            {
                graphDrawer.GraphPen = mGraphAndPen.Item2;
                graphDrawer.DrawGraph(mGraphAndPen.Item1);
            }
        }

        private IEnumerable<(IGraph, Pen)> MinorGraphsToBeDrawnAndItsPen
        {
            get
            {
                int i = -1;

                foreach (var mGraph in MinorGraphs)
                {
                    i++;
                    if (IgnoredMinorGraphs != null && IgnoredMinorGraphs.Exists(index => index == i))
                        continue;

                    yield return (mGraph, GetNextPen(i));
                }
            }
        }

        public bool DrawMainGraph { get; set; } = true;
        public bool DrawDiffGraphIfPossible { get; set; } = true;

        private Scale GetScale()
        {
            double freq = PictureBox.Width / Graph.Length;

            List<Scale> allScales = new List<Scale>();
            foreach (var g in MinorGraphs)
                allScales.Add(g.GetScale(freq)); //TODO maybe delete graphs which wont be drawn

            if (DrawMainGraph)
                allScales.Add(Graph.GetScale(freq));

            double maxValue = (from s in allScales select s.MaxValue).Max();
            double minValue = (from s in allScales select s.MinValue).Min();

            double zeroDelta = (maxValue - minValue) * 0.1;

            return new Scale(
                MaxValue: Math.Max(0 + zeroDelta, maxValue),
                MinValue: Math.Min(0 - zeroDelta, minValue)
            );
        }

        private Pen GetNextPen(int indexOfMinorGraph)
        {
            if (ColorsForMinorGraphs == null || indexOfMinorGraph >= ColorsForMinorGraphs.Count)
                return MinorGraphsPen;

            return new Pen(ColorsForMinorGraphs[indexOfMinorGraph]);

        }

        private void DrawDiffGraph()
        {
            if (!CanDrawDiffGraph()) 
                return;

            var saveScale = graphDrawer.Scale;
            graphDrawer.Scale = GetScaleForDiffGraph();

            var diffGraph = GetDiffGraph();

            graphDrawer.GraphPen = DiffGraphPen;
            graphDrawer.DrawGraph(diffGraph);

            graphDrawer.Scale = saveScale;
        }

        private bool CanDrawDiffGraph()
         => DrawDiffGraphIfPossible && MinorGraphsToBeDrawnAndItsPen.Count() == 2;

        private Scale GetScaleForDiffGraph()
        {
            var zeroDelta = (Scale.MaxValue - Scale.MinValue) * 0.05;

            return new Scale(
                MaxValue: Scale.MaxValue - Scale.MinValue - zeroDelta,
                MinValue: 0 - zeroDelta);
        }

        private IGraph GetDiffGraph()
        {
            List<IGraph> graphs;

            if (DrawEnvelopes)
                graphs = envelopeGraphs.Select(e => e.GetAreaSumsGraph()).ToList();
            else
                graphs = MinorGraphsToBeDrawnAndItsPen.Select(g => g.Item1).ToList();

            return new TransformedGraph(
                baseGraph: new DifferenceGraph(graphs[0], graphs[1]),
                transformFunc: Math.Abs);
        }
    }
}
