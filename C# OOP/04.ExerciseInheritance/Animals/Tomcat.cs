﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age) : base(name, age, "Male")
        {
        }
        public override string ProduceSound()
        {
            return "MEOW";
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Tomcat");
            stringBuilder.AppendLine($"{Name} {Age} {Gender}");
            stringBuilder.Append(ProduceSound());

            return stringBuilder.ToString();

        }
    }
}
