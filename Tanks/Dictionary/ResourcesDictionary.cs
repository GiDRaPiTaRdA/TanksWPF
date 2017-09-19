using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tanks.Models.Dictionary
{
    static class ResourcesDictionary
    {
        [ResourceType(FieldState.EmptyField,DictionaryType.Color)] public static Color FPColorEmpty => Colors.White;
        [ResourceType(FieldState.TankField, DictionaryType.Color)] public static Color FPColorTank => Colors.Black;

        public static object GetDictionaryElement(FieldState state,DictionaryType key)
        {
            var propsInfo = typeof(ResourcesDictionary).GetProperties()
                .Where(
                p => p.GetCustomAttribute<ResourceTypeAttribute>().Key == key &&
                p.GetCustomAttribute<ResourceTypeAttribute>().State == state
                );

            if (propsInfo.Count() > 1)
                throw new Exception("Dictionary has same attribute key properies");

            if (propsInfo.Count() == 0)
                throw new Exception("Dictionary has no such attribute key properies");

            var result = propsInfo.First().GetValue(null);

            return result;
        }
    }
}
