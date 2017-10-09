using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using PropertyChanged;
using Tanks.ActionModels;
using Tanks.Manager.Action.Managers;
using Tanks.Models.Units.Interfaces;

namespace Tanks.Models.Units.UnitModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class AbstractUnit
    {
        public UnitState? UnitPointState { get; }

        public Coordinates Coordinates { get; set; }

        protected AbstractUnit(Coordinates coordinates = null)
        {
            this.Coordinates = coordinates;

            this.UnitPointState = this.GetState();
        }

        public AbstractUnit Initialize(Coordinates coordinates)
        {
            this.Coordinates = coordinates;
            return this;
        }

        private UnitState? GetState()
        {
            var attribute = ((UnitStateAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(UnitStateAttribute)));

            if(attribute==null)
                throw new Exception("Atttibute "+nameof(UnitStateAttribute)+" not found for type " + this.GetType());

            UnitState? state = attribute.State;
            return state;
        }

        public override string ToString()
        {
            return this.Coordinates + " unit state: " + ((object)this.UnitPointState ?? "Null");
        }
    }
}
