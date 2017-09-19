using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Models.Dictionary;

namespace Tanks.Models
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
