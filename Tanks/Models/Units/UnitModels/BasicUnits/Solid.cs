using System.Runtime.Serialization;
using Tanks.Models.Units.Interfaces;

namespace Tanks.Models.Units.UnitModels.BasicUnits
{
    public abstract class Solid :AbstractUnit,ISolid
    {
        protected Solid(Coordinates coordinates = null) : base(coordinates){}
    }
}