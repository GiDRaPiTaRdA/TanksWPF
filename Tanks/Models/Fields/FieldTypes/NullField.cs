namespace Tanks.Models.Fields.FieldTypes
{
    public class NullField :AbstractField
    {
        public NullField(int x,int y) : this(new Coordinates(x,y)){}
        public NullField(Coordinates coordinates) : base(coordinates, null){}
    }
}