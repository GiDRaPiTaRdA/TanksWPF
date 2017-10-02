using System;
using Tanks.ActionModels;
using Tanks.Manager.Action;

namespace Tanks.Models.Units.Interfaces
{
    public interface IMissile
    {
        void Interact(MotionManager motionManager, DestructionManager destructionManager, Dirrection modelDirrection, Dirrection motionDirrection,Action stopAction);
    }
}