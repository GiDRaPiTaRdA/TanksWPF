using System;
using System.Linq;
using System.Reflection;
using System.Windows.Media;
using Tanks.Models;
using Tanks.Models.Units;

namespace Tanks.Dictionary
{
    static class ResourcesDictionary
    {
        [ResourceType(UnitState.EmptyUnit,DictionaryType.Color)] public static Color FpColorEmpty => Colors.White;
        [ResourceType(UnitState.Tank, DictionaryType.Color)] public static Color FpColorTank => Colors.Black;
        [ResourceType(UnitState.TankEnemy, DictionaryType.Color)]public static Color FpColorTankEnemy => Colors.Orange;
        [ResourceType(UnitState.Grass, DictionaryType.Color)]public static Color FpColorGrass => Colors.GreenYellow;
        [ResourceType(UnitState.Wall, DictionaryType.Color)] public static Color FpColorWall => Colors.DimGray;

        [ResourceType(UnitState.DefaultCannon, DictionaryType.Color)]public static Color FpColorCannon => Colors.CornflowerBlue;
        [ResourceType(UnitState.CannonBallMissle, DictionaryType.Color)]public static Color FpColorCannonBall => Colors.Red;


        [ResourceType(UnitState.BrickCannon, DictionaryType.Color)]public static Color FpColorBrickCannon => Colors.CornflowerBlue;
        [ResourceType(UnitState.BrickMissle, DictionaryType.Color)]public static Color FpColorBrickMissle => Colors.SaddleBrown;


        public static object GetDictionaryElement(UnitState state,DictionaryType key)
        {
            var propsInfo = typeof(ResourcesDictionary).GetProperties()
                .Where(
                p => p.GetCustomAttribute<ResourceTypeAttribute>().Key == key &&
                p.GetCustomAttribute<ResourceTypeAttribute>().State == state
                );

            if (propsInfo.Count() > 1)
                throw new Exception("Dictionary has same attribute key properies"+"Key :"+key+" State :"+state);

            if (!propsInfo.Any())
                throw new Exception("Dictionary has no such attribute key properies");

            var result = propsInfo.First().GetValue(null);

            return result;
        }
    }
}
