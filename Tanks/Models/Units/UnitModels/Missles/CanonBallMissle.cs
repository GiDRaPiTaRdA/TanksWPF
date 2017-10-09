using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels.BasicUnits;
using Tanks.Models.Units.UnitModels.MissleBehaviors;

namespace Tanks.Models.Units.UnitModels.Missles
{
    public class CanonBallMissle : Missle
    {
        public CanonBallMissle() : base(new CannonBall(), new MissleBehavior()) { }
    }
}
