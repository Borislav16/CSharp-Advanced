﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Rectangle Draw");
        }

        public int Width { get; set; }
        public int Height { get; set; }
    }
}
