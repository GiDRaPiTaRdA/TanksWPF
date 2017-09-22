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

namespace Tanks.ActionModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class ActionModel
    {
        public ActionModel(ModelMap modelMap)
        {
            this.ModelMap = modelMap;
        }

        public ModelMap ModelMap { get; set; }

        private void OnModelMapChanged()
        {
            this.BattleField?.SetMap(this.ModelMap);
        }

        public BattleField BattleField { get; private set; }

        #region Movement
        public void TurnFront()
        {
            ModelMap = ModelMap.AimMap(Dirrection.Forward);
        }
        public void TurnBack()
        {
            ModelMap = ModelMap.AimMap(Dirrection.Backward);
        }
        public void TurnLeft()
        {
            ModelMap = ModelMap.AimMap(Dirrection.Left);
        }
        public void TurnRight()
        {
            ModelMap = ModelMap.AimMap(Dirrection.Right);
        }
        #endregion

        #region should be placed in other class

        public static FieldState[] AllowedToSpawn => new FieldState[] { FieldState.EmptyField };
        public static FieldState[] Ignored => new FieldState[] { FieldState.EmptyField };

        public void Initialize(BattleField battleField)
        {
            this.BattleField = battleField;

            //var temp = battleField.SpotsMatrix.First<FieldSlot>(o=>CheckCanSpawn(o.State,o.Field.Coordinates));

            FieldSlot temp = FindOrigiSlotForInsert(battleField);

            if (temp != null)
            {
                Spawn(battleField, temp.Field.Coordinates);
            }
            else
            {
                throw new Exception("no space to spawn");
            }

        }
        private FieldSlot FindOrigiSlotForInsert(BattleField battleField)
        {
            FieldSlot slot = null;

            int RangeX = battleField.Size.X - ModelMap.ModelFields.GetLength(0) + 1;
            int RangeY = battleField.Size.Y - ModelMap.ModelFields.GetLength(1) + 1;

            for (int i = 0; i < RangeX; i++)
            {
                for (int j = 0; j < RangeY; j++)
                {
                    var fieldSlot = battleField[i, j];

                    var result = CheckCanSpawn(battleField, fieldSlot.Field.Coordinates);

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

            for (int i = 0; i < ModelMap.ModelPattern.GetLength(0); i++)
            {
                for (int j = 0; j < ModelMap.ModelPattern.GetLength(1); j++)
                {
                    Coordinates bfCoords = new Coordinates(i + coordinates.X, j + coordinates.Y);



                    //result &= ModelPattern[i, j] != bf[bfCoords].State;
                    result &= AllowedToSpawn.Any(state => bf[bfCoords].State == state) || ModelMap.ModelPattern[i, j] != bf[bfCoords].State; ;



                    if (!result)
                        return false;
                }
            }

            return result;
        }

        public void Spawn(BattleField battleField, Coordinates coordinates)
        {
            for (int i = 0; i < ModelMap.ModelPattern.GetLength(0); i++)
            {
                for (int j = 0; j < ModelMap.ModelPattern.GetLength(1); j++)
                {
                    // Ignore 
                    if (Ignored.Any(state => ModelMap.ModelPattern[i, j] == state))
                    {
                        continue;
                    }

                    Type type = Type.GetType(typeof(AbstractField).Namespace + "." + ModelMap.ModelPattern[i, j].ToString());

                    if (type != null)
                    {
                        AbstractField field = (AbstractField)Activator.CreateInstance(type, new Coordinates(i + coordinates.X, j + coordinates.Y));

                        // Add to ModelsFields
                        ModelMap.ModelFields[i, j] = field;

                        // Set to BattleField
                        battleField.SetSlot(field);
                    }
                }
            }
        }
        #endregion

    }
}
