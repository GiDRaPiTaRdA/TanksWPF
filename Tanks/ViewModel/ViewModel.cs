using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Tanks.Models;
using Tanks.Models.Fields;
using TraversalLib;

namespace Tanks
{
    class ViewModel
    {
        public BattleField BattleField { get; }

        public ViewModel()
        {
            this.BattleField = new BattleField(10,10);
        }

    }
}
