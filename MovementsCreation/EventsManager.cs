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
        public EventsManager(MovementCreationCanvas canvas, PictureBox pictureBox, IMovementsCreator movementsCreator)
        {
            this.canvas = canvas;
            this.movementsCreator = movementsCreator;

            this.pictureBox = pictureBox;
            pictureBox.Click += HandleClick;

            ChangeCurrentAction(ClickAction.AddingBorder);
        }

        MovementCreationCanvas canvas { get; }
        PictureBox pictureBox { get; }
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
            
            canvas.Borders = movementsCreator.GetUsedBorders();
            canvas.RefreshBorders();
            pictureBox.Refresh();
        }

        public void RemoveLastBorder()
        {
            movementsCreator.RemoveLastBorder();

            canvas.Borders = movementsCreator.GetUsedBorders();
            
            canvas.RefreshBorders();
            pictureBox.Refresh();
        }

        private void ModifyIntervals(MouseEventArgs e)
        {
            double time = GetTime(e.X);

            if (movementsCreator.CanCreateMovementIn(time))
                movementsCreator.CreateMovement(time);
            else
                movementsCreator.RemoveMovement(time);

            canvas.MovementsIntervals = movementsCreator.GetUsedIntervals();
            
            canvas.RefreshIntervals();
            pictureBox.Refresh();
        }

        private double GetTime(double Xcoor) => (Xcoor / canvas.BitmapImage.Width) * canvas.Graph.Length;
    }

}
