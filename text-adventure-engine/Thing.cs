using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    class Thing
    {
        public string name;
        public decimal weight;

        public bool isMoveable = true;

        public Thing (string inputName)
        {
            name = inputName;
        }
    }
}
