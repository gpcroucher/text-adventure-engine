using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    class Lock : Thing
    {
        protected Thing matchingKey;
        public Thing Key
        {
            get
            {
                return matchingKey;
            }
        }

        protected bool isLocked = false;
        public bool IsLocked
        {
            get
            {
                return isLocked;
            }
        }
        
        public Lock(string inputName, Thing newKey = null, bool newIsLocked = false) : base(inputName)
        {
            matchingKey = newKey;
            isLocked = newIsLocked;
        }

        public Thing CreateKey()
        {
            if (matchingKey == null)
            {
                matchingKey = new Thing($"key to {Name}");
            }
            return matchingKey;
        }

        public static Lock EmptyLock()
        {
            return new Lock("lock", null, false);
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
