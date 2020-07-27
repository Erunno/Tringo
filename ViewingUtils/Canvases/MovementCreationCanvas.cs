using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TringoModel.DataSructures.Interval;
using TringoModel.DataSructures;
using System.Windows.Forms;
using ViewingUtils;

namespace ViewingUtils.Canvases
{
    public class MovementCreationCanvas : GraphCanvas
    {
        public MovementCreationCanvas(PictureBox pictureBox) : base(pictureBox) { }

        public IEnumerable<double> Borders { get; set; } = new List<double>();

        public IEnumerable<Interval> MovementsIntervals { get; set; } = new List<Interval>();

        public override void RefreshAllComponents()
        {
            ClearImage();

            graphDrawer.ComputeScaleForGraph(Graph);

            DrawGrid();
            DrawIntervals();
            DrawBorders();
            DrawGraph();

            PictureBox?.Refresh();
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
            foreach (var rect in GetIntervalsRectangles())
                graphics.FillRectangle(IntervalsBrush, rect);
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

        private IEnumerable<Rectangle> GetIntervalsRectangles()
        {
            foreach (var interval in MovementsIntervals)
            {
                int XcoorFrom = GetXcoorForTime(interval.From);
                int XcoorTo = GetXcoorForTime(interval.To);

                Rectangle rect = new Rectangle(
                    x: XcoorFrom,
                    y: 0,
                    width: XcoorTo - XcoorFrom,
                    height: BitmapImage.Height
                    );

                yield return rect;
            }
        }

        public void RefreshBorders()
        {
            RefreshAllComponents(); //TODO implement this
        }

        public void RefreshIntervals()
        {
            RefreshAllComponents(); //TODO implement this
        }
    }
}
