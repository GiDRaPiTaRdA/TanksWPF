using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Manager;
using Tanks.Models;

namespace Tanks.ActionModels
{
    public abstract class ActionModel
    {
        public ActionModel(ModelMap modelMap)
        {
            this.ModelMap = modelMap;
        }

        public ModelMap ModelMap { get; }

        public void TurnFront()
        {
            ModelMap.AimMap(Dirrection.Forward);
        }

        public void TurnBack()
        {
            ModelMap.AimMap(Dirrection.Backward);
        }

        public void TurnLeft()
        {
            ModelMap.AimMap(Dirrection.Left);
        }
        public void TurnRight()
        {
            ModelMap.AimMap(Dirrection.Right);
        }

    }
}
