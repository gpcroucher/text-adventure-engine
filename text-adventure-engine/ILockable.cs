using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    interface ILockable
    {
        Lock AttachedLock { get; }

        void Lock();
        void Lock(Thing key);
        void Unlock();
        void Unlock(Thing key);
    }
}
