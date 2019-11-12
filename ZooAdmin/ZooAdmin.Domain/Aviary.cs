using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ZooAdmin.Domain
{
    public class Aviary 
    {
        
        public ListOfAnimals ListAnimals { get; private set; }
        public Guid Id { get; private set; }

        public int Number { get; private set; }

        public Aviary(int number, ListOfAnimals animal) 
        {
            Number = number;
            ListAnimals = animal;
            Id = Guid.NewGuid();

            //  if (id is  )
            //  {
            //      throw new ArgumentNullException();
            //  }
        }

        public List<Animal> Animals
        {

            get
            {
                var result = new List<Animal>();
                foreach (var aviary in Base.Aviaries.Values)
                {
                    foreach (var animal in Base.Animals.Values)
                    {
                        if (aviary.ListAnimals == animal.ListAnimals)
                            result.Add(animal);
                    }
                }

                return result;
            }
        }

    }
    
}
