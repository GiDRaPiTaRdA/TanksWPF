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

        public BattleField(Control[,] mainField)
        {
            this.ControlsMainField = mainField;
        }
    }
}
