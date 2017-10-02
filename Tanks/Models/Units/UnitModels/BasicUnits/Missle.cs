using System;
using Tanks.ActionModels;
using Tanks.Manager.Action;
using Tanks.Models.Units.Interfaces;

namespace Tanks.Models.Units.UnitModels.BasicUnits
{
    public abstract class Missle : AbstractUnit, ISolid, IMissile
    {
        public Missle(Coordinates coordinates) : base(coordinates)
        {
        }

        public virtual void Interact(MotionManager motionManager, DestructionManager destructionManager,
            Dirrection modelDirrection,
            Dirrection motionDirrection, Action stopAction)
        {
            var result = motionManager.Move(this, motionDirrection);

            CoordinatesManager coordinatesManager = new CoordinatesManager(motionManager.BattleField.Size);

            Coordinates coords = coordinatesManager.GetCoordinates(this.Coordinates, motionDirrection);

            if (!result && coords != null)
            {
                var field = motionManager.BattleField[coords].Unit;
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