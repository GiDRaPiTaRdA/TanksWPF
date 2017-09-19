using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Models;

namespace Tanks.ActionModels
{
    public class ModelMap
    {
        public Dirrection Dirrection { get; private set;}

        public FieldState[,] Map { get; private set; }

        public ModelMap(ModelMap modelMap) : this(modelMap.Map) { }

        public ModelMap(FieldState[,] map)
        {
            this.Map = map;
            this.Dirrection = Dirrection.Forward;
        }

    }
}
