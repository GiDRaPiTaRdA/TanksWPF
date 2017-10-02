namespace Tanks.Models.Units.UnitModels
{
    [UnitState]
    public class NullUnit :AbstractUnit
    {
        public NullUnit(int x,int y) : this(new Coordinates(x,y)){}
        public NullUnit(Coordinates coordinates) : base(coordinates){}
    }
}