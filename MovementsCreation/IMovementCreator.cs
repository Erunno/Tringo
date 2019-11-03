using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;
using TringoModel.DataSructures.Interval;

namespace MovementsCreation
{
    public interface IMovementsCreator
    {
        void RegisterBoundary(double timeBoundary);
        void RemoveLastBoundary();

        bool CanCreateMovementIn(double time);
        void CreateMovement(double timeContaintInMovement);
        void RemoveMovement(double timeContaintInMovement);

        IEnumerable<Interval> GetUsedIntervals();

        ISetOfMovements GetCreatedSetOfMovements();
    }
}
