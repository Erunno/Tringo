using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;
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

        public void DrawGraph(IGraph graph, Range rangeOfPicture)
        {
            double step = GetSizeOfOneStep(graph);

            Bitmap bitmap = GetBaseBitmap();
            Graphics graphics = Graphics.FromImage(bitmap);


            Point lastPoint = new Point();

            for (int i = 0; i < pictureBox.Width; i++)
            {
                int Ycoor = GetYPixel(graph[step * i], rangeOfPicture);

                if (0 < Ycoor && Ycoor < pictureBox.Height)
                    bitmap.SetPixel(x: i, y: Ycoor, GraphColor); 
            }

            pictureBox.Image = bitmap;
            pictureBox.Refresh();
        }

        private int GetYPixel(double valueInX, Range range)
            => pictureBox.Height - (int)((valueInX - range.MinValue) / range.Size * pictureBox.Height);

        private double GetSizeOfOneStep(IGraph graph)
            => graph.Length / pictureBox.Width;

        private Bitmap GetBaseBitmap()
            => new Bitmap(width: pictureBox.Width, height: pictureBox.Height);
    }

    class Range
    {
        public double MaxValue { get; }
        public double MinValue { get; }

        public double Size { get; }

        public Range(double MaxValue, double MinValue)
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
