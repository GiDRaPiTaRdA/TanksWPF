using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Tanks.Models.Fields;

namespace Tanks
{
    class ViewModel
    {
        public int Size => 10;

        public int FPS => 60;

        public BattleField BattleField { get; set; }

        public ViewModel(Control[,] controls)
        {
            this.BattleField = new BattleField(controls);
        }

    }
}
