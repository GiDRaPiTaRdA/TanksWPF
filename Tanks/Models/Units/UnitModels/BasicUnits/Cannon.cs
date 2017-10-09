using System.Collections.Generic;
using System.Linq;
using Tanks.Models.Units.Interfaces;

namespace Tanks.Models.Units.UnitModels.BasicUnits
{
    public abstract class Cannon<TMissle>: Solid, ICannon where TMissle : Missle
    {
        public Stack<TMissle> ChargesStack { get; protected set; }

        public Cannon(Coordinates coordinates) : base(coordinates){}

        public virtual Missle GetMissle(Coordinates coordinates)
        {
            Missle missle = null;

            if (this.ChargesStack.Any())
            {
                missle = this.ChargesStack.Pop();

                missle.Unit.Initialize(coordinates);
            }

            return missle;
        }
    }
}