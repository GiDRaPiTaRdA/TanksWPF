using Tanks.Models.Units.UnitModels.BasicUnits;
using Tanks.Models.Units.UnitModels.Missles;

namespace Tanks.Models.Units.UnitModels.Cannons
{
    [UnitState(UnitState.RemoteControlledBrickCannon)]
    public class RemoteControledBrickCannon :Cannon
    {
        public RemoteControledBrickCannon(Coordinates coordinates) : base(coordinates){}

        public override Missle GetMissle(Coordinates coordinates)
        {
            return new RemoteControlledBrickMissle(coordinates);
        }
    }
}