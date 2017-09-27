using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Manager;
using Tanks.Models;
using Tanks.Models.Fields;
using PropertyChanged;
using Tanks.Models.Fields.FieldTypes;

namespace Tanks.ActionModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class ActionModel
    {
        public ModelMap ModelMap { get; set; }

        private static FieldState[] AllowedToSpawn => new[] { FieldState.EmptyField };

        protected ActionModel(ModelMap modelMap)
        {
            this.ModelMap = modelMap;
        }

        #region Initialize & Spawn
        public void Initialize(BattleField battleField)
        {
            FieldSlot temp = this.FindOrigiSlotForInsert(battleField);

            if (temp != null)
            {
                this.Spawn(battleField, temp.Field.Coordinates);
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

                        string typeString = typeof(AbstractField).Namespace + "." + this.ModelMap.ModelPattern[i, j];

                        Type type = Type.GetType(typeString);

                        AbstractField field =
                            (AbstractField)
                                Activator.CreateInstance(type, coordinates);

                        // Add to ModelsFields
                        this.ModelMap.ModelFields[i, j] = field;

                        // Set to BattleField
                        battleField.PushField(field);
                    }
                    else
                    {
                        this.ModelMap.ModelFields[i, j] = new NullField(coordinates);
                    }
                }
            }
        }

        private FieldSlot FindOrigiSlotForInsert(BattleField battleField)
        {
            FieldSlot slot = null;

            int RangeX = battleField.Size.X - this.ModelMap.ModelFields.GetLength(0) + 1;
            int RangeY = battleField.Size.Y - this.ModelMap.ModelFields.GetLength(1) + 1;

            for (int i = 0; i < RangeX; i++)
            {
                for (int j = 0; j < RangeY; j++)
                {
                    var fieldSlot = battleField[i, j];

                    var result = this.CheckCanSpawn(battleField, fieldSlot.Field.Coordinates);

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



                    //result &= ModelPattern[i, j] != bf[bfCoords].State;
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
