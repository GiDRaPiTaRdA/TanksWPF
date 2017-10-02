using System;
using System.Linq;
using Tanks.ActionModels;
using Tanks.Models;
using Tanks.Models.Units;
using Tanks.Models.Units.UnitModels;

namespace Tanks.Manager.Action.Managers
{
    public class SpawnManager : AbstractManagerBase
    {
        private static UnitState[] AllowedToSpawn => new[] { UnitState.EmptyUnit };

        public SpawnManager(BattleField battleField) : base(battleField) { }

        public void Initialize(ActionModel model)
        {
            UnitSlot temp = this.FindOrigiSlotForInsert(model);

            if (temp != null)
            {
                this.Spawn(model, temp.Unit.Coordinates);
            }
            else
            {
                throw new Exception("no space to spawn");
            }

        }

        private void Spawn(ActionModel model,  Coordinates coordinate)
        {
            for (int i = 0; i < model.ModelMap.ModelPattern.GetLength(0); i++)
            {
                for (int j = 0; j < model.ModelMap.ModelPattern.GetLength(1); j++)
                {
                    Coordinates coordinates = new Coordinates(i + coordinate.X, j + coordinate.Y);

                    if (model.ModelMap.ModelPattern[i, j] != null)
                    {
                        AbstractUnit unit = model.ModelMap.ModelPattern[i, j].GenerateInstance(coordinates);

                        // Add to ModelsFields
                        model.ModelMap.ModelUnits[i, j] = unit;

                        // Set to BattleField
                        //battleField.PushField(unit);
                    }
                    else
                    {
                        model.ModelMap.ModelUnits[i, j] = new NullUnit(coordinates);
                    }
                }
            }
            this.BattleField.PushModel(model);
        }

        private UnitSlot FindOrigiSlotForInsert(ActionModel model)
        {
            UnitSlot slot = null;

            int RangeX = this.BattleField.Size.X - model.ModelMap.ModelUnits.GetLength(0) + 1;
            int RangeY = this.BattleField.Size.Y - model.ModelMap.ModelUnits.GetLength(1) + 1;

            for (int i = 0; i < RangeX; i++)
            {
                for (int j = 0; j < RangeY; j++)
                {
                    var fieldSlot = this.BattleField[i, j];

                    var result = this.CheckCanSpawn(model, fieldSlot.Unit.Coordinates);

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

        private bool CheckCanSpawn(ActionModel model, Coordinates coordinates)
        {
            bool result = true;

            for (int i = 0; i < model.ModelMap.ModelPattern.GetLength(0); i++)
            {
                for (int j = 0; j < model.ModelMap.ModelPattern.GetLength(1); j++)
                {
                    Coordinates bfCoords = new Coordinates(i + coordinates.X, j + coordinates.Y);

                    result &= AllowedToSpawn.Any(state => this.BattleField[bfCoords].State == state);

                    if (!result)
                        break;
                }
                if (!result)
                    break;
            }

            return result;
        }
    }
}