using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Tanks.Models.Fields;

namespace Tanks
{
    class ViewModel
    {
        public int Size => 10;

        public int FPS => 60;

        public bool [,] Flags { get; set; }

        public ViewModel()
        {
            this.Flags = new bool[10,10];
            this.Flags[0, 1] = true;
        }

    }
}
