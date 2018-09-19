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
        public decimal weight = 0;
        public Room location;

        protected bool isMoveable = true;
        public bool IsMoveable
        {
            get
            {
                return isMoveable;
            }
        }

        public Thing (string inputName)
        {
            name = inputName;
        }
    }
}
