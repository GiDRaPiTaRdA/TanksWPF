namespace Tanks.Models.Units.UnitModels
{
    [UnitState(UnitState.EmptyUnit)]
    class EmptyUnit : AbstractUnit
    {
        public EmptyUnit(int x,int y) : this(new Coordinates(x,y)){}
        public EmptyUnit(Coordinates coodrinates) : base(coodrinates){}
    }
}