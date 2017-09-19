using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PropertyChanged;
using System.Windows.Controls;
using System.Windows.Media;
using Tanks.Models.Dictionary;

namespace Tanks.Models.Fields
{
   // [AddINotifyPropertyChangedInterface]
   public abstract class AbstractField
    {
        public FieldState FieldPointState { get; }

        public Coordinates Coordinates { get; set; }

        public AbstractField(Coordinates coordinates, FieldState state)
        {
            this.Coordinates = coordinates;
            this.FieldPointState = state;
        }

        public override string ToString()
        {
            return this.Coordinates +" Field state: " + this.FieldPointState;
        }
    }
}
