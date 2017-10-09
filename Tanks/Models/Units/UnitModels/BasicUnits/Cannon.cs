using System.Collections.Generic;
using Tanks.Models.Units.Interfaces;

namespace Tanks.Models.Units.UnitModels.BasicUnits
{
    public abstract class Cannon: Solid 
    {
        public Stack<Solid> ChargesStack { get; protected set; }

        public Cannon(Coordinates coordinates) : base(coordinates){}

        public abstract Missle GetMissle(Coordinates coordinates);
    }
}