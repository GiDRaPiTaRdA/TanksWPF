using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Tanks.Models;
using TraversalLib;

namespace Tanks.Models.Fields
{
    class BattleField
    {
        public int X { get;}
        public int Y { get; }

        public FieldSlot[,] SpotsMatrix { get; set; }

        public BattleField(int x,int y)
        {
            this.X = x;
            this.Y = y;

            Initialize();
        }

        private void Initialize()
        {
            SpotsMatrix = new FieldSlot[X, Y];

            SpotsMatrix.Traversal((o, ps) => CreateSlot(new EmptyField(ps[0], ps[1])));
        }

        public void SetSlot(AbstractField field)
        {
            SpotsMatrix[field.X, field.Y].Field = field;
        }

        private void CreateSlot(AbstractField field)
        {
            SpotsMatrix[field.X, field.Y] = new FieldSlot(field);
        }
    }
}
