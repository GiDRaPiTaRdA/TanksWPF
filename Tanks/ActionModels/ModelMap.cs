using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tanks.Models;
using Tanks.Models.Units;
using Tanks.Models.Units.UnitModels;
using TraversalLib;

namespace Tanks.ActionModels
{
    public class ModelMap
    {
        public Dirrection Dirrection { get; private set;}
        public UnitState?[,] ModelPattern { get; private set; }

        public AbstractUnit[,] ModelUnits { get; }

        public ModelMap(ModelMap modelMap) : this(modelMap.ModelPattern,modelMap.Dirrection,modelMap.ModelUnits) { }

        public ModelMap(UnitState?[,] pattetn,Dirrection dirrection = Dirrection.Forward, AbstractUnit[,] map = null)
        {
            this.ModelPattern = pattetn;
           
            this.Dirrection = dirrection;

            this.ModelUnits = map ?? new AbstractUnit [this.ModelPattern.GetLength(0),this.ModelPattern.GetLength(1)];
        }
    }
}
