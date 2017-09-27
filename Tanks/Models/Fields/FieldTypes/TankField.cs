﻿namespace Tanks.Models.Fields.FieldTypes
{
    class TankField : AbstractField
    {
        public TankField(int x, int y) : this(new Coordinates(x,y)){}
        public TankField(Coordinates coordinate) : base(coordinate, FieldState.TankField){}
    }
}
