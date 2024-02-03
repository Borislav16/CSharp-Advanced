using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age) : base(name, age, "Female")
        {

        }

        public override string ProduceSound()
        {
            return "Meow";
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Kitten");
            stringBuilder.AppendLine($"{Name} {Age} {Gender}");
            stringBuilder.Append(ProduceSound());

            return stringBuilder.ToString();

        }
    }
}
