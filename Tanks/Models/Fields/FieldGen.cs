using System;
using System.Reflection;
using Tanks.Models.Fields.FieldTypes;
using TraversalLib;

namespace Tanks.Models.Fields
{
    public static class FieldGen
    {
        public static AbstractField GenerateInstance(this FieldState? state, Coordinates coordinates)
        {
             var type =  Assembly.GetExecutingAssembly().GetTypes().First<Type>(t=>t.BaseType==typeof(AbstractField)&&((AbstractField)Activator.CreateInstance(t,coordinates)).FieldPointState==state);
             AbstractField field = (AbstractField)Activator.CreateInstance(type, coordinates);
             return field;

        }
    }
}