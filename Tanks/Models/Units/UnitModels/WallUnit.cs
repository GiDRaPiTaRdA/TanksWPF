using Tanks.Models.Units.Interfaces;

namespace Tanks.Models.Units.UnitModels
{
    [UnitState(UnitState.Wall)]
    public class WallUnit :AbstractUnit,ISolid
    {
        public WallUnit(int x, int y) : this(new Coordinates(x,y)){ }
        public WallUnit(Coordinates coordinates) : base(coordinates){}
    }
}