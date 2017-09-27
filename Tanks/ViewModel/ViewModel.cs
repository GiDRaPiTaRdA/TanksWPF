using Microsoft.Practices.Prism.Commands;
using Tanks.ActionModels;
using Tanks.ActionModels.RealModels;
using Tanks.Manager;
using Tanks.Models;
using Tanks.Models.Fields;
using Tanks.Models.Fields.FieldTypes;

// ReSharper disable MemberCanBePrivate.Global

namespace Tanks.ViewModel
{
    class ViewModel
    {
        public Tank Tank { get; set; }
        public Tank Tank2 { get; set; }

        public TankField TankField { get; set; }

        public BattleField BattleField { get; }

        public MotionManager MovementManager { get; }

        public RotationManager RotationManager { get; }

        public ViewModel()
        {
            // Initialize
            this.BattleField = new BattleField(20, 20);

            this.MovementManager = new MotionManager(this.BattleField);
            this.RotationManager =  new RotationManager(this.BattleField);


            // Logic
            this.Tank = new Tank();
            this.Tank2 = new Tank();

            this.Tank.Initialize(this.BattleField);
            this.Tank2.Initialize(this.BattleField);

            this.BattleField.PushField(new GrassField(5,5));
            this.BattleField.PushField(new GrassField(0, 0));
        }

        #region Delegate commands

        private DelegateCommand moveUpCommand;
        private DelegateCommand moveRightCommand;
        private DelegateCommand moveDownCommand;
        private DelegateCommand moveLeftCommand;

        public DelegateCommand MoveUpCommand => this.moveUpCommand ?? (this.moveUpCommand = new DelegateCommand(() => this.GoUp(this.Tank)));
        public DelegateCommand MoveDownCommand => this.moveDownCommand ?? (this.moveDownCommand = new DelegateCommand(() => this.GoDown(this.Tank)));
        public DelegateCommand MoveLeftCommand => this.moveLeftCommand ?? (this.moveLeftCommand = new DelegateCommand(() => this.GoLeft(this.Tank)));
        public DelegateCommand MoveRightCommand => this.moveRightCommand ?? (this.moveRightCommand = new DelegateCommand(() => this.GoRight(this.Tank)));


        private DelegateCommand moveUpCommandQ;
        private DelegateCommand moveRightCommandQ;
        private DelegateCommand moveDownCommandQ;
        private DelegateCommand moveLeftCommandQ;

        public DelegateCommand MoveUpCommandQ => this.moveUpCommandQ ?? (this.moveUpCommandQ = new DelegateCommand(() => this.GoUp(this.Tank2)));
        public DelegateCommand MoveDownCommandQ => this.moveDownCommandQ ?? (this.moveDownCommandQ = new DelegateCommand(() => this.GoDown(this.Tank2)));
        public DelegateCommand MoveLeftCommandQ => this.moveLeftCommandQ ?? (this.moveLeftCommandQ = new DelegateCommand(() => this.GoLeft(this.Tank2)));
        public DelegateCommand MoveRightCommandQ => this.moveRightCommandQ ?? (this.moveRightCommandQ = new DelegateCommand(() => this.GoRight(this.Tank2)));
        #endregion Delegate commands


        #region Debug
        private DelegateCommand debugCommand;
        public DelegateCommand DebugCommand => this.debugCommand ?? (this.debugCommand = new DelegateCommand(this.Debug));


        private void GoUp(ActionModel model)
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
        private void GoDown(ActionModel model)
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
        private void GoLeft(ActionModel model)
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
        private void GoRight(ActionModel model)
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


        private void Debug()
        {
            new Tank().Initialize(this.BattleField);
        }
        #endregion
    }
}
