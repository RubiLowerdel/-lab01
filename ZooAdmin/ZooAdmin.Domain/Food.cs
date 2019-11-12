using System;
using System.Collections.Generic;
using System.Text;

namespace ZooAdmin.Domain
{
    public class Food : Base
    {
        
        public int Weight { get; private set; }

        public ListOfAnimals ListAnimals { get; private set; }

        public void ChangeWeight(int w)
        {
            Weight = w;
        }

        
        public Food(string name, int weight, ListOfAnimals aviaryFor) : base(name)
        {

            if (String.IsNullOrEmpty(name) || weight == 0)
            {
                throw new ArgumentNullException();
            }
            
            Weight = weight;
            ListAnimals = aviaryFor;



        }

    }
}
