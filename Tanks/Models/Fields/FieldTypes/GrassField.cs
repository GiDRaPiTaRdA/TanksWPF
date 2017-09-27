namespace Tanks.Models.Fields.FieldTypes
{
    public class GrassField: AbstractField
    {
        public GrassField(int x, int y) : this(new Coordinates(x,y)){ }
        public GrassField(Coordinates coordinate) : base(coordinate, FieldState.GrassField){ }
    }
}