using System;
using System.Linq.Expressions;
using Tanks.ActionModels;
using Tanks.Manager.Action.Managers;
using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels.BasicUnits;

namespace Tanks.Models.Units.UnitModels.MissleBehaviors
{
    public class BrickBehavior : IMissleBehavior
    {
        public bool IsRemoteControlled { get; set; }

        public void Collide(
            AbstractUnit unit,
            Dirrection motionDirrection,
            Expression<Func<Dirrection>> modelDirrectionExpression,
            MotionManager motionManager,
            DestructionManager destructionManager,
            BattleField battleField,
            Action stopAction)
        {
            Dirrection dirrection = this.IsRemoteControlled ? modelDirrectionExpression.Compile().Invoke() : motionDirrection;

            if (!battleField[unit.Coordinates].Unit.Equals(unit))
            {
                stopAction();
            }

            else
            {
                var result = motionManager.Move(unit, dirrection);

                if (!result)
                {
                    stopAction();
                }
            }
        }

        public void Fire(
            AbstractUnit unit,
            Dirrection motionDirrection,
            Expression<Func<Dirrection>> modelDirrectionExpression,
            MotionManager motionManager,
            DestructionManager destructionManager,
            BattleField battleField,
            Action stopAction)
        {
            if (!(battleField[unit.Coordinates].Unit is ISolid))
            {
                battleField[unit.Coordinates].Push(unit);
            }
        }
    }
}