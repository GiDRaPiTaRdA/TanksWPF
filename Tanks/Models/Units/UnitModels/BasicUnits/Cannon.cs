using Tanks.Models.Units.Interfaces;

namespace Tanks.Models.Units.UnitModels.BasicUnits
{
    public abstract class Cannon: AbstractUnit, ISolid
    {
        public Cannon(Coordinates coordinates) : base(coordinates)
        {
        }

        public abstract Missle GetMissle(Coordinates coordinates);
    }
}