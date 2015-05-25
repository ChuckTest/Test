using System;

namespace ObjectPool
{
    /// <summary>
    /// The PooledObject class is the type that is expensive or slow to instantiate,
    /// or that has limited availability, so is to be held in the object pool.
    /// </summary>
    public class PooledObject
    {
        private DateTime createdAt = DateTime.Now;
        public DateTime CreatedAt
        {
            get { return createdAt; }
        }

        public string TempData { get; set; }
    }
}
