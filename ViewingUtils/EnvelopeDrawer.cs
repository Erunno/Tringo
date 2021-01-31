using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TringoLib.DataProcessing;
using TringoModel.DataSructures;

namespace ViewingUtils
{
    public class EnvelopeDrawer
    {
        private readonly Bitmap bitmap;
        private Graphics graphics;

        public Pen EnvelopPen { get; set; }
        public Scale Scale { get; set; }

        public EnvelopeDrawer(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            graphics = Graphics.FromImage(bitmap);
        }


        public EnvelopeGraph DrawEnvelop(IGraph graph, double windowsSize)
        {
            var samplingPeriod = graph.Length / bitmap.Width;
            var envelop = new EnvelopeGraph(graph, windowsSize, samplingPeriod);
            DrawEnvelop(envelop);

            return envelop;
        }

        public void DrawEnvelop(EnvelopeGraph envelop)
        {
            var points = GetPoints(envelop);
            var brush = new SolidBrush(Color.FromArgb(alpha: 100, EnvelopPen.Color));
            
            graphics.FillPolygon(brush, points);
            graphics.DrawPolygon(EnvelopPen, points);
        }

        private PointF[] GetPoints(EnvelopeGraph envelop)
            => (from vert in envelop.Upper.Concat(envelop.LowerReverse)
                select new PointF()
                {
                    X = (float)GetXCoor(envelop.Length, vert.Time),
                    Y = Scale.GetYCoorForValue(vert.Value, bitmap.Height)
                })
                .ToArray();


        private double GetXCoor(double graphLenght, double time)
            => bitmap.Width * time / graphLenght;

    }
}
