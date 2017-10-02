using System;
using Tanks.ActionModels;
using Tanks.Models;

namespace Tanks.Manager.Action
{
    class CoordinatesManager
    {
        public Coordinates BoundCoordinates { get; }

        public CoordinatesManager(Coordinates coordinates)
        {
            this.BoundCoordinates = coordinates;
        }

        public Coordinates GetCoordinates(Coordinates coordinates, Dirrection dirrection)
        {
            Coordinates coords;

            switch (dirrection)
            {
                case Dirrection.Forward:
                    coords = this.GetCoordinatesUp(coordinates);
                    break;
                case Dirrection.Backward:
                    coords = this.GetCoordinatesDown(coordinates);
                    break;
                case Dirrection.Left:
                    coords = this.GetCoordinatesLeft(coordinates);
                    break;
                case Dirrection.Right:
                    coords = this.GetCoordinatesRight(coordinates);
                    break;
                default:
                    throw new ArgumentException("Dirrcetion :" +dirrection+" is not implemented");
            }
            return coords;
        }

        public Coordinates GetCoordinatesUp(Coordinates coordinates)
        {
            return this.GetCooordinates(new Coordinates(coordinates.X, coordinates.Y - 1));
        }
        public Coordinates GetCoordinatesDown(Coordinates coordinates)
        {
            return this.GetCooordinates(new Coordinates(coordinates.X, coordinates.Y + 1));
        }
        public Coordinates GetCoordinatesLeft(Coordinates coordinates)
        {
            return this.GetCooordinates(new Coordinates(coordinates.X - 1, coordinates.Y));
        }
        public Coordinates GetCoordinatesRight(Coordinates coordinates)
        {
            return this.GetCooordinates(new Coordinates(coordinates.X + 1, coordinates.Y));
        }

        /// <summary>
        /// Gets coordinates correctly
        /// </summary>
        /// <param name="coords">coords</param>
        /// <returns>correct coords</returns>
        private Coordinates GetCooordinates(Coordinates coords)
        {
            Coordinates coordinates = null;

            if (
                 coords.X >= 0 && coords.X < this.BoundCoordinates.X &&
                 coords.Y >= 0 && coords.Y < this.BoundCoordinates.Y
                )
            {
                coordinates = coords;
            }

            return coordinates;
        }
    }
}
