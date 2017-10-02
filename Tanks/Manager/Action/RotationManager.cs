using System;
using Tanks.ActionModels;
using Tanks.Models;
using Tanks.Models.Units.UnitModels;
using TraversalLib;

namespace Tanks.Manager.Action
{
    public class RotationManager
    {
        private BattleField BattleField { get; set; }

        public RotationManager(BattleField battleField)
        {
            this.BattleField = battleField;
        }


        private void RotateModel(ActionModel model, Dirrection dirrection)
        {
            if (ActionManager.CanAct(model,this.BattleField))
            {
                // Pop Model
                this.BattleField.PopModel(model);

                // Rotate Model
                model.ModelMap = this.AimMap(model.ModelMap, dirrection);

                // Push Model
                this.BattleField.PushModel(model);
            }
        }

        public void RotateForward(ActionModel model)
        {
            this.RotateModel(model, Dirrection.Forward);
        }

        public void RotateLeft(ActionModel model)
        {
            this.RotateModel(model, Dirrection.Left);
        }

        public void RotateRight(ActionModel model)
        {
            this.RotateModel(model, Dirrection.Right);
        }

        public void RotateBackward(ActionModel model)
        {
            this.RotateModel(model, Dirrection.Backward);
        }


        /// <summary>
        /// Сумашедшый алгоритм
        /// </summary>
        /// <param name="currentMap"></param>
        /// <param name="targetDirrecion"></param>
        /// <returns></returns>
        private ModelMap AimMap(ModelMap currentMap, Dirrection targetDirrecion)
        {
            Dirrection currentDirrection = currentMap.Dirrection;

            if (targetDirrecion == currentDirrection)
                return currentMap;

            int dirrectionDeltaValue = targetDirrecion - currentDirrection;
            int remainder = dirrectionDeltaValue % 2;

            ModelMap aimedMap;

            // Mirror
            if (remainder == 0)
            {
                int currentDirrectionReminder = (int)currentDirrection % 2;

                switch (currentDirrectionReminder)
                {
                    case 0:
                        // Vertical mirror
                        aimedMap = new ModelMap(currentMap.ModelPattern, targetDirrecion, this.RotateWithNull(currentMap.ModelUnits, Array2DManager.MirrorVertical));
                        break;
                    case 1:
                        // Horisontal mirror
                        aimedMap = new ModelMap(currentMap.ModelPattern, targetDirrecion, this.RotateWithNull(currentMap.ModelUnits, Array2DManager.MirrorHorisontal));
                        break;
                    default:
                        throw new Exception("Algorithmic Error");
                }
            }
            //Rotation
            else
            {
                int integerDivision = Math.Abs(dirrectionDeltaValue / 2);

                int switchCoeficient = (integerDivision != 0) ? -(integerDivision) * remainder : remainder;

                switch (switchCoeficient)
                {
                    case 1:
                        // Right
                        aimedMap = new ModelMap(currentMap.ModelPattern, targetDirrecion, this.RotateWithNull(currentMap.ModelUnits, Array2DManager.RotateRight));

                        break;
                    case -1:
                        // Left
                        aimedMap = new ModelMap(currentMap.ModelPattern, targetDirrecion, this.RotateWithNull(currentMap.ModelUnits, Array2DManager.RotateLeft));
                        break;
                    default:
                        throw new Exception("Algorithmic Error");
                }
            }

            return aimedMap;
        }

        private AbstractUnit[,] RotateWithNull(AbstractUnit[,] array, Func<AbstractUnit[,], AbstractUnit[,]> rotate)
        {
            // Rotate array
            var rotatedArray = rotate(array);

            // Create array
            Coordinates[,] coords = new Coordinates[rotatedArray.GetLength(0), rotatedArray.GetLength(1)];

            // Clone coords
            array.Traversal((o, ps) => coords[ps[0], ps[1]] = new Coordinates(array[ps[0], ps[1]].Coordinates));

            // Paste coords
            coords.Traversal((o, ps) => rotatedArray[ps[0], ps[1]].Coordinates = (Coordinates)o);


            return rotatedArray;
        }
    }
}