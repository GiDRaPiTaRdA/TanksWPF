using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Tanks.ActionModels;
using Tanks.Models;
using TraversalLib;

namespace Tanks.Models.Fields
{
    public class BattleField
    {
        public Coordinates Size { get; }

        public FieldSlot[,] SpotsMatrix { get; private set; }

        public BattleField(int x, int y)
        {
            this.Size = new Coordinates(x,y);

            Initialize();
        }

        private void Initialize()
        {
            SpotsMatrix = new FieldSlot[Size.X, Size.Y];

            SpotsMatrix.Traversal((o, ps) => CreateSlot(new EmptyField(ps[0], ps[1])));
        }

        public void SetSlot(AbstractField field)
        {
            this[field.Coordinates].Field = field;
        }

        public void SetMap(ModelMap map)
        {
            map.ModelFields.Traversal((o, ps) => this.SetSlot((AbstractField)o));
        }

        private void CreateSlot(AbstractField field)
        {
            this[field.Coordinates] = new FieldSlot(field);
        }

        public FieldSlot this[Coordinates coordinates]
        {
            get
            {
                FieldSlot slot = this[coordinates.X, coordinates.Y];
                return slot;
            }
            private set
            {
                this[coordinates.X, coordinates.Y] = value;
            }

        }

        public FieldSlot this[int x,int y]
        {
            get
            {
                FieldSlot slot = this.SpotsMatrix[x, y];
                return slot;
            }
            private set
            {
                this.SpotsMatrix[x, y] = value;
            }

        }
    }
}
