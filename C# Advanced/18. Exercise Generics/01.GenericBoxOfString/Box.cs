using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GenericBoxOfString
{
    internal class Box<T>
    {
        private T generic;

        public Box(T generic)
        {
            this.generic = generic;
        }
        
        public override string ToString()
        {
            return $"{typeof(T)}: {generic}";
        }
    }
}
