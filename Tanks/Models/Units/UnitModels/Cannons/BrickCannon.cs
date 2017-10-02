using Tanks.Models.Units.UnitModels.BasicUnits;
using Tanks.Models.Units.UnitModels.Missles;

namespace Tanks.Models.Units.UnitModels.Cannons
{
    [UnitState(UnitState.BrickCannon)]
    public class BrickCannon :Cannon
    {
        public BrickCannon(Coordinates coordinates) : base(coordinates)
        {
        }

        public override Missle GetMissle(Coordinates coordinates)
        {
            return new BrickMissle(coordinates);
        }
    }
}