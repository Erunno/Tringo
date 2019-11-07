using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TringoModel.DataSructures;
using System.Windows.Forms;
using TringoModel.DataSructures.Interval;

namespace ViewingUtils.Canvases
{
    public class Canvas
    {
        public Canvas(PictureBox pictureBox)
        {
            PictureBoxOfImage = pictureBox;
        }

        public Bitmap BitmapImage { get; private set; }

        public PictureBox PictureBoxOfImage { get; }

        public void SetImage(Bitmap newBitmap)
        {
            BitmapImage = newBitmap;
            graphDrawer = new GraphDrawer(newBitmap);
            graphics = Graphics.FromImage(newBitmap);

            PictureBoxOfImage.Image = newBitmap;
        }

        public void SetImage(Size sizeOfNewBitmap)
            => SetImage(new Bitmap(width: sizeOfNewBitmap.Width, height: sizeOfNewBitmap.Height));

        public IGraph Graph { get; set; }

        public Scale Scale { get; set; }
        public bool AutoscaleGraph { get; set; } = true;

        protected GraphDrawer graphDrawer;
        protected Graphics graphics;

        public Pen BordersPen { get; set; } = new Pen(Color.FromArgb(0, 255, 0));
        public Pen GraphPen { get; set; } = new Pen(Color.FromArgb(255, 51, 51));
        public Brush IntervalsBrush { get; set; } = new SolidBrush(Color.FromArgb(25, 0, 0, 255));
        public Pen GridPen { get; set; } = new Pen(Color.FromArgb(25, 25, 25));

        public Brush BackgroudBrush { get; set; } = new SolidBrush(Color.FromArgb(20, 20, 20));

        virtual public void RefreshAllComponents()
        {
            ClearImage();
            DrawGrid();

            DrawGraph();

            PictureBoxOfImage.Refresh();
        }

        protected void DrawGraph()
        {
            graphDrawer.GraphPen = GraphPen;

            if (AutoscaleGraph)
                graphDrawer.DrawGraphAutoscale(Graph);
            else
            {
                graphDrawer.Scale = Scale;
                graphDrawer.DrawGraph(Graph);
            }
        }

        protected int GetXcoorForTime(double time)
            => (int)(BitmapImage.Width * (time / Graph.Length));

        protected void ClearImage()
        {
            graphics.FillRectangle(
                BackgroudBrush,
                x: 0, y: 0,
                width: BitmapImage.Width, height: BitmapImage.Width
                );
        }

        protected void DrawGrid()
        {
            foreach (var gridLine in GetGridLines())
                graphics.DrawLine(GridPen, gridLine.From, gridLine.To);
        }

        private IEnumerable<LinePoints> GetGridLines()
        {
            for (int i = 0; i < Graph.Length; i++)
                yield return new LinePoints(
                    new Point(x: GetXcoorForTime(i), y: 0),
                    new Point(x: GetXcoorForTime(i), y: BitmapImage.Height
                    ));
        }
    }

    struct LinePoints
    {
        public LinePoints(Point from, Point to)
        {
            From = from;
            To = to;
        }

        public Point From;
        public Point To;
    }
}
