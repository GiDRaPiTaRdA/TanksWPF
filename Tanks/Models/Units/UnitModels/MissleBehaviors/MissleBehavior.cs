using System;
using Tanks.ActionModels;
using Tanks.Manager.Action.Managers;
using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels.BasicUnits;

namespace Tanks.Models.Units.UnitModels.MissleBehaviors
{
    public class MissleBehavior : IMissleBehavior
    {
        public bool IsRemoteControlled { get; set; }

        public void Interact(Solid unit,
          MotionManager motionManager,
          DestructionManager destructionManager,
          BattleField battleField,
          Dirrection modelDirrection,
          Dirrection motionDirrection,
          Action stopAction)
        {
            Dirrection dirrection = this.IsRemoteControlled ? modelDirrection : motionDirrection;

            var result = motionManager.Move(unit, dirrection);

            CoordinatesManager coordinatesManager = new CoordinatesManager(battleField.Size);

            Coordinates coords = coordinatesManager.GetCoordinates(unit.Coordinates, dirrection);

            if (!result && coords != null)
            {
                var field = battleField[coords].Unit;
                if (field != null)
                {
                    destructionManager.WhatToDestroy(field);
                    destructionManager.Destroy(unit);
                    stopAction();
                }
            }
            else if (!result)
            {
                destructionManager.Destroy(unit);
                stopAction();
            }
        }
    }
}