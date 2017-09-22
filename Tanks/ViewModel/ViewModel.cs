using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Tanks.ActionModels.RealModels;
using Tanks.Manager;
using Tanks.Models;
using Tanks.Models.Fields;
using TraversalLib;

namespace Tanks
{
    class ViewModel
    {
       // public TankField Tank { get; set; }

        public Tank Tank { get; set; }

        public BattleField BattleField { get; }

        public MotionManager MovementManager { get; }

        public ViewModel()
        {
            this.BattleField = new BattleField(20, 20);
            this.MovementManager = new MotionManager(this.BattleField);

            this.BattleField.SetSlot(new TankField(0,0));

            this.Tank = new Tank();

            Tank.Initialize(this.BattleField);
        }

        #region Delegate commands

        private DelegateCommand moveUpCommand;
        private DelegateCommand moveRightCommand;
        private DelegateCommand moveDownCommand;
        private DelegateCommand moveLeftCommand;


        //public DelegateCommand MoveUpCommand => moveUpCommand ?? (moveUpCommand = new DelegateCommand(() => this.MovementManager.MoveUp(this.Tank)));
        //public DelegateCommand MoveDownCommand => moveDownCommand ?? (moveDownCommand = new DelegateCommand(() => this.MovementManager.MoveDown(this.Tank)));
        //public DelegateCommand MoveLeftCommand => moveLeftCommand ?? (moveLeftCommand = new DelegateCommand(() => this.MovementManager.MoveLeft(this.Tank)));
        //public DelegateCommand MoveRightCommand => moveRightCommand ?? (moveRightCommand = new DelegateCommand(() => this.MovementManager.MoveRight(this.Tank)));

        public DelegateCommand MoveUpCommand => moveUpCommand ?? (moveUpCommand = new DelegateCommand(() => Tank.TurnFront()));
        public DelegateCommand MoveDownCommand => moveDownCommand ?? (moveDownCommand = new DelegateCommand(() => Tank.TurnBack()));
        public DelegateCommand MoveLeftCommand => moveLeftCommand ?? (moveLeftCommand = new DelegateCommand(() => Tank.TurnLeft()));
        public DelegateCommand MoveRightCommand => moveRightCommand ?? (moveRightCommand = new DelegateCommand(() => Tank.TurnRight()));


        #endregion Delegate commands


        #region Debug
        private DelegateCommand debugCommand;
        public DelegateCommand DebugCommand => debugCommand ?? (debugCommand = new DelegateCommand(Debug));

        private void Debug()
        {


            Tank.TurnRight();

            //tank.ModelMap

           // tank.ModelMap.Initialize(this.BattleField);
        }
        #endregion
    }
}
