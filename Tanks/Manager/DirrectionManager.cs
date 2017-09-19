using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.ActionModels;

namespace Tanks.Manager
{
    public static class DirrectionManager
    {
        public static ModelMap AimMap(this ModelMap currentMap, Dirrection targetDirrecion)
        {
            Dirrection currentDirrection = currentMap.Dirrection;

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
                        aimedMap = new ModelMap(Array2DManager.MirrorVertical(currentMap.Map));
                        break;
                    case 1:
                        // Horisontal mirror
                        aimedMap = new ModelMap(Array2DManager.MirrorHorisontal(currentMap.Map));
                        break;
                    default:
                        throw new Exception("Algorithmic Error");
                }
            }
            //Rotation
            else
            {
                int integerDivision = dirrectionDeltaValue / 2;

                int switchCoeficient = (integerDivision > 0) ? (-1) * remainder : remainder;

                switch (switchCoeficient)
                {
                    case 1:
                        // Right
                        aimedMap = new ModelMap(Array2DManager.RotateRight(currentMap.Map));
                        break;
                    case -1:
                        // Left
                        aimedMap = new ModelMap(Array2DManager.RotateLeft(currentMap.Map));
                        break;
                    default:
                        throw new Exception("Algorithmic Error");
                }
            }

            throw new NotImplementedException();
        }
    }
}
