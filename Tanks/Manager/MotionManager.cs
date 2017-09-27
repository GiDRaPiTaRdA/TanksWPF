using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Models;
using Tanks.Models.Fields;
using Tanks.ActionModels;
using Tanks.Models.Fields.FieldTypes;
using TraversalLib;

namespace Tanks.Manager
{
    public class MotionManager
    {
        private BattleField BattleField { get; set; }
        private CoordinatesManager CoordinatesManager { get; }

        public MotionManager(BattleField battleField)
        {
            this.BattleField = battleField;
            this.CoordinatesManager = new CoordinatesManager(this.BattleField.Size);
        }

        public bool Move(AbstractField field,Coordinates targetCoords)
        {

            if (targetCoords != null)
            {
                Coordinates prevoius = new Coordinates(field.Coordinates);
                field.Coordinates = targetCoords;

                if (field.FieldPointState != null)
                {
                    this.BattleField[prevoius].Pop();
                    this.BattleField.PushField(field);
                }
            }

            return targetCoords != null;
        }

        public bool MoveUp(AbstractField field)
        {
            var result = this.Move(field, this.CoordinatesManager.GetCoordinatesUp(field.Coordinates));
            return result;
        }
        public bool MoveDown(AbstractField field)
        {
            var result = this.Move(field, this.CoordinatesManager.GetCoordinatesDown(field.Coordinates));
            return result;
        }
        public bool MoveLeft(AbstractField field)
        {
            var result = this.Move(field, this.CoordinatesManager.GetCoordinatesLeft(field.Coordinates));
            return result;
        }
        public bool MoveRight(AbstractField field)
        {
            var result = this.Move(field, this.CoordinatesManager.GetCoordinatesRight(field.Coordinates));
            return result;
        }

        public bool MoveUp(ActionModel model)
        {
            model.ModelMap.ModelFields.ForEach<AbstractField>(f=> this.MoveUp(f));
            return true;
        }
        public bool MoveDown(ActionModel model)
        {
            model.ModelMap.ModelFields.ForEach<AbstractField>(f => this.MoveDown(f));
            return true;
        }
        public bool MoveLeft(ActionModel model)
        {
            model.ModelMap.ModelFields.ForEach<AbstractField>(f => this.MoveLeft(f));
            return true;
        }
        public bool MoveRight(ActionModel model)
        {
            model.ModelMap.ModelFields.ForEach<AbstractField>(f => this.MoveRight(f));
            return true;
        }

    }
}
