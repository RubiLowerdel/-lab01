using System;
using System.Collections.Generic;
using System.Text;

namespace ZooAdmin.Domain
{
    public class Ration
    {
        public Food Food { get; private set; }

        public ListOfAnimals ListAnimals { get; private set; }

        public int WeightPortion { get; private set; }

        public int Coefficient { get; private set; }
        public Guid Id { get; private set; }

        public void Weight(int w)
        {
            WeightPortion = w;
        }
        public void Coef(int c)
        {
            Coefficient = c;
        }
        public List<DateTimeOffset> Eating  = new List<DateTimeOffset>();


        public Ration(Food food,  ListOfAnimals animalFor) {
            Food = food;

            Id = Guid.NewGuid();
            ListAnimals = animalFor;

        }
    }
}
