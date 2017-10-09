using System;
using Tanks.ActionModels;
using Tanks.Manager.Action.Managers;
using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels.BasicUnits;

namespace Tanks.Models.Units.UnitModels.MissleBehaviors
{
    public class BrickBehavior : IMissleBehavior
    {
        public bool IsRemoteControlled { get; set; }

        public void Interact(AbstractUnit unit, MotionManager motionManager, DestructionManager destructionManager,
            BattleField battleField, Dirrection modelDirrection, Dirrection motionDirrection, Action stopAction)
        {
            Dirrection dirrection = this.IsRemoteControlled ? modelDirrection : motionDirrection;

            var result = motionManager.Move(unit, dirrection);

            if (!result)
            {
                stopAction();
            }
        }
    }
}