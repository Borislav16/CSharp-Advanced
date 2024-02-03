using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Frog : Animal
    {
        public Frog(string name, int age, string gender) : base(name, age, gender)
        {
        }
        public override string ProduceSound()
        {
            return "Ribbit";
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Frog");
            stringBuilder.AppendLine($"{Name} {Age} {Gender}");
            stringBuilder.Append(ProduceSound());

            return stringBuilder.ToString();

        }
    }
}
