using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("Shape draw");
        }
    }
}
