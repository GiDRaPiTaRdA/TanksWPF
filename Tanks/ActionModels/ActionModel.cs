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

       

        protected ActionModel(ModelMap modelMap)
        {
            this.ModelMap = modelMap;
        }
    }
}
