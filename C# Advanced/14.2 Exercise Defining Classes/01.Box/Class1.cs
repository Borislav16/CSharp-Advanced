using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public T Remove()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove item: the list is empty");
            }

            T item = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return item;
        }

        public int Count
        {
            get { return list.Count; }
        }
    }
}