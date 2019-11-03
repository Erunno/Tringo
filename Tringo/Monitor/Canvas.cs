using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;
using TringoModel.DataSructures.DataCache;
using System.Drawing;
using System.Windows.Forms;


namespace Tringo.Monitor
{
    class Canvas
    {
        private PictureBox pictureBox { get; }
        Graphics graphics { get; }

        public Color GraphColor { get; set; } = Color.Red;

        public Canvas(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            baseBitmap = GetBaseBitmap();
            pictureBox.Image = baseBitmap;
            
            graphics = Graphics.FromImage(baseBitmap);
        }

        Bitmap baseBitmap { get; }
        public Scale Scale { get; set; }


        public void DrawGraphAutoscale(IGraph graph)
        {
            double freq = 1 / GetSizeOfOneStep(graph);
            double correction = 0.01;

            CachedGraph cachedGraph = new CachedGraph(graph,freq); //TODO decide whether cache graph
            Scale = new Scale(
                MaxValue: cachedGraph.MaxValue * (1 + correction), 
                MinValue: cachedGraph.MinValue * (1 + correction)
                );

            DrawGraph(cachedGraph);
        }

        public void DrawGraph(IGraph graph)
        {
            Brush b = new SolidBrush(GraphColor);
            Pen pen = new Pen(b);
            
            Point lastPoint = new Point(0, 0);

            var allPoints = GetPoints(graph);
            lastPoint = allPoints.First();

            foreach (var point in allPoints)
            {
                graphics.DrawLine(pen, lastPoint, point);
                lastPoint = point;
            }
        }

        private IEnumerable<Point> GetPoints(IGraph graph)
        {
            double step = GetSizeOfOneStep(graph);

            for (int Xcoor = 0; Xcoor < pictureBox.Width; Xcoor++)
                yield return new Point(Xcoor, GetYPixel(graph[step * Xcoor]));
        }

        private int GetYPixel(double valueInX)
            => pictureBox.Height - (int)((valueInX - Scale.MinValue) / Scale.Size * pictureBox.Height);

        private bool IsInScale(int Ycoor)
            => 0 <= Ycoor && Ycoor < pictureBox.Height;

        private double GetSizeOfOneStep(IGraph graph)
            => graph.Length / pictureBox.Width;

        private Bitmap GetBaseBitmap()
            => new Bitmap(width: pictureBox.Width, height: pictureBox.Height);


        public void Clear()
        {
            for (int x = 0; x < baseBitmap.Width; x++)
                for (int y = 0; y < baseBitmap.Height; y++)
                    baseBitmap.SetPixel(x, y, Color.Transparent);

            pictureBox.Refresh();
        }
    }

    class Scale
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
