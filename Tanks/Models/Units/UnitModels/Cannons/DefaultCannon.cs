using System.Collections.Generic;
using System.Linq;
using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels.BasicUnits;
using Tanks.Models.Units.UnitModels.MissleBehaviors;
using Tanks.Models.Units.UnitModels.Missles;

namespace Tanks.Models.Units.UnitModels.Cannons
{
    [UnitState(UnitState.DefaultCannon)]
    public class DefaultCannon : Cannon
    {
       

        public DefaultCannon(Coordinates coordinates) : base(coordinates)
        {
            this.ChargesStack = new Stack<Solid>();

            for (int i = 0; i < 5; i++)
            {
                this.ChargesStack.Push(new CanonBallMissle()
                {
                    MissleBehavior = new MissleBehavior()
                });
            }

            for (int i = 0; i < 5; i++)
            {
                this.ChargesStack.Push(new BrickMissle()
                {
                    MissleBehavior = new BrickBehavior()
                });
            }

        }


        public override Missle GetMissle(Coordinates coordinates)
        {
            Missle missle = null;

            if (this.ChargesStack.Any())
                missle = this.ChargesStack.Pop().Initialize(coordinates) as Missle;

            return missle;
        }
    }
}