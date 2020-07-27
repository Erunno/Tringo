using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TringoModel.DataSructures;
using System.Drawing;
using ViewingUtils;

namespace ViewingUtils.Canvases
{
    public class MultipleGraphsCanvas : GraphCanvas
    {
        public MultipleGraphsCanvas(PictureBox pictureBox) : base(pictureBox) { }

        public IEnumerable<IGraph> MinorGraphs { get; set; } = new List<IGraph>();

        public Pen MinorGraphsPen { get; set; } = DefaultMinorGraphPen;
        
        public static Pen DefaultMinorGraphPen { get; } = new Pen(Color.FromArgb(40, 40, 40));

        public override void RefreshAllComponents()
        {
            ClearImage();
            DrawGrid();

            if (AutoscaleGraph)
                Scale = GetScale();

            DrawMinorGraphs();

            if (DrawMainGraph)
            {
                graphDrawer.GraphPen = GraphPen;
                graphDrawer.DrawGraph(Graph);
            }

            PictureBox.Refresh();  
        }

        public List<Color> ColorsForMinorGraphs { get; set; }
        public List<int> IgnoredMinorGraphs { get; set; }

        private void DrawMinorGraphs()
        {
            int i = -1;

            foreach (var mGraph in MinorGraphs)
            {
                i++;
                if (IgnoredMinorGraphs != null && IgnoredMinorGraphs.Exists(index => index == i))
                    continue;

                graphDrawer.GraphPen = GetNextPen(i);
                graphDrawer.DrawGraph(mGraph);
            }
        }

        public bool DrawMainGraph { get; set; } = true;

        private Scale GetScale()
        {
            double freq = PictureBox.Width / Graph.Length;

            List<Scale> allScales = new List<Scale>();
            foreach (var g in MinorGraphs)
                allScales.Add(g.GetScale(freq)); //TODO maybe delete graphs which wont be drawn

            if (DrawMainGraph)
                allScales.Add(Graph.GetScale(freq));

            return new Scale(
                MaxValue: (from s in allScales select s.MaxValue).Max(), 
                MinValue: (from s in allScales select s.MinValue).Min()
                );
        }

        private Pen GetNextPen(int indexOfMinorGraph)
        {
            if (ColorsForMinorGraphs == null || indexOfMinorGraph >= ColorsForMinorGraphs.Count)
                return MinorGraphsPen;

            return new Pen(ColorsForMinorGraphs[indexOfMinorGraph]);

        }
    }
}
