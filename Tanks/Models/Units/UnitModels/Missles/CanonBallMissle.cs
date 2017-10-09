using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels.BasicUnits;
using Tanks.Models.Units.UnitModels.MissleBehaviors;

namespace Tanks.Models.Units.UnitModels.Missles
{
    [UnitState(UnitState.CannonBallMissle)]
    class CanonBallMissle : Missle
    {
        public CanonBallMissle(){}
        public CanonBallMissle(int x, int y) : this(new Coordinates(x,y)){ }
        public CanonBallMissle(Coordinates coordinates) : base(coordinates,new MissleBehavior()){}
    }
}
