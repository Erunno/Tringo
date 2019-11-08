using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TringoModel.DataSructures;
using System.Windows.Forms;
using TringoModel.DataSructures.Interval;
using System.Collections;

namespace ViewingUtils.Canvases
{
    public class SensorCanvas<Canvas> where Canvas : GraphCanvas
    {
        public SensorCanvas(IPictureBoxes pictureBoxes, CanvasProvider<Canvas> canvasProvider)
        {
            this.pictureBoxes = pictureBoxes;
            this.canvasProvider = canvasProvider;

            CreateCanvases();
        }

        public ICanvases<Canvas> GraphCanvases { get; private set; }
        IPictureBoxes pictureBoxes;
        CanvasProvider<Canvas> canvasProvider;

        public void CreateCanvases()
        {
            Canvases<Canvas> canvases = new Canvases<Canvas>();

            canvases.EMG = canvasProvider(pictureBoxes.EMG);
            canvases.X = canvasProvider(pictureBoxes.X);
            canvases.Y = canvasProvider(pictureBoxes.Y);
            canvases.Z = canvasProvider(pictureBoxes.Z);

            this.GraphCanvases = canvases;
        }

        public void SetImage(Size sizeOfNewBitmap)
        {
            foreach (var canvas in GraphCanvases)
                canvas.SetImage(sizeOfNewBitmap);
        }

        public ISensor Sensor { get; set; }

        public bool AutoscaleGraphs { get; set; } = true;

        virtual public void RefreshAllSubgraphs()
        {
            SetRightGraphsToCanvases();
            SetAutoscaleFlagToEachCanvas();
            RefreshAllCanvases();
        }

        private void SetRightGraphsToCanvases()
        {
            GraphCanvases.EMG.Graph = Sensor.EMG;
            GraphCanvases.X.Graph = Sensor.X;
            GraphCanvases.Y.Graph = Sensor.Y;
            GraphCanvases.Z.Graph = Sensor.Z;
        }

        private void SetAutoscaleFlagToEachCanvas()
        {
            foreach (var canvas in GraphCanvases)
                canvas.AutoscaleGraph = AutoscaleGraphs;
        }

        private void RefreshAllCanvases()
        {
            foreach (var canvas in GraphCanvases)
                canvas.RefreshAllComponents();
        }

    }

    public interface ICanvases<Canvas> : IEnumerable<Canvas> where Canvas : GraphCanvas
    {
        Canvas EMG { get; }
        Canvas X { get; }
        Canvas Y { get; }
        Canvas Z { get; }
    }

    class Canvases<Canvas> : ICanvases<Canvas> where Canvas : GraphCanvas
    {
        public Canvas EMG { get; set; }
        public Canvas X { get; set; }
        public Canvas Y { get; set; }
        public Canvas Z { get; set; }

        public IEnumerator<Canvas> GetEnumerator()
        {
            yield return EMG;
            yield return X;
            yield return Y;
            yield return Z;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public interface IPictureBoxes
    {
        PictureBox EMG { get; }
        PictureBox X { get; }
        PictureBox Y { get; }
        PictureBox Z { get; }
    }


    public class SimplePictureBoxes : IPictureBoxes
    {
        public PictureBox EMG { get; set; }

        public PictureBox X { get; set; }
        public PictureBox Y { get; set; }
        public PictureBox Z { get; set; }
    }
}
