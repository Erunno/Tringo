using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TringoModel.DataSructures;
using TringoModel.DataSructures.Interval;
using TringoModel.DataSructures.Simple;

namespace MovementsCreation
{
    public class MovementsCreator : IMovementsCreator
    {
        public MovementsCreator(ISetOfSensors setOfSensors)
        {
            this.setOfSensors = setOfSensors;

            maxTime = (from sens in setOfSensors.Sensors select sens.EMG.Length).Max(); //dosnt matter from which i select time
        }

        ISetOfSensors setOfSensors { get; }
        List<double> borders = new List<double>();
        List<MovementFactory> factories = new List<MovementFactory>(); 

        double maxTime { get; }

        public void CreateMovement(double timeContaintInMovement)
        {
            Interval interval = GetIntervalOf(timeContaintInMovement);
            
            if (!CanCreateFactoryWithInterval(interval))
                throw new OverlapingMovementsException();

            factories.Add(new MovementFactory(setOfSensors, interval));
        }

        private Interval GetIntervalOf(double time)
        {
            double upperBound = (from b in borders.Append(maxTime) where time <= b select b).Min();
            double lowerBound = (from b in borders.Append(0)       where b <= time select b).Max(); //TODO lower bound doesnt have to be provided

            return new Interval(from: lowerBound, to: upperBound);
        }

        public void RemoveMovement(double timeContaintInMovement)
        {
            MovementFactory factoryToRemove = FindFactory(timeContaintInMovement);

            if (factoryToRemove != null)
                factories.Remove(factoryToRemove);
        }

        private MovementFactory FindFactory(double time)
        {
            foreach (var factory in factories)
                if (factory.Interval.ValueIsInClosedInterval(time))
                    return factory;

            return null;
        }

        public ISetOfMovements GetCreatedSetOfMovements()
        {
            List<IMovement> movements = new List<IMovement>();

            var sortedFactories = from fac in factories orderby fac.Interval.From ascending select fac;

            foreach (var factory in sortedFactories)
                movements.Add(factory.GetMovement());

            return new SimpleSetOfMovements(movements);
        }

        public void RegisterBoundary(double timeBoundary)
        {
            borders.Add(timeBoundary);
        }

        public void RemoveLastBorder()
        {
            if (borders.Count == 0)
                return;

            double removedBorder = borders[borders.Count - 1];
            borders.RemoveAt(borders.Count - 1);

            RemoveMovement(removedBorder);
        }

        public bool CanCreateMovementIn(double time)
        {
            Interval interval = GetIntervalOf(time);

            return CanCreateFactoryWithInterval(interval);
        }

        private bool CanCreateFactoryWithInterval(Interval interval)
        {
            foreach (var factory in factories)
                if (OpenIntervalsOverlap(factory.Interval, interval))
                    return false;

            return true;
        }

        private bool OpenIntervalsOverlap(Interval i1, Interval i2)
            =>
                i1 == i2 ||
                i1.ValueIsInOpenInterval(i2.From) ||
                i1.ValueIsInOpenInterval(i2.To) ||
                i2.ValueIsInOpenInterval(i1.From) ||
                i2.ValueIsInOpenInterval(i1.To);

        public IEnumerable<Interval> GetUsedIntervals()
        {
            foreach (var factory in factories)
                yield return factory.Interval;
        }

        public IEnumerable<double> GetUsedBorders() => borders;
    }

    class OverlapingMovementsException : Exception { }
}
