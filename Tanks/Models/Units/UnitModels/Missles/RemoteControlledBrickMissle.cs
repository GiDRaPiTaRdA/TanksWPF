using System;
using Tanks.ActionModels;
using Tanks.Manager.Action;
using Tanks.Models.Units.UnitModels.BasicUnits;

namespace Tanks.Models.Units.UnitModels.Missles
{
    [UnitState(UnitState.RemoteControlledBrickMissle)]
    public class RemoteControlledBrickMissle :Missle
    {
        public RemoteControlledBrickMissle(Coordinates coordinates) : base(coordinates){}

        public override void Interact(MotionManager motionManager, DestructionManager destructionManager, Dirrection modelDirrection,
           Dirrection motionDirrection, Action stopAction)
        {
            var result = motionManager.Move(this, modelDirrection);

            if (!result)
            {
                stopAction();
            }
        }
    }
}