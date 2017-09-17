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
        public FieldPointState FieldPointState { get; }

        public int X { get; set; }
        public int Y { get; set; }

        public AbstractField(int x, int y, FieldPointState state)
        {
            this.X = x;
            this.Y = y;
            this.FieldPointState = state;
        }
    }
}
