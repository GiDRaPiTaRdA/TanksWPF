using Tanks.Models.Units.Interfaces;

namespace Tanks.Models.Units.UnitModels
{
    [UnitState(UnitState.TankEnemy)]
    public class TankEnemyUnit : AbstractUnit, ISolid
    {
        public TankEnemyUnit(int x, int y) : this(new Coordinates(x, y)) { }
        public TankEnemyUnit(Coordinates coordinate) : base(coordinate) { }
    }

}