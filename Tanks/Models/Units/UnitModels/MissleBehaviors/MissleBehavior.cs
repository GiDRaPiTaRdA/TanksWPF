using System;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using Tanks.ActionModels;
using Tanks.Manager.Action.Managers;
using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels.BasicUnits;

namespace Tanks.Models.Units.UnitModels.MissleBehaviors
{
    public class MissleBehavior : IMissleBehavior
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
            Dirrection dirrection = this.IsRemoteControlled
                ? modelDirrectionExpression.Compile().Invoke()
                : motionDirrection;

            CoordinatesManager coordinatesManager = new CoordinatesManager(battleField.Size);

            Coordinates coords = coordinatesManager.GetCoordinates(unit.Coordinates, dirrection);


            if (coords != null)
            {
                AbstractUnit nextUnit = battleField[coords].Unit;

                var result = motionManager.Move(unit, dirrection);

                // Hit solid object
                if (!result)
                {
                    if (nextUnit is ISolid)
                    {
                        // Destroy object
                        destructionManager.WhatToDestroy(nextUnit);

                        // Self destruct
                        destructionManager.Destroy(unit);
                    }
                }
            }
            // Reached the end of battlefield
            else
            {
                destructionManager.Destroy(unit);
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
            else
            {
                destructionManager.WhatToDestroy(battleField[unit.Coordinates].Unit);

                stopAction();
            }
        }
    }
}
