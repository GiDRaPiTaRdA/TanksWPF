using Tanks.Models.Fields.Interfaces;

namespace Tanks.Models.Fields.FieldTypes
{
    public class TankEnemyField : AbstractField, ISolid
    {
        public TankEnemyField(int x, int y) : this(new Coordinates(x, y)) { }
        public TankEnemyField(Coordinates coordinate) : base(coordinate, FieldState.TankEnemy) { }
    }

}