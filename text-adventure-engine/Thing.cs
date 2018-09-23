using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    class Thing : IMovable
    {
        public string Name { get; protected set; }
        public decimal weight = 0;
        public Room Location { get; protected set; }
        public bool IsMovable { get; protected set; }
        public bool IsTakeable { get; protected set; }
        public Type IntendedType { get; protected set; }

        public void Move(Room destination)
        {
            if (IsMovable)
            {
                Location = destination;
            }
        }

        public void Rename (string newName)
        {
            Name = newName;
        }

        public Thing (string inputName)
        {
            Name = inputName;
            IsMovable = true;
            IntendedType = typeof(Thing);
        }
    }


}
