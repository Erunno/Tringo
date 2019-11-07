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
    public class BaseFormBuilder<C> where C : Canvas
    {
        public BaseFormBuilder(IList<ISensor> sensors, FlowLayoutPanel flowLayoutPanel, ComboBox comboBox, CanvasProvider<C> canvasProvider)
        {
            this.sensors = sensors;
            components.ComboBox = comboBox;
            this.flowLayoutPanel = flowLayoutPanel;
            this.canvasProvider = canvasProvider;
        }

        IList<ISensor> sensors;
        FlowLayoutPanel flowLayoutPanel;

        ComponentsContainer<C> components = new ComponentsContainer<C>();
        CanvasProvider<C> canvasProvider;

        public ComponentsContainer<C> GetInicializedComponents(int widthOfCanvas)
        {
            CreatePictureBox();
            CreateCanvas(widthOfCanvas);
            ConfigureFlowLayoutPanel();
            CreateComboBoxManager();

            return components;
        }

        private void CreatePictureBox()
        {
            components.PictureBox = new PictureBox();
            components.PictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void CreateCanvas(int width)
        {
            C canvas = canvasProvider(components.PictureBox);

            int sizeOfSlider = 25;

            canvas.SetImage(new Size(
                width: width,
                height: flowLayoutPanel.Height - sizeOfSlider
                ));

            components.Canvas = canvas;
        }

        private void ConfigureFlowLayoutPanel()
        {
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Controls.Add(components.PictureBox);
        }

        private void CreateComboBoxManager()
        {
            components.ComboBoxManager = new ComboBoxManager(
                components.ComboBox,
                components.Canvas,
                sensors);
        }
    }

    public class ComponentsContainer<C> where C : Canvas
    {
        public PictureBox PictureBox { get; set; }
        public C Canvas { get; set; }
        public ComboBox ComboBox { get; set; }
        public ComboBoxManager ComboBoxManager { get; set; }
    }

    public delegate C CanvasProvider<C>(PictureBox pictureBox);
}
