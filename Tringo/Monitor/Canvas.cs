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
            baseBitmap = GetBaseBitmap();
        }

        Bitmap baseBitmap;
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
            double step = GetSizeOfOneStep(graph);

            for (int i = 0; i < pictureBox.Width; i++)
            {
                int Ycoor = GetYPixel(graph[step * i]);

                if (IsInScale(Ycoor))
                    baseBitmap.SetPixel(x: i, y: Ycoor, GraphColor);
            }

            pictureBox.Image = baseBitmap;
            pictureBox.Refresh();
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
