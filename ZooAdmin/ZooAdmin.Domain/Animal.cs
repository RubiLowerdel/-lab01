using System;
using System.Collections.Generic;
using System.Globalization;

namespace ZooAdmin.Domain
{
    public class Animal : Base
    {
        public bool Hungry { get; private set; }


        public TypeOfAnimals TypeOfAnimals { get; private set; }


        public TypeOfAnimalsOnTutrion TypeOfAnimalsOnTutrion { get; private set; }

        public DateTimeOffset YearOfBirth { get; private set; }

        public int Age { get; private set; }

        

        public ListOfAnimals ListAnimals { get; private set; }



        public void ChangeHungry(bool hungry)
        {
            Hungry = hungry;
        }





        public Animal(Guid id, string name, DateTimeOffset yearOfBirth, int age, TypeOfAnimals typeOfAnimals, TypeOfAnimalsOnTutrion typeOfAnimalsOnTutrion, ListOfAnimals aviaryFor) : base(id, name)
        {


            Age = age;
            ListAnimals = aviaryFor;
            YearOfBirth = yearOfBirth;
            TypeOfAnimals = typeOfAnimals;

            TypeOfAnimalsOnTutrion = typeOfAnimalsOnTutrion;

           


            if (String.IsNullOrEmpty(name) || yearOfBirth == null)
            {
                throw new ArgumentNullException();
            }


        }



        public override string ToString()
        {
            return base.ToString() + "(" + YearOfBirth + ")";
        }


    }

}
/* створити клас в якому  описати те, що залежно від того, яка тварина\мясоїдна, всеїдна, росл\ давати їй той тип їжі і скільки їжі іж хватає для ситості, тобто 1 кг м'яса на 1 годину і потім вона знову голодає */
