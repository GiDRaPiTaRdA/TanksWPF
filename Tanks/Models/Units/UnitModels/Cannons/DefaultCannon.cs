using System.Collections.Generic;
using System.Linq;
using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels.BasicUnits;
using Tanks.Models.Units.UnitModels.MissleBehaviors;
using Tanks.Models.Units.UnitModels.Missles;

namespace Tanks.Models.Units.UnitModels.Cannons
{
    [UnitState(UnitState.DefaultCannon)]
    public class DefaultCannon : Cannon<CanonBallMissle>
    {
        public DefaultCannon(Coordinates coordinates) : base(coordinates)
        {
            this.ChargesStack = new Stack<CanonBallMissle>();

            for (int i = 0; i < 100; i++)
            {
                this.ChargesStack.Push(new CanonBallMissle());
            }
        }
    }
}