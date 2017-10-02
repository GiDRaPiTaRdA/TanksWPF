using Tanks.ActionModels;
using Tanks.Models;
using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels;
using TraversalLib;

namespace Tanks.Manager.Action
{
    public class ActionManager
    {
        private MotionManager MovementManager { get; }

        private RotationManager RotationManager { get; }

        private FigthManager FightManager { get; set; }

        public ActionManager(BattleField battleField)
        {
            this.MovementManager = new MotionManager(battleField);
            this.RotationManager = new RotationManager(battleField);
            this.FightManager =  new FigthManager(battleField);
        }


        public static bool CanAct(AbstractUnit unit,BattleField battleField)
        {
            bool canMove =
               unit?.Coordinates != null &&
              
               ((battleField[unit.Coordinates].Fields.Contains(unit) && unit is ISolid) ^
               unit.UnitPointState == null);
            return canMove;
        }
        public static bool CanAct(ActionModel model, BattleField battleField)
        {
            bool result = model.ModelMap.ModelUnits.All<AbstractUnit>(field =>
            {
                bool canMove = CanAct(field,battleField);
                return canMove;
            });
            return result;
        }

        #region Action model action
        public void GoUp(ActionModel model)
        {
            if (model.ModelMap.Dirrection != Dirrection.Forward)
            {
                this.RotationManager.RotateForward(model);
            }
            else
            {
                this.MovementManager.MoveUp(model);
            }
        }
        public void GoDown(ActionModel model)
        {
            if (model.ModelMap.Dirrection != Dirrection.Backward)
            {
                this.RotationManager.RotateBackward(model);
            }
            else
            {
                this.MovementManager.MoveDown(model);
            }

        }
        public void GoLeft(ActionModel model)
        {
            if (model.ModelMap.Dirrection != Dirrection.Left)
            {
                this.RotationManager.RotateLeft(model);
            }
            else
            {
                this.MovementManager.MoveLeft(model);
            }

        }
        public void GoRight(ActionModel model)
        {
            if (model.ModelMap.Dirrection != Dirrection.Right)
            {
                this.RotationManager.RotateRight(model);
            }
            else
            {
                this.MovementManager.MoveRight(model);
            }

        }

        public void Fire(ActionModel model)
        {
            this.FightManager.Fire(model);
        }
        #endregion

        #region unit actions
        public void GoUp(AbstractUnit model)
        {
            this.MovementManager.MoveUp(model);
        }
        public void GoDown(AbstractUnit model)
        {
            this.MovementManager.MoveDown(model);
        }
        public void GoLeft(AbstractUnit model)
        {

            this.MovementManager.MoveLeft(model);
        }
        public void GoRight(AbstractUnit model)
        {
            this.MovementManager.MoveRight(model);
        }
        #endregion
    }
}