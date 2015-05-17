using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool
{
    /// <summary>
    /// The Pool class is the most important class in the object pool design pattern. It controls access to the
    /// pooled objects, maintaining a list of available objects and a collection of objects that have already been
    /// requested from the pool and are still in use. The pool also ensures that objects that have been released
    /// are returned to a suitable state, ready for the next time they are requested. 
    /// </summary>
    public static class Pool
    {
        private static SynchronizedCollection<PooledObject> avaiable = new SynchronizedCollection<PooledObject>();
        private static SynchronizedCollection<PooledObject> inUse = new SynchronizedCollection<PooledObject>();

        public static PooledObject GetObject()
        {
            PooledObject po = null;
            if (avaiable.Count == 0)
            {
                po = new PooledObject();
                inUse.Add(po);
            }
            else
            {
                po = avaiable[0];
                inUse.Add(po);
                avaiable.RemoveAt(0);
            }
            return po;
        }

        public static void ReleaseObject(PooledObject po)
        {
            CleanUp(po);
            avaiable.Add(po);
            inUse.Remove(po);
        }

        private static void CleanUp(PooledObject po)
        {
            po.TempData = null;
        }
    }
}
