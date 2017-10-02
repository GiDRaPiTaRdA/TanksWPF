using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Tanks.Manager;
using Tanks.Models;
using PropertyChanged;
using Tanks.Models.Units;
using Tanks.Models.Units.UnitModels;

namespace Tanks.ActionModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class ActionModel
    {
        public ModelMap ModelMap { get; set; }

        private static UnitState[] AllowedToSpawn => new[] { UnitState.EmptyUnit };

        protected ActionModel(ModelMap modelMap)
        {
            this.ModelMap = modelMap;
        }


        #region Initialize & Spawn
        public void Initialize(BattleField battleField)
        {
            UnitSlot temp = this.FindOrigiSlotForInsert(battleField);

            if (temp != null)
            {
                this.Spawn(battleField, temp.Unit.Coordinates);
            }
            else
            {
                throw new Exception("no space to spawn");
            }

        }

        private void Spawn(BattleField battleField, Coordinates coordinate)
        {
            for (int i = 0; i < this.ModelMap.ModelPattern.GetLength(0); i++)
            {
                for (int j = 0; j < this.ModelMap.ModelPattern.GetLength(1); j++)
                {
                    Coordinates coordinates = new Coordinates(i + coordinate.X, j + coordinate.Y);

                    if (this.ModelMap.ModelPattern[i, j] != null)
                    {
                        AbstractUnit unit = this.ModelMap.ModelPattern[i, j].GenerateInstance(coordinates);

                        // Add to ModelsFields
                        this.ModelMap.ModelUnits[i, j] = unit;

                        // Set to BattleField
                        //battleField.PushField(unit);
                    }
                    else
                    {
                        this.ModelMap.ModelUnits[i, j] = new NullUnit(coordinates);
                    }
                }
            }
            battleField.PushModel(this);
        }

        private UnitSlot FindOrigiSlotForInsert(BattleField battleField)
        {
            UnitSlot slot = null;

            int RangeX = battleField.Size.X - this.ModelMap.ModelUnits.GetLength(0) + 1;
            int RangeY = battleField.Size.Y - this.ModelMap.ModelUnits.GetLength(1) + 1;

            for (int i = 0; i < RangeX; i++)
            {
                for (int j = 0; j < RangeY; j++)
                {
                    var fieldSlot = battleField[i, j];

                    var result = this.CheckCanSpawn(battleField, fieldSlot.Unit.Coordinates);

                    if (result)
                    {
                        slot = fieldSlot;
                        break;
                    }

                }
                if (slot != null)
                {
                    break;
                }
            }
            return slot;
        }

        private bool CheckCanSpawn(BattleField bf, Coordinates coordinates)
        {
            bool result = true;

            for (int i = 0; i < this.ModelMap.ModelPattern.GetLength(0); i++)
            {
                for (int j = 0; j < this.ModelMap.ModelPattern.GetLength(1); j++)
                {
                    Coordinates bfCoords = new Coordinates(i + coordinates.X, j + coordinates.Y);

                    result &= AllowedToSpawn.Any(state => bf[bfCoords].State == state) ; 

                    if (!result)
                        break;
                }
                if (!result)
                    break;
            }

            return result;
        }
        #endregion

    }
}
