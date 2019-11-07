using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TringoModel.DataSructures;
using TringoModel.DataSructures.DataCache;

namespace ViewingUtils
{
    public class GraphDrawer
    {
        Graphics graphics { get; }

        public Pen GraphPen { get; set; } = Pens.Red;

        public GraphDrawer(Bitmap image)
        {
            baseBitmap = image;
            graphics = Graphics.FromImage(baseBitmap);
        }

        Bitmap baseBitmap { get; }
        public Scale Scale { get; set; }


        public void DrawGraphAutoscale(IGraph graph)
        {
            double freq = 1 / GetSizeOfOneStep(graph);
            double correction = 0.01;

            CachedGraph cachedGraph = new CachedGraph(graph, freq); //TODO decide whether cache graph
            Scale = new Scale(
                MaxValue: cachedGraph.MaxValue * (1 + correction),
                MinValue: cachedGraph.MinValue * (1 + correction)
                );

            DrawGraph(cachedGraph);
        }

        public void DrawGraph(IGraph graph)
        {
            var allPoints = GetPoints(graph);
            Point lastPoint = allPoints.First();

            foreach (var point in allPoints)
            {
                graphics.DrawLine(GraphPen, lastPoint, point);
                lastPoint = point;
            }
        }

        private IEnumerable<Point> GetPoints(IGraph graph)
        {
            double step = GetSizeOfOneStep(graph);

            for (int Xcoor = 0; Xcoor < baseBitmap.Width; Xcoor++)
                yield return new Point(Xcoor, GetYPixel(graph[step * Xcoor]));
        }

        private int GetYPixel(double valueInX)
            => baseBitmap.Height - (int)((valueInX - Scale.MinValue) / Scale.Size * baseBitmap.Height);

        private bool IsInScale(int Ycoor)
            => 0 <= Ycoor && Ycoor < baseBitmap.Height;

        private double GetSizeOfOneStep(IGraph graph)
            => graph.Length / baseBitmap.Width;
    }

    public class Scale
    {
        public double MaxValue { get; }
        public double MinValue { get; }

        public double Size { get; }

        public Scale(double MaxValue, double MinValue)
        {
            if (MaxValue < MinValue)
                throw new UnvalidRangeException();

            this.MaxValue = MaxValue;
            this.MinValue = MinValue;

            Size = MaxValue - MinValue;
        }
    }

    class UnvalidRangeException : Exception { }
}
