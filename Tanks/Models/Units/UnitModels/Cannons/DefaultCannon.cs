using Tanks.Models.Units.UnitModels.BasicUnits;
using Tanks.Models.Units.UnitModels.Missles;

namespace Tanks.Models.Units.UnitModels.Cannons
{
    [UnitState(UnitState.DefaultCannon)]
    public class DefaultCannon :Cannon
    {
        public DefaultCannon(Coordinates coordinates) : base(coordinates)
        {
        }

        public override Missle GetMissle(Coordinates coordinates)
        {
            return new CanonBallMissle(coordinates);
        }
    }
}