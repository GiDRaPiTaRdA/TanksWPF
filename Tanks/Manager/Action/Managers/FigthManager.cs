using System;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Timers;
using Tanks.ActionModels;
using Tanks.Models;
using Tanks.Models.Units;
using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels;
using Tanks.Models.Units.UnitModels.BasicUnits;
using TraversalLib;

namespace Tanks.Manager.Action.Managers
{
    public class FigthManager : AbstractManagerBase
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
            if (this.CanFire(model))
            {
                model.ModelMap.ModelUnits
                    .Where<AbstractUnit>(f => f is ICannon).ToArray()
                    .ForEach<AbstractUnit>(
                        f =>
                        {
                            var coords = this.CoordinatesManager.GetCoordinates(f.Coordinates, model.ModelMap.Dirrection);

                            if (coords != null)
                            {
                                Missle missle = (f as ICannon).GetMissle(coords);

                                if (missle != null)
                                {
                                    new Motion(
                                            missle,
                                            model.ModelMap.Dirrection,
                                            () => model.ModelMap.Dirrection,
                                            this.MotionManager,
                                            this.DestructionManager,
                                            this.BattleField
                                            ).Start();
                                }
                            }

                        });
            }
        }

        public bool CanFire(ActionModel model)
        {
            bool result = ActionManager.CanAct(model, this.BattleField);
            return result;
        }

       
    }


}