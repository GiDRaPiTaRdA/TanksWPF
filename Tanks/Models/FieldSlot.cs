using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Models.Fields;
using PropertyChanged;
using System.ComponentModel;
using Tanks.Models.Fields.FieldTypes;

namespace Tanks.Models
{
    [AddINotifyPropertyChangedInterface]
    public class FieldSlot 
    {
        public event EventHandler StateChanged;

        public FieldSlot(AbstractField field)
        {
            this.Fields =  new List<AbstractField>();
            this.Push(field);
        }

        public List<AbstractField> Fields { get; }

        public AbstractField Field => this.Fields.Last();

        public FieldState? State => this.Field.FieldPointState;


        public void Push(AbstractField field)
        {
            if (field.FieldPointState != null)
            {
                this.Fields.Add(field);
                this.OnFieldChanged();
            }
        }

        public bool Pop(AbstractField field)
        {
            bool result = this.Fields.Remove(field);
            this.OnFieldChanged();
            return result;
        }


        private void OnFieldChanged()
        {
            this.StateChanged?.Invoke(this,new SlotEventArgs(this.Field));
        }

        public override string ToString()
        {
            return "["+nameof(FieldSlot)+"]" + this.Field;
        }
    }

    public class SlotEventArgs : EventArgs
    {
        public SlotEventArgs(AbstractField field)
        {
            this.Field = field;
        }
        public AbstractField Field { get; }
    }
}
