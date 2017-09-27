using System;
using Tanks.Models.Fields;

namespace Tanks.Dictionary
{
    class ResourceTypeAttribute :Attribute
    {
        public ResourceTypeAttribute(FieldState state,DictionaryType key)
        {
            this.State = state;
            this.Key = key;
        }

        public DictionaryType Key { get; set; }
        public FieldState State { get; set; }
    }
}
