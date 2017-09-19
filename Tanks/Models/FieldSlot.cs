using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Models.Fields;
using PropertyChanged;

namespace Tanks.Models
{
    [AddINotifyPropertyChangedInterface]
    public class FieldSlot 
    {
        public FieldSlot(AbstractField field)
        {
            this.Field = field;
        }

        public event EventHandler StateChanged;

        public AbstractField Field { get; set; }

        public FieldState State => Field.FieldPointState;

        private void OnStateChanged()
        {
            StateChanged?.Invoke(this,new SlotEventArgs(Field));
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
