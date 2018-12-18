using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public class LimitedList<T> : IEnumerable<T>
    {
        private readonly int capacity;
        private readonly List<T> items = new List<T>();

        public LimitedList(int capacity)
        {
            this.capacity = capacity;
        }

        /// <summary>
        /// Overload of square brackt operator
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>An instance of type T</returns>
        public T this[int i] { get => items[i]; }
      
        public int Capacity { get => capacity; }
        public int Count { get => items.Count;  }

        public bool Add(T item)
        {
            if(items.Count < Capacity)
            {
                items.Add(item);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes the item from the list if the item exists.
        /// </summary>
        /// <param name="item">The item to remove</param>
        /// <returns>true if item was removed otherwise false</returns>
        public bool Remove(T item) => items.Remove(item);

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Must be implemented even if it is not used
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
