using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels;

namespace Tanks.Models.Units
{
    [UnitState(UnitState.Drop)]
    public class DropUnit : AbstractUnit,IDrop
    {
        public DropUnit(Coordinates coordinates) : base(coordinates){}
        public DropUnit(int x, int y) : this(new Coordinates(x, y)) { }
    }
}