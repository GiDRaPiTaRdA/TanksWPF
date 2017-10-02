using System;
using Tanks.ActionModels;
using Tanks.Manager.Action;
using Tanks.Manager.Action.Managers;

namespace Tanks.Models.Units.Interfaces
{
    public interface IMissile
    {
        void Interact(
            MotionManager motionManager,
            DestructionManager destructionManager,
            BattleField battleField,
            Dirrection modelDirrection,
            Dirrection motionDirrection, Action stopAction);
    }
}