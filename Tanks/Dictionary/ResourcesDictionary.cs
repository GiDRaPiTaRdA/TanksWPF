using System;
using System.Linq;
using System.Reflection;
using System.Windows.Media;
using Tanks.Models;
using Tanks.Models.Fields;

namespace Tanks.Dictionary
{
    static class ResourcesDictionary
    {
        [ResourceType(FieldState.EmptyField,DictionaryType.Color)] public static Color FpColorEmpty => Colors.White;
        [ResourceType(FieldState.TankField, DictionaryType.Color)] public static Color FpColorTank => Colors.Black;
        [ResourceType(FieldState.GrassField, DictionaryType.Color)]public static Color FpColorGrass => Colors.GreenYellow;

        public static object GetDictionaryElement(FieldState state,DictionaryType key)
        {
            var propsInfo = typeof(ResourcesDictionary).GetProperties()
                .Where(
                p => p.GetCustomAttribute<ResourceTypeAttribute>().Key == key &&
                p.GetCustomAttribute<ResourceTypeAttribute>().State == state
                );

            if (propsInfo.Count() > 1)
                throw new Exception("Dictionary has same attribute key properies");

            if (!propsInfo.Any())
                throw new Exception("Dictionary has no such attribute key properies");

            var result = propsInfo.First().GetValue(null);

            return result;
        }
    }
}
