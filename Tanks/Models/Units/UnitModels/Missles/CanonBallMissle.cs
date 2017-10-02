using Tanks.Models.Units.UnitModels.BasicUnits;

namespace Tanks.Models.Units.UnitModels.Missles
{
    [UnitState(UnitState.CannonBallMissle)]
    class CanonBallMissle : Missle
    {
        public CanonBallMissle(int x, int y) : this(new Coordinates(x,y)){ }
        public CanonBallMissle(Coordinates coordinates) : base(coordinates){}
    }
}
