using System;
using System.Security.Cryptography.X509Certificates;
using Tanks.ActionModels;
using Tanks.Manager.Action.Managers;
using Tanks.Models.Units.UnitModels;
using Tanks.Models.Units.UnitModels.BasicUnits;

namespace Tanks.Models.Units.Interfaces
{
    public interface IMissleBehavior
    {
        bool IsRemoteControlled { get; set; }

        void Interact(
             Solid unit,
             MotionManager motionManager,
             DestructionManager destructionManager,
             BattleField battleField,
             Dirrection modelDirrection,
             Dirrection motionDirrection, Action stopAction);
    }
}