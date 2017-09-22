using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Models;
using Tanks.Models.Fields;
using Tanks.ActionModels;
using TraversalLib;

namespace Tanks.Manager
{
    public class MotionManager
    {
        public BattleField BattleField { get; set; }
        private CoordinatesManager CoordinatesManager { get; }

        public MotionManager(BattleField battleField)
        {
            this.BattleField = battleField;
            this.CoordinatesManager = new CoordinatesManager(this.BattleField.Size);
        }

        public void Swap(AbstractField field1, AbstractField field2)
        {
            field1.Coordinates.Swap(field2.Coordinates);

            this.BattleField.SetSlot(field1);
            this.BattleField.SetSlot(field2);
        }

        public bool Move(AbstractField field,Coordinates targetCoords)
        {

            if (targetCoords != null)
            {
                var fieldSlot = this.BattleField[targetCoords];

                Swap(fieldSlot.Field, field);
            }

            return targetCoords != null;
        }

        public bool MoveUp(AbstractField field)
        {
            var result = Move(field, CoordinatesManager.GetCoordinatesUp(field.Coordinates));
            return result;
        }
        public bool MoveDown(AbstractField field)
        {
            var result = Move(field, CoordinatesManager.GetCoordinatesDown(field.Coordinates));
            return result;
        }
        public bool MoveLeft(AbstractField field)
        {
            var result = Move(field, CoordinatesManager.GetCoordinatesLeft(field.Coordinates));
            return result;
        }
        public bool MoveRight(AbstractField field)
        {
            var result = Move(field, CoordinatesManager.GetCoordinatesRight(field.Coordinates));
            return result;
        }

        public bool MoveUp(ActionModel model)
        {

            throw new NotImplementedException();

            //model.ModelMap.Map.Traversal(()=>)

            //var result = Move(field, CoordinatesManager.GetCoordinatesUp(field.Coordinates));
            //return result;
        }

    }
}
