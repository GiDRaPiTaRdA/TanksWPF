using System;
using System.Linq;
using Tanks.ActionModels;
using Tanks.Models;
using Tanks.Models.Units.UnitModels;
using TraversalLib;

namespace Tanks.Manager.Action.Managers
{
    public class DestructionManager :AbstractManagerBase
    {
        public DestructionManager(BattleField battleField) : base(battleField) { }

        public event EventHandler OnDestroyUnit;
        public event EventHandler OnDestroyModel;

        /// <summary>
        /// Destroies Unit or model according "does unit belongs model or not"
        /// </summary>
        /// <param name="unit"></param>
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
                this.OnDestroyUnit?.Invoke(unit, null);
            }
        }

        public void Destroy(ActionModel model)
        {
            if (ActionManager.CanAct(model, this.BattleField))
            {
                this.BattleField.PopModel(model);
                this.OnDestroyModel?.Invoke(model, null);
            }
        }
    }
}