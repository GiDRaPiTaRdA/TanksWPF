using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels.BasicUnits;

namespace Tanks.Models.Units.UnitModels
{
    [UnitState(UnitState.Wall)]
    public class WallUnit :Solid
    {
        public WallUnit() { }
        public WallUnit(int x, int y) : this(new Coordinates(x,y)){ }
        public WallUnit(Coordinates coordinates) : base(coordinates){}
    }
}