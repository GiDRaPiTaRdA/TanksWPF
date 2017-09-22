using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.ActionModels;
using TraversalLib;

namespace Tanks.Manager
{
    public static class DirrectionManager
    {
        /// <summary>
        /// Сумашедшый алгоритм
        /// </summary>
        /// <param name="currentMap"></param>
        /// <param name="targetDirrecion"></param>
        /// <returns></returns>
        public static ModelMap AimMap(this ModelMap currentMap, Dirrection targetDirrecion)
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
                        aimedMap = new ModelMap(currentMap.ModelPattern, targetDirrecion, currentMap.ModelFields.Rotate(Array2DManager.MirrorVertical));
                        break;
                    case 1:
                        // Horisontal mirror
                        aimedMap = new ModelMap(currentMap.ModelPattern, targetDirrecion, currentMap.ModelFields.Rotate(Array2DManager.MirrorHorisontal));
                        break;
                    default:
                        throw new Exception("Algorithmic Error");
                }
            }
            //Rotation
            else
            {
                int integerDivision = Math.Abs(dirrectionDeltaValue / 2);

                int switchCoeficient = (integerDivision != 0)? -(integerDivision) * remainder:remainder;

                switch (switchCoeficient)
                {
                    case 1:
                        // Right
                        aimedMap = new ModelMap(currentMap.ModelPattern, targetDirrecion, currentMap.ModelFields.Rotate(Array2DManager.RotateRight));

                        break;
                    case -1:
                        // Left
                        aimedMap = new ModelMap(currentMap.ModelPattern, targetDirrecion, currentMap.ModelFields.Rotate(Array2DManager.RotateLeft));
                        break;
                    default:
                        throw new Exception("Algorithmic Error");
                }
            }

            return aimedMap;
        }
    }
}
