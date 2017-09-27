using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tanks.Models;
using Tanks.Models.Fields;

namespace Tanks.Manager
{
    class CoordinatesManager
    {
        public Coordinates BoundCoordinates { get; }

        public CoordinatesManager(Coordinates coordinates)
        {
            this.BoundCoordinates = coordinates;
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
