using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;
using ViewingUtils;
using System.Windows.Forms;

namespace MovementsCreation
{
    public interface IMovementsCreationManager
    {
        ISetOfMovements CreateSetOfMovements(ISetOfSensors allSensors);
    }


    public class FormMovementCreatorManager : IMovementsCreationManager
    {

        public ISetOfMovements CreateSetOfMovements(ISetOfSensors allSensors)
        {
            MovementCreatorForm movementCreatorForm = new MovementCreatorForm(allSensors);
            movementCreatorForm.ShowDialog();

            return movementCreatorForm.Result;
        }
    }
}
