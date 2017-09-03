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
        public TankField(int x, int y, Control uiElement) : base(x,y,uiElement, FieldPointState.TankField)
        {
        }
    }
}
