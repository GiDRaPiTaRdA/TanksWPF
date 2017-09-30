using Tanks.ActionModels;
using Tanks.Models;
using Tanks.Models.Fields.FieldTypes;

namespace Tanks.Manager
{
    public class ActionManager
    {
        private MotionManager MovementManager { get; }

        private RotationManager RotationManager { get; }

        public ActionManager(BattleField battleField)
        {
            this.MovementManager = new MotionManager(battleField);
            this.RotationManager = new RotationManager(battleField);
        }

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

        public void GoUp(AbstractField model)
        {
            this.MovementManager.MoveUp(model);
        }
        public void GoDown(AbstractField model)
        {
            this.MovementManager.MoveDown(model);
        }
        public void GoLeft(AbstractField model)
        {

            this.MovementManager.MoveLeft(model);
        }
        public void GoRight(AbstractField model)
        {
            this.MovementManager.MoveRight(model);
        }
    }
}