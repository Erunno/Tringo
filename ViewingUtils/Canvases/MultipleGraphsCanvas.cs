using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TringoModel.DataSructures;
using System.Drawing;

namespace ViewingUtils.Canvases
{
    public class MultipleGraphsCanvas : GraphCanvas
    {
        public MultipleGraphsCanvas(PictureBox pictureBox) : base(pictureBox) { }

        public IEnumerable<IGraph> MinorGraphs { get; set; } = new List<IGraph>();

        public Pen MinorGraphsPen { get; set; } = new Pen(Color.FromArgb(40, 40, 40));
        

        public override void RefreshAllComponents()
        {
            ClearImage();
            DrawGrid();

            DrawGraph();
            DrawMinorGraphs();
            DrawGraph(); //TODO find better solution

            PictureBox.Refresh();
        }

        private void DrawMinorGraphs()
        {
            graphDrawer.GraphPen = MinorGraphsPen;

            foreach (var mGraph in MinorGraphs)
                graphDrawer.DrawGraph(mGraph);
        }
    }
}
