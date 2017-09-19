using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Tanks.Manager;
using Tanks.Models;
using Tanks.Models.Fields;
using TraversalLib;

namespace Tanks
{
    class ViewModel
    {
        public TankField Tank { get; set; }

        public BattleField BattleField { get; }

        public MotionManager MovementManager { get; }

        public ViewModel()
        {
            this.BattleField = new BattleField(20, 20);
            this.MovementManager = new MotionManager(this.BattleField);

            this.Tank = new TankField(0, 0);
            this.BattleField.SetSlot(this.Tank);


            int[,] array = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };

            var result = Array2DManager.MirrorVertical(array);
        }

        #region Delegate commands

        private DelegateCommand moveUpCommand;
        private DelegateCommand moveRightCommand;
        private DelegateCommand moveDownCommand;
        private DelegateCommand moveLeftCommand;

        public DelegateCommand MoveUpCommand => moveUpCommand ?? (moveUpCommand = new DelegateCommand(() => this.MovementManager.MoveUp(this.Tank)));
        public DelegateCommand MoveDownCommand => moveDownCommand ?? (moveDownCommand = new DelegateCommand(() => this.MovementManager.MoveDown(this.Tank)));
        public DelegateCommand MoveLeftCommand => moveLeftCommand ?? (moveLeftCommand = new DelegateCommand(() => this.MovementManager.MoveLeft(this.Tank)));
        public DelegateCommand MoveRightCommand => moveRightCommand ?? (moveRightCommand = new DelegateCommand(() => this.MovementManager.MoveRight(this.Tank)));

        #endregion Delegate commands

    }
}
