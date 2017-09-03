using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tanks.Models.Fields
{
    class BattleField
    {
        public Control[,] ControlsMainField { get; set; }

        public BattleField(int x,int y)
        {
            this.ControlsMainField = new EmptyField[x,y];
        }

        public BattleField(Control[,] mainField)
        {
            this.ControlsMainField = mainField;
        }
    }
}
