using System;

namespace Tanks.Models.Units
{
    public class UnitStateAttribute :Attribute
    {
        public UnitState? State { get; }


        public UnitStateAttribute()
        {
            this.State = null;
        }
        public UnitStateAttribute(UnitState state)
        {
            this.State = state;
        }
    }
}