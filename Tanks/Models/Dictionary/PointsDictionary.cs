using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tanks.Models.Dictionary
{
    static class FieldsDictionary
    {
        [PointType(FieldPointState.EmptyField,DictionaryType.Color)] public static Color FPColorEmpty => Colors.White;
        [PointType(FieldPointState.TankField, DictionaryType.Color)] public static Color FPColorTank => Colors.Black;

        public static object GetDictionaryElement(FieldPointState state,DictionaryType key)
        {
            var propsInfo = typeof(FieldsDictionary).GetProperties()
                .Where(
                p => p.GetCustomAttribute<PointTypeAttribute>().Key == key &&
                p.GetCustomAttribute<PointTypeAttribute>().State == state
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
