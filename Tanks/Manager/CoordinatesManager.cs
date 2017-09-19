using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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

        //public void Swap(Coordinates coords1, Coordinates coords2)
        //{
        //    Coordinates c1Temp = coords1;
        //    Coordinates c2Temp = coords2;

        //    coords1 = c2Temp;
        //    coords2 = c1Temp;
        //}


        public Coordinates GetCoordinatesUp(Coordinates coordinates)
        {
            return GetCooordinates(new Coordinates(coordinates.X, coordinates.Y - 1));
        }
        public Coordinates GetCoordinatesDown(Coordinates coordinates)
        {
            return GetCooordinates(new Coordinates(coordinates.X, coordinates.Y + 1));
        }
        public Coordinates GetCoordinatesLeft(Coordinates coordinates)
        {
            return GetCooordinates(new Coordinates(coordinates.X - 1, coordinates.Y));
        }
        public Coordinates GetCoordinatesRight(Coordinates coordinates)
        {
            return GetCooordinates(new Coordinates(coordinates.X + 1, coordinates.Y));
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
                 coords.X >= 0 && coords.X < BoundCoordinates.X &&
                 coords.Y >= 0 && coords.Y < BoundCoordinates.Y
                )
            {
                coordinates = coords;
            }

            return coordinates;
        }
    }
}
