using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Citizen : IIdentifiable,IBirthable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

        public string Birthday { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
