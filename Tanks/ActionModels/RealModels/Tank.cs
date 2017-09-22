using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Models;

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
        private static FieldState[,] Map =>
                (new FieldState[,]
                            {
                                {FieldState.EmptyField,FieldState.TankField,FieldState.TankField },
                                {FieldState.TankField,FieldState.TankField,FieldState.EmptyField },
                                {FieldState.EmptyField,FieldState.TankField,FieldState.TankField }
                            }
                        );

        public Tank() : base(new ModelMap(Map))
        {
        }


    }
}
