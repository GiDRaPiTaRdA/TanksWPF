using System;
using System.Linq;
using System.Timers;
using Tanks.ActionModels;
using Tanks.Models;
using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels;
using Tanks.Models.Units.UnitModels.BasicUnits;
using TraversalLib;

namespace Tanks.Manager.Action.Managers
{
    public class FigthManager:AbstractManagerBase
    {
        private DestructionManager DestructionManager { get; }
        private MotionManager MotionManager { get; }
        private CoordinatesManager CoordinatesManager { get; }

        public FigthManager(BattleField battleField) : base(battleField) 
        {
            this.MotionManager = new MotionManager(this.BattleField);
            this.DestructionManager = new DestructionManager(this.BattleField);
            this.CoordinatesManager = new CoordinatesManager(this.BattleField.Size);
        }

        public void Fire(ActionModel model)
        {
            model.ModelMap.ModelUnits
                .Where<AbstractUnit>(f => f is Cannon).ToArray()
                .ForEach<AbstractUnit>(
                f =>
                {
                    var coords = this.CoordinatesManager.GetCoordinates(f.Coordinates, model.ModelMap.Dirrection);

                    if (coords != null && !(this.BattleField[coords].Unit is ISolid))
                    {
                        Missle missle = (f as Cannon).GetMissle(coords);

                        this.BattleField.PushField(missle);

                        new Motion(missle, model.ModelMap.Dirrection,
                            (m, motionDirrection, stopAction) => m.Interact(
                                this.MotionManager,
                                this.DestructionManager,
                                this.BattleField,
                                model.ModelMap.Dirrection,
                                motionDirrection,
                                stopAction
                                )
                                ).Start();
                    }
                });
        }

    }

    class Motion
    {
        readonly Timer timer;
        IMissile Missle { get; }
        Dirrection MotionDirrection { get; }

        public Motion(IMissile missle, Dirrection motionDirrection, Action<IMissile, Dirrection, System.Action> interact, int frequancy = 200)
        {
            this.Missle = missle;
            this.MotionDirrection = motionDirrection;
            this.timer = new Timer { Interval = frequancy };
            this.timer.Elapsed += (o, s) => interact(this.Missle, this.MotionDirrection, this.Stop);
        }

        public void Start()
        {
            this.timer.Start();
        }

        public void Stop()
        {
            this.timer.Stop();
        }
    }
}