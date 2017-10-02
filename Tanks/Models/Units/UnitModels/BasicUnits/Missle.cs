using System;
using Tanks.ActionModels;
using Tanks.Manager.Action;
using Tanks.Manager.Action.Managers;
using Tanks.Models.Units.Interfaces;

namespace Tanks.Models.Units.UnitModels.BasicUnits
{
    public abstract class Missle : AbstractUnit, ISolid, IMissile
    {
        public Missle(Coordinates coordinates) : base(coordinates)
        {
        }

        public virtual void Interact(
            MotionManager motionManager,
            DestructionManager destructionManager,
            BattleField battleField,
            Dirrection modelDirrection,
            Dirrection motionDirrection, Action stopAction)
        {
            var result = motionManager.Move(this, motionDirrection);

            CoordinatesManager coordinatesManager = new CoordinatesManager(battleField.Size);

            Coordinates coords = coordinatesManager.GetCoordinates(this.Coordinates, motionDirrection);

            if (!result && coords != null)
            {
                var field = battleField[coords].Unit;
                if (field != null)
                {
                    destructionManager.WhatToDestroy(field);
                    destructionManager.Destroy(this);
                    stopAction();
                }
            }
            else if (!result)
            {
                destructionManager.Destroy(this);
                stopAction();
            }
        }
    }
}