using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using System.ComponentModel;
using Tanks.Models.Units;
using Tanks.Models.Units.UnitModels;

namespace Tanks.Models
{
    [AddINotifyPropertyChangedInterface]
    public class UnitSlot 
    {
        public event EventHandler StateChanged;

        public UnitSlot(AbstractUnit unit)
        {
            this.Fields =  new List<AbstractUnit>();
            this.Push(unit);
        }

        public List<AbstractUnit> Fields { get; }

        public AbstractUnit Unit =>  this.Fields.Last();

        public UnitState? State => this.Unit.UnitPointState;


        public void Push(AbstractUnit unit)
        {
            if (unit.UnitPointState != null)
            {
                this.Fields.Add(unit);
                this.OnFieldChanged();
            }
        }

        public bool Pop(AbstractUnit unit)
        {
            bool result = this.Fields.Remove(unit);
            this.OnFieldChanged();
            return result;
        }


        private void OnFieldChanged()
        {
            this.StateChanged?.Invoke(this,new SlotEventArgs(this.Unit));
        }

        public override string ToString()
        {
            return "["+nameof(UnitSlot)+"]" + this.Unit;
        }
    }

    public class SlotEventArgs : EventArgs
    {
        public SlotEventArgs(AbstractUnit unit)
        {
            this.Unit = unit;
        }
        public AbstractUnit Unit { get; }
    }
}
