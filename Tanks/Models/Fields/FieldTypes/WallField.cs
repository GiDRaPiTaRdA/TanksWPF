using Tanks.Models.Fields.Interfaces;

namespace Tanks.Models.Fields.FieldTypes
{
    public class WallField :AbstractField,ISolid
    {
        public WallField(int x, int y) : this(new Coordinates(x,y)){ }
        public WallField(Coordinates coordinates) : base(coordinates, FieldState.Wall){}
    }
}