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
    public class GraphCanvas
    {
        public GraphCanvas(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
            SetImage(pictureBox.Size);
        }

        public Bitmap BitmapImage { get; private set; }

        public PictureBox PictureBox { get; }

        public void SetImage(Bitmap newBitmap)
        {
            BitmapImage = newBitmap;
            graphDrawer = new GraphDrawer(newBitmap);
            graphics = Graphics.FromImage(newBitmap);

            PictureBox.Image = newBitmap;
        }

        public void SetImage(Size sizeOfNewBitmap)
            => SetImage(new Bitmap(width: sizeOfNewBitmap.Width, height: sizeOfNewBitmap.Height));

        public IGraph Graph { get; set; }

        public Scale Scale { get => graphDrawer.Scale; set => graphDrawer.Scale = value; }
        public bool AutoscaleGraph { get; set; } = true;

        protected GraphDrawer graphDrawer;
        protected Graphics graphics;

        public Pen BordersPen { get; set; } = DefaultBordersPen;
        public static Pen DefaultBordersPen { get; } = new Pen(Color.FromArgb(0, 255, 0));

        public Pen GraphPen { get; set; } = DefaultGraphPen;
        public static Pen DefaultGraphPen { get; } = new Pen(Color.FromArgb(255, 51, 51));

        public Brush IntervalsBrush { get; set; } = DefaultIntervalsBrush;
        public static Brush DefaultIntervalsBrush { get; } = new SolidBrush(Color.FromArgb(25, 0, 0, 255));

        public Pen GridPen { get; set; } = DefaultGridPen;
        public static Pen DefaultGridPen { get; } = new Pen(Color.FromArgb(50, 50, 50));

        public Pen ZeroLinePen { get; set; } = DefaultZeroLinePen;
        public static Pen DefaultZeroLinePen { get; } = new Pen(Color.FromArgb(180, 180, 180));

        public Brush BackgroudBrush { get; set; } = DefaultBackgroudBrush;
        public static Brush DefaultBackgroudBrush { get; } = new SolidBrush(Color.FromArgb(20, 20, 20));


        virtual public void RefreshAllComponents()
        {
            ClearImage();
            DrawGrid();

            DrawGraph();

            PictureBox.Refresh();
        }

        protected void DrawGraph()
        {
            graphDrawer.GraphPen = GraphPen;

            if (AutoscaleGraph)
                graphDrawer.DrawGraphAutoscale(Graph);
            else
                graphDrawer.DrawGraph(Graph);
        }

        protected void DrawLabel(string label)
        {
            graphics.DrawString(
                label, 
                new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                Brushes.White,
                10, 10);
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
            //vertical line
            foreach (var gridLine in GetGridLines())
                graphics.DrawLine(GridPen, gridLine.From, gridLine.To);
            
            //horizontal zero line
            int YcoorOfZero = Scale.GetYCoorForValue(value: 0, BitmapImage.Height);
            graphics.DrawLine(ZeroLinePen, 
                new Point(x: 0, y: YcoorOfZero), 
                new Point(x: BitmapImage.Width - 1, y: YcoorOfZero)
                );
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
