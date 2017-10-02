using Tanks.Models.Units.Interfaces;

namespace Tanks.Models.Units.UnitModels
{
    [UnitState(UnitState.Tank)]
    class TankUnit : AbstractUnit ,ISolid
    {
        public TankUnit(int x, int y) : this(new Coordinates(x,y)){}
        public TankUnit(Coordinates coordinate) : base(coordinate){}
    }
}
