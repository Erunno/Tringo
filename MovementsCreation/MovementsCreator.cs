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
        }

        ISetOfSensors setOfSensors { get; }
        List<double> boundaries = new List<double>();
        List<MovementFactory> factories = new List<MovementFactory>(); 

        public void CreateMovement(double timeContaintInMovement)
        {
            Interval interval = GetIntervalOf(timeContaintInMovement);
            
            if (!CanCreateFactoryWithInterval(interval))
                throw new OverlapingMovementsException();

            factories.Add(new MovementFactory(setOfSensors, interval));
        }

        private Interval GetIntervalOf(double time)
        {
            double upperBound = (from b in boundaries where time <= b select b).Min();
            double lowerBound = (from b in boundaries where b <= time select b).Max();

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
            boundaries.Add(timeBoundary);
        }

        public void RemoveLastBoundary()
        {
            if (boundaries.Count != 0)
                boundaries.RemoveAt(boundaries.Count - 1);
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
                i1.ValueIsInOpenInterval(i2.From) ||
                i1.ValueIsInOpenInterval(i2.To) ||
                i2.ValueIsInOpenInterval(i1.From) ||
                i2.ValueIsInOpenInterval(i1.To);

        public IEnumerable<Interval> GetUsedIntervals()
        {
            foreach (var factory in factories)
                yield return factory.Interval;
        }
    }

    class OverlapingMovementsException : Exception { }
}
