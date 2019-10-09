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

        public Color GraphColor { get; set; } = Color.Red;

        public Canvas(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
        }

        public void DrawGraphWithAutoscale(IGraph graph)
        {
            double freq = 1 / GetSizeOfOneStep(graph);
            double correction = 0.01;

            CachedGraph cachedGraph = new CachedGraph(graph,freq); //TODO decide whether cache graph
            Scale scale = new Scale(
                MaxValue: cachedGraph.MaxValue * (1 + correction), 
                MinValue: cachedGraph.MinValue * (1 + correction)
                );

            DrawGraph(cachedGraph, scale);
        }

        public void DrawGraph(IGraph graph, Scale rangeOfPicture)
        {
            double step = GetSizeOfOneStep(graph);

            Bitmap bitmap = GetBaseBitmap();

            for (int i = 0; i < pictureBox.Width; i++)
            {
                int Ycoor = GetYPixel(graph[step * i], rangeOfPicture);

                if (0 <= Ycoor && Ycoor < pictureBox.Height)
                    bitmap.SetPixel(x: i, y: Ycoor, GraphColor);
            }

            pictureBox.Image = bitmap;
            pictureBox.Refresh();
        }

        private int GetYPixel(double valueInX, Scale scale)
            => pictureBox.Height - (int)((valueInX - scale.MinValue) / scale.Size * pictureBox.Height);

        private double GetSizeOfOneStep(IGraph graph)
            => graph.Length / pictureBox.Width;

        private Bitmap GetBaseBitmap()
            => new Bitmap(width: pictureBox.Width, height: pictureBox.Height);
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
