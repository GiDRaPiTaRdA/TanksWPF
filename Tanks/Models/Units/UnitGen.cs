using System;
using System.Linq;
using System.Reflection;
using Tanks.Models.Units.UnitModels;
using TraversalLib;

namespace Tanks.Models.Units
{
    public static class UnitGen
    {
        public static AbstractUnit GenerateInstance(this UnitState? state, Coordinates coordinates)
        {
             var type =  TREXCS.First<Type>(
                 Assembly.GetExecutingAssembly().GetTypes()
                 .Where(ty=>ty.GetCustomAttribute(typeof(UnitStateAttribute))!=null).ToArray(),
                 t=> ((UnitStateAttribute)t.GetCustomAttribute(typeof(UnitStateAttribute))).State==state);

             AbstractUnit unit = (AbstractUnit)Activator.CreateInstance(type, coordinates);
             return unit;

        }
    }
}