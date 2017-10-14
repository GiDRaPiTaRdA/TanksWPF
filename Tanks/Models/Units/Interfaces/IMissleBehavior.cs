using System;
using System.Linq.Expressions;
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

        void Collide(
             AbstractUnit unit,
             Dirrection motionDirrection,
             Expression<Func<Dirrection>> modelDirrectionExpression,
             MotionManager motionManager,
             DestructionManager destructionManager,
             BattleField battleField,
             Action stopAction);

        void Fire(
             AbstractUnit unit,
             Dirrection motionDirrection,
             Expression<Func<Dirrection>> modelDirrectionExpression,
             MotionManager motionManager,
             DestructionManager destructionManager,
             BattleField battleField,
             Action stopAction);
    }
}