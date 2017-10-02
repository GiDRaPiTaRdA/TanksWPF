namespace Tanks.Models.Units.UnitModels
{
    [UnitState(UnitState.Grass)]
    public class GrassUnit: AbstractUnit
    {
        public GrassUnit(int x, int y) : this(new Coordinates(x,y)){ }
        public GrassUnit(Coordinates coordinate) : base(coordinate){ }
    }
}