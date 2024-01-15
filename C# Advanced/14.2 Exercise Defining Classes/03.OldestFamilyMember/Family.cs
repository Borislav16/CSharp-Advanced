using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            people = new List<Person>();
        }
        public List<Person> people { get; set; }

        public void AddMember(Person person)
        {
            people.Add(person);
        }

        public Person GetOldestMember()
        {
            Person oldest = people.OrderByDescending(c => c.Age).FirstOrDefault();
            return oldest;
        }
    }
}
