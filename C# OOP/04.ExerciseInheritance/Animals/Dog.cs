using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string gender) : base(name, age, gender)
        {
        }
        public override string ProduceSound()
        {
            return "Woof!";
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Dog");
            stringBuilder.AppendLine($"{Name} {Age} {Gender}");
            stringBuilder.Append(ProduceSound());

            return stringBuilder.ToString();

        }
    }
}
