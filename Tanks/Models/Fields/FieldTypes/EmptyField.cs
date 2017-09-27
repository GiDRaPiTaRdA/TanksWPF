namespace Tanks.Models.Fields.FieldTypes
{
    class EmptyField : AbstractField
    {
        public EmptyField(int x,int y) : this(new Coordinates(x,y)){}
        public EmptyField(Coordinates coodrinates) : base(coodrinates, FieldState.EmptyField){}
    }
}
