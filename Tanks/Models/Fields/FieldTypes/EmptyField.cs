using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Tanks.Models.Fields
{
    class EmptyField : AbstractField
    {
        public EmptyField(int x,int y) : this(new Coordinates(x,y)){}
        public EmptyField(Coordinates coodrinates) : base(coodrinates, FieldState.EmptyField){}
    }
}
