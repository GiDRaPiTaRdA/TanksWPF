using Tanks.ActionModels;
using Tanks.Manager.Action.Managers;
using Tanks.Models;
using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels;
using Tanks.Models.Units.UnitModels.Cannons;
using TraversalLib;

namespace Tanks.Manager.Action
{
    public class ActionManager
    {
        private MotionManager MovementManager { get; }

        private RotationManager RotationManager { get; }

        private FigthManager FightManager { get; set; }

        private SpawnManager SpawnManager { get; set; }

        private WeaponManager WeaponManager { get; set; }

        public ActionManager(BattleField battleField)
        {
            this.MovementManager = new MotionManager(battleField);
            this.RotationManager = new RotationManager(battleField);
            this.FightManager =  new FigthManager(battleField);
            this.SpawnManager = new SpawnManager(battleField);
            this.WeaponManager =  new WeaponManager(battleField);
        }


        public static bool CanAct(AbstractUnit unit,BattleField battleField)
        {
            bool canMove =
               unit?.Coordinates != null &&
              
               ((battleField[unit.Coordinates].Units.Contains(unit) && unit is AbstractUnit) ^
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

        #region Action model actions

        public void Spawn(ActionModel model)
        {
            this.SpawnManager.Initialize(model);
        }


        private void Go(ActionModel  model, Dirrection dirrection)
        {
            // Rotate
            if (model.ModelMap.Dirrection != dirrection)
            {
                this.RotationManager.RotateModel(model, dirrection);
            }
            // Move
            else
            {
                this.MovementManager.Move(model, dirrection);
            }

        }
        public void GoUp(ActionModel model)=>this.Go(model,Dirrection.Forward);
        public void GoDown(ActionModel model)=> this.Go(model, Dirrection.Backward);
        public void GoLeft(ActionModel model)=>this.Go(model, Dirrection.Left);
        public void GoRight(ActionModel model)=> this.Go(model, Dirrection.Right);

        public void Fire(ActionModel model)
        {
            this.FightManager.Fire(model);
        }

        public void ChangeWeapon<TCannon>(ActionModel model) where TCannon : ICannon
        {
            this.WeaponManager.ChangeWeapon<TCannon>(model);
        }

        #endregion

        #region Unit actions
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