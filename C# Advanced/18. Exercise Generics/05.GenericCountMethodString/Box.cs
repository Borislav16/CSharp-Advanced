using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GenericCountMethodString
{
    internal class Box<T> where T : IComparable<T>
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

        public int Count(T compare)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (item.CompareTo(compare) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
