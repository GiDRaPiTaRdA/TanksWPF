using System;
using System.Linq;
using System.Reflection;
using PropertyChanged;

namespace Tanks.Models.Units.UnitModels
{
   [AddINotifyPropertyChangedInterface]
   public abstract class AbstractUnit
    {
        public UnitState? UnitPointState { get; }

        public Coordinates Coordinates { get; set; }

       protected AbstractUnit(Coordinates coordinates)
        {
            this.Coordinates = coordinates;

            this.UnitPointState = ((UnitStateAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(UnitStateAttribute))).State;
        }

        public override string ToString()
        {
            return this.Coordinates +" unit state: " + ((object)this.UnitPointState??"Null");
        }
    }
}
