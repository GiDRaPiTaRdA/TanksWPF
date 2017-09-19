using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Tanks.Models.Fields
{
    class TankField : AbstractField
    {
        public TankField(int x, int y) : this(new Coordinates(x,y)){}
        public TankField(Coordinates coordinate) : base(coordinate, FieldState.TankField){}
    }
}
