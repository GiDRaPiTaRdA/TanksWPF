using System.Collections.Generic;
using Tanks.Models.Units.UnitModels.BasicUnits;
using Tanks.Models.Units.UnitModels.MissleBehaviors;
using Tanks.Models.Units.UnitModels.Missles;

namespace Tanks.Models.Units.UnitModels.Cannons
{
    [UnitState(UnitState.BrickCannon)]
    public class BrickCannon :Cannon<Missle>
    {
        public BrickCannon(Coordinates coordinates) : base(coordinates)
        {
            this.ChargesStack = new Stack<Missle>();

            for (int i = 0; i < 5; i++)
            {
                this.ChargesStack.Push(new BrickMissle());
            }
        }
    }
}