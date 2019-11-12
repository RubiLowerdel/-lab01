using System;
using System.Collections.Generic;
using System.Text;

namespace ZooAdmin.Domain
{
    public class Food 
    {
        public string Name { get; private set; }
        public int Weight { get; private set; }

        public ListOfAnimals ListAnimals { get; private set; }

        public void ChangeWeight(int w)
        {
            Weight = w;
        }


        public Food(string name, int weight, ListOfAnimals aviaryFor)
        {

            if (String.IsNullOrEmpty(name) || weight == 0)
            {
                throw new ArgumentNullException();
            }
            Name = name;
            Weight = weight;
            ListAnimals = aviaryFor;



        }

    }
}
