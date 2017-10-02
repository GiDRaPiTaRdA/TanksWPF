using System.Linq;
using Tanks.ActionModels;
using Tanks.Models;
using Tanks.Models.Units.UnitModels;
using TraversalLib;

namespace Tanks.Manager.Action
{
    public class DestructionManager
    {
        private BattleField BattleField { get; set; }

        public DestructionManager(BattleField battleField)
        {
            this.BattleField = battleField;
        }

        public void WhatToDestroy(AbstractUnit unit)
        {
            var model = this.BattleField.Models.FirstOrDefault(m => m.Value.ModelMap.ModelUnits.Any<AbstractUnit>(f => f == unit)).Value;
            if (model != null)
            {
                this.Destroy(model);
            }
            else
            {
                this.Destroy(unit);
            }
        }

        public void Destroy(AbstractUnit unit)
        {
            if (ActionManager.CanAct(unit, this.BattleField))
            {
                this.BattleField.PopField(unit);
            }
        }

        public void Destroy(ActionModel model)
        {
            if (ActionManager.CanAct(model, this.BattleField))
            {
                this.BattleField.PopModel(model);
            }
        }

    }
}