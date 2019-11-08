using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TringoModel.DataSructures;
using System.Drawing;
using ViewingUtils.Canvases;

namespace ViewingUtils
{
    public class BaseFormBuilder<Canvas> where Canvas : GraphCanvas
    {
        public BaseFormBuilder(IList<ISensor> sensors, FlowLayoutPanel flowLayoutPanel, ComboBox comboBox, CanvasProvider<Canvas> canvasProvider)
        {
            this.sensors = sensors;
            components.ComboBox = comboBox;
            this.flowLayoutPanel = flowLayoutPanel;
            this.canvasProvider = canvasProvider;
        }

        IList<ISensor> sensors;
        FlowLayoutPanel flowLayoutPanel;

        ComponentsContainer<Canvas> components = new ComponentsContainer<Canvas>();
        CanvasProvider<Canvas> canvasProvider;

        public ComponentsContainer<Canvas> GetInicializedComponents(int widthOfCanvas)
        {
            CreateSensorCanvas(widthOfCanvas);
            ConfigureFlowLayoutPanel();
            CreateComboBoxManager();

            return components;
        }

        private IPictureBoxes GetPictureBoxes()
        {
            SimplePictureBoxes simplePictureBoxes = new SimplePictureBoxes();

            simplePictureBoxes.EMG = GetNewPictureBox();
            simplePictureBoxes.X = GetNewPictureBox();
            simplePictureBoxes.Y = GetNewPictureBox();
            simplePictureBoxes.Z = GetNewPictureBox();

            return simplePictureBoxes;
        }

        private PictureBox GetNewPictureBox()
        {
            PictureBox pb = new PictureBox();
            pb.SizeMode = PictureBoxSizeMode.AutoSize;

            return pb;
        }

        private void CreateSensorCanvas(int width)
        {
            components.SensorCanvas = new SensorCanvas<Canvas>(
                pictureBoxes: GetPictureBoxes(), 
                canvasProvider);

            int sizeOfSlider = 50;
            int numOfCanvases = 4;
            components.SensorCanvas.SetImage(new Size(
                width: width,
                height: (flowLayoutPanel.Height - sizeOfSlider) / numOfCanvases
                ));
        }

        private void ConfigureFlowLayoutPanel()
        {
            flowLayoutPanel.AutoScroll = true;

            flowLayoutPanel.Controls.Add(components.SensorCanvas.GraphCanvases.EMG.PictureBox); //EMG
            flowLayoutPanel.Controls.Add(components.SensorCanvas.GraphCanvases.X.PictureBox);   //X
            flowLayoutPanel.Controls.Add(components.SensorCanvas.GraphCanvases.Y.PictureBox);   //Y
            flowLayoutPanel.Controls.Add(components.SensorCanvas.GraphCanvases.Z.PictureBox);   //Z
        }

        private void CreateComboBoxManager()
        {
            components.ComboBoxManager = new ComboBoxManager<Canvas>(
                components.ComboBox,
                components.SensorCanvas,
                sensors);
        }
    }

    public class ComponentsContainer<Canvas> where Canvas : GraphCanvas
    {
        public SensorCanvas<Canvas> SensorCanvas { get; set; }
        public ComboBox ComboBox { get; set; }
        public ComboBoxManager<Canvas> ComboBoxManager { get; set; }
    }

    public delegate C CanvasProvider<C>(PictureBox pictureBox);
}
