using System;
using Tanks.ActionModels;
using Tanks.Manager.Action;
using Tanks.Models.Units.UnitModels.BasicUnits;

namespace Tanks.Models.Units.UnitModels.Missles
{
    [UnitState(UnitState.RemoteContolledMissle)]
    public class RemoteControlledCannonBallMissle :Missle
    {
        public RemoteControlledCannonBallMissle(Coordinates coordinates) : base(coordinates){}

        public override void Interact(MotionManager motionManager, DestructionManager destructionManager,
            Dirrection modelDirrection,
            Dirrection motionDirrection, Action stopAction)
        {
            var result = motionManager.Move(this, modelDirrection);

            CoordinatesManager coordinatesManager = new CoordinatesManager(motionManager.BattleField.Size);

            Coordinates coords = coordinatesManager.GetCoordinates(this.Coordinates, modelDirrection);

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