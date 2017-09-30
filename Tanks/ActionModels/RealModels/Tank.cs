using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Models;
using Tanks.Models.Fields;

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
        private static FieldState?[,] Map =>
                new FieldState?[,]
                            {
                                {null,FieldState.Tank,FieldState.Tank },
                                {FieldState.Tank,FieldState.Tank,null },
                                {null,FieldState.Tank,FieldState.Tank }
                            }
                        ;            

        public Tank() : base(new ModelMap(Map))
        {
        }


    }
}
