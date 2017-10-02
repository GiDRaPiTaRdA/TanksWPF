using Tanks.Models.Units;

namespace Tanks.ActionModels.RealModels
{
    public class TankEnemy :ActionModel
    {
        private static UnitState?[,] Map =>
              new UnitState?[,]
                          {
                                {null,UnitState.TankEnemy,UnitState.TankEnemy },
                                {UnitState.DefaultCannon,UnitState.TankEnemy,null },
                                {null,UnitState.TankEnemy,UnitState.TankEnemy }
                          }
                      ;

        public TankEnemy() : base(new ModelMap(Map))
        {
        }
    }
}