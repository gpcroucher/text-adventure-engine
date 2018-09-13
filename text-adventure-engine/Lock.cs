using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    class Lock : Thing
    {
        private Thing matchingKey;
        public Thing Key
        {
            get
            {
                return matchingKey;
            }
        }

        private bool isLocked = false;
        

        public Lock(string inputName, Thing newKey = null, bool newIsLocked = false) : base(inputName)
        {
            matchingKey = newKey;
            isLocked = newIsLocked;
        }

        public Thing CreateKey()
        {
            if (matchingKey == null)
            {
                matchingKey = new Thing($"key to {name}");
            }
            return matchingKey;
        }

        public void ForceLock()
        {
            isLocked = true;
        }

        public void ForceUnlock()
        {
            isLocked = false;
        }

        public bool LockWithKey(Thing key)
        {
            if (key == matchingKey && !isLocked)
            {
                isLocked = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetKey (Thing newKey)
        {
            matchingKey = newKey;
        }

        public bool UnlockWithKey(Thing key)
        {
            if (key == matchingKey && isLocked)
            {
                isLocked = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
