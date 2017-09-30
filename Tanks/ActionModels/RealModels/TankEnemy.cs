using Tanks.Models.Fields;

namespace Tanks.ActionModels.RealModels
{
    public class TankEnemy :ActionModel
    {
        private static FieldState?[,] Map =>
              new FieldState?[,]
                          {
                                {null,FieldState.TankEnemy,FieldState.TankEnemy },
                                {FieldState.TankEnemy,FieldState.TankEnemy,null },
                                {null,FieldState.TankEnemy,FieldState.TankEnemy }
                          }
                      ;

        public TankEnemy() : base(new ModelMap(Map))
        {
        }
    }
}