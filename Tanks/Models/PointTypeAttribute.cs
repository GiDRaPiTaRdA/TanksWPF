using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Models.Dictionary;

namespace Tanks.Models
{
    class PointTypeAttribute :Attribute
    {
        public PointTypeAttribute(FieldPointState state,DictionaryType key)
        {
            this.State = state;
            this.Key = key;
        }

        public DictionaryType Key { get; set; }
        public FieldPointState State { get; set; }
    }
}
