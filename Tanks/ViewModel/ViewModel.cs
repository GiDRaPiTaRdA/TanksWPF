using System.Threading;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Tanks.ActionModels;
using Tanks.ActionModels.RealModels;
using Tanks.Manager;
using Tanks.Manager.Action;
using Tanks.Manager.Action.Managers;
using Tanks.Models;
using Tanks.Models.Units.UnitModels;
using Tanks.Models.Units.UnitModels.Cannons;
using TraversalLib;

// ReSharper disable MemberCanBePrivate.Global

namespace Tanks.ViewModel
{
    class ViewModel
    {
        public Tank Tank { get; set; }
        public TankEnemy Tank2 { get; set; }

        public TankUnit Tank1 { get; set; }

        public BattleField BattleField { get; }

        private ActionManager ActionManager { get; }

        public ViewModel()
        {
            // Initialize
            this.BattleField = new BattleField(20, 20);
            this.ActionManager = new ActionManager(this.BattleField);

            // Logic
            this.Tank = new Tank();
            this.Tank2 = new TankEnemy();
            this.Tank1 = new TankUnit(5, 6);

            this.ActionManager.Spawn(this.Tank);
            this.ActionManager.Spawn(this.Tank2);

            //WeaponManager weaponManager = new WeaponManager(this.BattleField);

            //weaponManager.ChangeWeapon<BrickCannon>(this.Tank);


            this.BattleField.PushField(this.Tank1);

            this.BattleField.PushField(new GrassUnit(0, 0));
            this.BattleField.PushField(new GrassUnit(5, 5));

            this.BattleField.PushField(new WallUnit(6, 6));
            this.BattleField.PushField(new WallUnit(6, 7));
            this.BattleField.PushField(new WallUnit(6, 8));
            this.BattleField.PushField(new WallUnit(6, 9));
        }

        #region Delegate commands

        private DelegateCommand moveUpCommand;
        private DelegateCommand moveRightCommand;
        private DelegateCommand moveDownCommand;
        private DelegateCommand moveLeftCommand;

        public DelegateCommand MoveUpCommand => this.moveUpCommand ?? (this.moveUpCommand = new DelegateCommand(() => this.ActionManager.GoUp(this.Tank)));
        public DelegateCommand MoveDownCommand => this.moveDownCommand ?? (this.moveDownCommand = new DelegateCommand(() => this.ActionManager.GoDown(this.Tank)));
        public DelegateCommand MoveLeftCommand => this.moveLeftCommand ?? (this.moveLeftCommand = new DelegateCommand(() => this.ActionManager.GoLeft(this.Tank)));
        public DelegateCommand MoveRightCommand => this.moveRightCommand ?? (this.moveRightCommand = new DelegateCommand(() => this.ActionManager.GoRight(this.Tank)));


        private DelegateCommand moveUpCommandQ;
        private DelegateCommand moveRightCommandQ;
        private DelegateCommand moveDownCommandQ;
        private DelegateCommand moveLeftCommandQ;

        public DelegateCommand MoveUpCommandQ => this.moveUpCommandQ ?? (this.moveUpCommandQ = new DelegateCommand(() => this.ActionManager.GoUp(this.Tank1)));
        public DelegateCommand MoveDownCommandQ => this.moveDownCommandQ ?? (this.moveDownCommandQ = new DelegateCommand(() => this.ActionManager.GoDown(this.Tank1)));
        public DelegateCommand MoveLeftCommandQ => this.moveLeftCommandQ ?? (this.moveLeftCommandQ = new DelegateCommand(() => this.ActionManager.GoLeft(this.Tank1)));
        public DelegateCommand MoveRightCommandQ => this.moveRightCommandQ ?? (this.moveRightCommandQ = new DelegateCommand(() => this.ActionManager.GoRight(this.Tank1)));

        //public DelegateCommand MoveUpCommandQ => this.moveUpCommandQ ?? (this.moveUpCommandQ = new DelegateCommand(() => this.ActionManager.GoUp(this.Tank2)));
        //public DelegateCommand MoveDownCommandQ => this.moveDownCommandQ ?? (this.moveDownCommandQ = new DelegateCommand(() => this.ActionManager.GoDown(this.Tank2)));
        //public DelegateCommand MoveLeftCommandQ => this.moveLeftCommandQ ?? (this.moveLeftCommandQ = new DelegateCommand(() => this.ActionManager.GoLeft(this.Tank2)));
        //public DelegateCommand MoveRightCommandQ => this.moveRightCommandQ ?? (this.moveRightCommandQ = new DelegateCommand(() => this.ActionManager.GoRight(this.Tank2)));

        #endregion Delegate commands


        #region Debug
        private DelegateCommand debugCommand;
        public DelegateCommand DebugCommand => this.debugCommand ?? (this.debugCommand = new DelegateCommand(this.Debug));


        private void Debug()
        {
            this.ActionManager.Fire(this.Tank);

            
        }
        #endregion
    }
}
