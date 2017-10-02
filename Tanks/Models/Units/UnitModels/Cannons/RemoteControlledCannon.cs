using Tanks.Models.Units.UnitModels.BasicUnits;
using Tanks.Models.Units.UnitModels.Missles;

namespace Tanks.Models.Units.UnitModels.Cannons
{
    [UnitState(UnitState.RemoteContolledCannon)]
    public class RemoteControlledCannon : Cannon
    {
        public RemoteControlledCannon(Coordinates coordinates) : base(coordinates)
        {
        }

        public override Missle GetMissle(Coordinates coordinates)
        {
            return new RemoteControlledCannonBallMissle(coordinates);
        }
    }
}