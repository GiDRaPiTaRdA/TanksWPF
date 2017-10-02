using System;
using Tanks.Models.Units;

namespace Tanks.Dictionary
{
    class ResourceTypeAttribute :Attribute
    {
        public ResourceTypeAttribute(UnitState state,DictionaryType key)
        {
            this.State = state;
            this.Key = key;
        }

        public DictionaryType Key { get; set; }
        public UnitState State { get; set; }
    }
}
