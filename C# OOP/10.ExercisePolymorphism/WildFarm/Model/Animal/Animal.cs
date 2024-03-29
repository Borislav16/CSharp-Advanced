﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Model.Interfaces;

namespace WildFarm.Model.Animal
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract double WeightMultiplier { get; }

        public abstract IReadOnlyCollection<Type> PreferredFoods { get;}

        public void Eat(IFood food)
        {
            if(!PreferredFoods.Any(pf => food.GetType().Name == pf.Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * WeightMultiplier;

            FoodEaten += food.Quantity;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }
    }
}
