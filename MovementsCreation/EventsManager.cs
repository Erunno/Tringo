using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewingUtils;
using System.Windows.Forms;
using ViewingUtils.Canvases;

namespace MovementsCreation
{
    class EventsManager
    {
        public EventsManager(SensorCanvas<MovementCreationCanvas> sensorCanvas, IMovementsCreator movementsCreator)
        {
            this.canvases = sensorCanvas.GraphCanvases;
            this.movementsCreator = movementsCreator;

            ConfigureCanvases();

            ChangeCurrentAction(ClickAction.AddingBorder);
        }

        private void ConfigureCanvases()
        {
            foreach (var canvas in canvases)
                canvas.PictureBox.Click += HandleClick;
        }

        IEnumerable<MovementCreationCanvas> canvases { get; }
        IMovementsCreator movementsCreator { get; }
        ClickHandler currentClickHandler;


        public enum ClickAction { AddingBorder, ModifingIntervals }

        private delegate void ClickHandler(MouseEventArgs e);

        public void ChangeCurrentAction(ClickAction clickAction)
        {
            switch (clickAction)
            {
                case ClickAction.AddingBorder:
                    currentClickHandler = AddBorder;
                    break;
                case ClickAction.ModifingIntervals:
                    currentClickHandler = ModifyIntervals;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void HandleClick(object sender, EventArgs e) => currentClickHandler((MouseEventArgs)e);

        private void AddBorder(MouseEventArgs e)
        {
            double time = GetTime(e.X);

            movementsCreator.RegisterBoundary(time);

            foreach (var canvas in canvases)
            {
                canvas.Borders = movementsCreator.GetUsedBorders();
                canvas.RefreshBorders();
                canvas.PictureBox.Refresh();
            }
        }

        public void RemoveLastBorder()
        {
            movementsCreator.RemoveLastBorder();

            foreach (var canvas in canvases)
            {
                canvas.Borders = movementsCreator.GetUsedBorders();
            
                canvas.RefreshBorders();
                canvas.PictureBox.Refresh();
            }
        }

        private void ModifyIntervals(MouseEventArgs e)
        {
            double time = GetTime(e.X);

            if (movementsCreator.CanCreateMovementIn(time))
                movementsCreator.CreateMovement(time);
            else
                movementsCreator.RemoveMovement(time);

            foreach (var canvas in canvases)
            {
                canvas.MovementsIntervals = movementsCreator.GetUsedIntervals();
            
                canvas.RefreshIntervals();
                canvas.PictureBox.Refresh();
            }
        }

        private double GetTime(double Xcoor)
        {
            MovementCreationCanvas randomCanvas = canvases.First(); //all graphs are of same width since they are from one sensor

            return (Xcoor / randomCanvas.BitmapImage.Width) * randomCanvas.Graph.Length;
        }
    }

}
