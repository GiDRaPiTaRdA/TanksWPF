using System.Collections.Generic;
using Tanks.Models.Units.UnitModels.BasicUnits;

namespace Tanks.Models.Units.Interfaces
{
    public interface ICannon
    {
        Missle GetMissle(Coordinates coordinates);
    }
}