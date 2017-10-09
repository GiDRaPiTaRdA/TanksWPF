using System;
using System.Collections.Generic;
using System.Linq;
using Tanks.ActionModels;
using Tanks.Models;
using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels;
using Tanks.Models.Units.UnitModels.BasicUnits;
using TraversalLib;

namespace Tanks.Manager.Action.Managers
{
    public class WeaponManager : AbstractManagerBase
    {
        public WeaponManager(BattleField battleField) : base(battleField)
        {
        }

        public void ChangeWeapon<TWeapon>(ActionModel model) where TWeapon : ICannon
        {

            model.ModelMap.ModelUnits.Traversal((o, ps) =>
            {
                AbstractUnit unit = (AbstractUnit) o;

                if (o is ICannon)
                {

                    this.BattleField[unit.Coordinates].Pop(unit);
                    this.BattleField[unit.Coordinates].Push((AbstractUnit) Activator.CreateInstance(typeof (TWeapon), unit.Coordinates));

                    model.ModelMap.ModelUnits[ps[0], ps[1]] = this.BattleField[unit.Coordinates].Unit;
                }

            });
        }
    }
}