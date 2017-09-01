using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Models.Fields
{
    class BattleField
    {
        public AbstractField[,] MainField { get; set; }

        public BattleField(int x,int y)
        {
            this.MainField = new EmptyField[x,y];
        }
    }
}
