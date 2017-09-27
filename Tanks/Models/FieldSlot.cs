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
            this.Fields =  new Stack<AbstractField>();
            this.Push(field);
        }

        public Stack<AbstractField> Fields { get; }

        public AbstractField Field => this.Fields.Peek();

        public FieldState? State => this.Field.FieldPointState;


        public void Push(AbstractField field)
        {
            if (field.FieldPointState != null)
            {
                this.Fields.Push(field);
                this.OnFieldChanged();
            }
        }

        public AbstractField Pop()
        {
            AbstractField field = this.Fields.Pop();
            this.OnFieldChanged();
            return field;
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
