using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Models;
using Tanks.Models.Units;

namespace Tanks.ActionModels.RealModels
{
    public class Tank : ActionModel
    {

        /// <summary>
        /// TankMap
        /// _ X X
        /// X X _
        /// _ X X
        /// </summary>
        private static UnitState?[,] Map =>
                new UnitState?[,]
                            {
                                {null,UnitState.Tank,UnitState.Tank },
                                {UnitState.DefaultCannon,UnitState.Tank,null },
                                {null,UnitState.Tank,UnitState.Tank }
                            }
                        ;            

        public Tank() : base(new ModelMap(Map))
        {
        }


    }
}
