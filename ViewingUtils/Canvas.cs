using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TringoModel.DataSructures.Interval;
using TringoModel.DataSructures;

namespace ViewingUtils
{
    public class Canvas
    {
        public Bitmap BitmapImage { get; private set; }

        public void SetImage(Bitmap newBitmap)
        {
            BitmapImage = newBitmap;
            graphDrawer = new GraphDrawer(newBitmap);
            graphics = Graphics.FromImage(newBitmap);
        }

        public IEnumerable<double> Borders { get; set; } = new List<double>();

        public IEnumerable<Interval> MovementsIntervals { get; set; } = new List<Interval>();

        public IGraph Graph { get; set; }

        public Scale Scale { get; set; }
        public bool AutoscaleGraph { get; set; } = true;

        private GraphDrawer graphDrawer;
        private Graphics graphics;

        public Pen BordersPen { get; set; }
        public Pen GraphPen { get; set; }
        public Pen IntervalsPen { get; set; }
        public Pen GridPen { get; set; } = Pens.Gray;

        public void RefreshAllComponents()
        {
            ClearImage();
            DrawGrid();

            DrawGraph();
            DrawBorders();
            DrawIntervals();
        }

        private void DrawGraph()
        {
            if (AutoscaleGraph)
                graphDrawer.DrawGraphAutoscale(Graph);
            else
            {
                graphDrawer.Scale = Scale;
                graphDrawer.DrawGraph(Graph);
            }
        }

        private void DrawBorders()
        {
            foreach (var line in GetBordersLines())
                graphics.DrawLine(BordersPen, line.From, line.To);
        }

        private IEnumerable<LinePoints> GetBordersLines()
        {
            foreach (var border in Borders)
            {
                int Xcoor = GetXcoorForTime(border);

                Point A = new Point(Xcoor, y: 0);
                Point B = new Point(Xcoor, y: BitmapImage.Height - 1);

                yield return new LinePoints(A, B);
            }
        }

        private void DrawIntervals()
        {
            foreach (var line in GetIntervalsLines())
                graphics.DrawLine(IntervalsPen, line.From, line.To);
        }

        private int YcoorForInterval { get; } = 1;

        private IEnumerable<LinePoints> GetIntervalsLines()
        {
            foreach (var interval in MovementsIntervals)
            {
                int XcoorFrom = GetXcoorForTime(interval.From);
                int XcoorTo = GetXcoorForTime(interval.To);

                Point A = new Point(XcoorFrom, YcoorForInterval);
                Point B = new Point(XcoorTo, YcoorForInterval);

                yield return new LinePoints(A, B);
            }
        }

        public void RefreshBorders()
        {
            RefreshAllComponents(); //TODO implement this
            return;
            throw new NotImplementedException();
        }

        public void RefreshIntervals()
        {
            RefreshAllComponents(); //TODO implement this
            return;
            throw new NotImplementedException();
        }

        private int GetXcoorForTime(double time)
            => (int)(BitmapImage.Width * (time / Graph.Length));

        private void ClearImage()
        {
            graphics.FillRectangle(
                Brushes.White, 
                x: 0, y:0 , 
                width: BitmapImage.Width, height: BitmapImage.Width
                );
        }

        private void DrawGrid()
        {
            foreach (var gridLine in GetGridLines())
                graphics.DrawLine(GridPen, gridLine.From, gridLine.To);
        }

        private IEnumerable<LinePoints> GetGridLines()
        {
            for (int i = 0; i < Graph.Length; i++)
                yield return new LinePoints(
                    new Point(x: GetXcoorForTime(i), y:0),
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
