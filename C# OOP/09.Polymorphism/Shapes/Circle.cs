﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Circle Draw");
        }

        public int Radius { get; set; }
    }
}
