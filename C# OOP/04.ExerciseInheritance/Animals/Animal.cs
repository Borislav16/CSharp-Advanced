using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Animal
    {
        private string name;
		private int age;
        private string gender;
        public Animal(string name,int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get
            {
                return name ;
            }
            private set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                name = value ;
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }

        public int Age
		{
			get 
            {
                return age; 
            }
			set 
            {
                if(value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                } 
                age = value;
            }
		}
        public virtual string ProduceSound()
        {
            return "";
        }
        
    }
}
