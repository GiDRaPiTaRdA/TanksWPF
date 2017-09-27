using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tanks.Models;
using Tanks.Models.Fields;
using Tanks.Models.Fields.FieldTypes;
using TraversalLib;

namespace Tanks.ActionModels
{
    public class ModelMap
    {
        public Dirrection Dirrection { get; private set;}
        public FieldState?[,] ModelPattern { get; private set; }

        public AbstractField[,] ModelFields { get; }

        public ModelMap(ModelMap modelMap) : this(modelMap.ModelPattern,modelMap.Dirrection,modelMap.ModelFields) { }

        public ModelMap(FieldState?[,] pattetn,Dirrection dirrection = Dirrection.Forward, AbstractField[,] map = null)
        {
            this.ModelPattern = pattetn;
           
            this.Dirrection = dirrection;

            this.ModelFields = map ?? new AbstractField [this.ModelPattern.GetLength(0),this.ModelPattern.GetLength(1)];
        }
    }
}
