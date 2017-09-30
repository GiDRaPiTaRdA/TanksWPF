using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Models;
using Tanks.Models.Fields;
using Tanks.ActionModels;
using Tanks.Models.Fields.FieldTypes;
using Tanks.Models.Fields.Interfaces;
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

        #region Move Field
        public bool CanMove(AbstractField field, Coordinates targetCoords)
        {
            bool result =
                field?.Coordinates != null &&
                targetCoords != null &&
                !(this.BattleField[targetCoords].Field is ISolid);

            return result;
        }
     
        public bool CanMoveUp(AbstractField field)
        {
            var result = this.CanMove(field, this.CoordinatesManager.GetCoordinatesUp(field.Coordinates));

            return result;
        }
        public bool CanMoveDown(AbstractField field)
        {
            var result = this.CanMove(field, this.CoordinatesManager.GetCoordinatesDown(field.Coordinates));

            return result;
        }
        public bool CanMoveLeft(AbstractField field)
        {
            var result = this.CanMove(field, this.CoordinatesManager.GetCoordinatesLeft(field.Coordinates));

            return result;
        }
        public bool CanMoveRight(AbstractField field)
        {
            var result = this.CanMove(field, this.CoordinatesManager.GetCoordinatesRight(field.Coordinates));

            return result;
        }

        public bool Move(AbstractField field,Coordinates targetCoords,bool canMoveCheck =true)
        {
            bool canMove = canMoveCheck ? this.CanMove(field, targetCoords):true;

            if (canMove)
            {
                Coordinates prevoius = new Coordinates(field.Coordinates);
                field.Coordinates = targetCoords;

                if (field.FieldPointState != null)
                {
                    this.BattleField[prevoius].Pop(field);
                    this.BattleField.PushField(field);
                }
            }


            return canMove;
        }

        public bool MoveUp(AbstractField field, bool canMoveCheck = true)
        {
            var result = this.Move(field, this.CoordinatesManager.GetCoordinatesUp(field.Coordinates), canMoveCheck);
            return result;
        }
        public bool MoveDown(AbstractField field, bool canMoveCheck = true)
        {
            var result = this.Move(field, this.CoordinatesManager.GetCoordinatesDown(field.Coordinates),canMoveCheck);
            return result;
        }
        public bool MoveLeft(AbstractField field, bool canMoveCheck = true)
        {
            var result = this.Move(field, this.CoordinatesManager.GetCoordinatesLeft(field.Coordinates),canMoveCheck);
            return result;
        }
        public bool MoveRight(AbstractField field, bool canMoveCheck = true)
        {
            var result = this.Move(field, this.CoordinatesManager.GetCoordinatesRight(field.Coordinates),canMoveCheck);
            return result;
        }
        #endregion


        #region Move ActionModel
        public bool CanMove(ActionModel model, AbstractField field, Coordinates targetCoords)
        {
            bool result =
                field?.Coordinates != null &&
                targetCoords != null &&
                (model.ModelMap.ModelFields.Where<AbstractField>(f1 => f1.FieldPointState != null).Any(f => f.Coordinates.Equals(this.BattleField[targetCoords].Field.Coordinates)) ||
                !(this.BattleField[targetCoords].Field is ISolid) || field.FieldPointState == null);

            return result;
        }

        public bool CanMoveUp(ActionModel model)
        {
            bool result = model.ModelMap.ModelFields.All<AbstractField>(f=>this.CanMove(model, f, this.CoordinatesManager.GetCoordinatesUp(f.Coordinates)));

            return result;
        }
        public bool CanMoveDown(ActionModel model)
        {
            bool result = model.ModelMap.ModelFields.All<AbstractField>(f => this.CanMove(model, f, this.CoordinatesManager.GetCoordinatesDown(f.Coordinates)));
            return result;
        }
        public bool CanMoveLeft(ActionModel model)
        {
            bool result = model.ModelMap.ModelFields.All<AbstractField>(f => this.CanMove(model, f, this.CoordinatesManager.GetCoordinatesLeft(f.Coordinates)));
            return result;
        }
        public bool CanMoveRight(ActionModel model)
        {
            bool result = model.ModelMap.ModelFields.All<AbstractField>(f => this.CanMove(model, f, this.CoordinatesManager.GetCoordinatesRight(f.Coordinates)));
            return result;
        }

        public bool MoveUp(ActionModel model)
        {
            bool canMove = this.CanMoveUp(model);

            if (canMove)
            {
                model.ModelMap.ModelFields.ForEach<AbstractField>(f => this.MoveUp(f,false));
            }

            return canMove;
        }
        public bool MoveDown(ActionModel model)
        {
            bool canMove = this.CanMoveDown(model);

            if (canMove)
            {
                model.ModelMap.ModelFields.ForEach<AbstractField>(f => this.MoveDown(f, false));
            }

            return canMove;
        }
        public bool MoveLeft(ActionModel model)
        {
            bool canMove = this.CanMoveLeft(model);

            if (canMove)
            {
                model.ModelMap.ModelFields.ForEach<AbstractField>(f => this.MoveLeft(f, false));
            }

            return canMove;
        }
        public bool MoveRight(ActionModel model)
        {
            bool canMove = this.CanMoveRight(model);

            if (canMove)
            {
                model.ModelMap.ModelFields.ForEach<AbstractField>(f => this.MoveRight(f, false));
            }

            return canMove;
        }

        #endregion

    }
}
