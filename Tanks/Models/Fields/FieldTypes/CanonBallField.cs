using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Models.Fields.FieldTypes
{
    class CanonBallField : AbstractField
    {
        public CanonBallField(int x, int y) : this(new Coordinates(x,y)){ }
        public CanonBallField(Coordinates coordinates) : base(coordinates, FieldState.CannonBall)
        {
        }

        public override void Intercept(AbstractField field)
        {
           
        }
    }
}
