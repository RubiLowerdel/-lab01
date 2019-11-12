using System;
using System.Collections.Generic;
using ZooAdmin.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;

namespace ZooAdmin
{
    class Program
    {

        public static List<DateTimeOffset> dateTimes = new List<DateTimeOffset>();
        public static List<Animal> HungryAnimal = new List<Animal>();
        static void Main(string[] args)
        {


            Console.WriteLine("Ви зайшли в програму по управлiнню зоопарком. Можете тут нагодувати тварин, які голодні");
            Console.WriteLine("Котра зараз година?");
            DateTimeOffset time = DateTimeOffset.Now;
            DateTimeOffset timeutc = DateTimeOffset.UtcNow;
            int hourUtc = time.Hour - timeutc.Hour;
            int minuteUtc = time.Minute - timeutc.Minute;
            Console.WriteLine(time.Hour + ":" + time.Minute + ", UTC : " + 2 + ":" + minuteUtc);
        
            Aviary aviaryNumber1 = new Aviary(1, ListOfAnimals.Jaguars);
            Base.Aviaries.Add(aviaryNumber1.Id, aviaryNumber1);
            Aviary aviaryNumber2 = new Aviary(2, ListOfAnimals.Tigers);
            Base.Aviaries.Add(aviaryNumber2.Id, aviaryNumber2);


            Food meat = new Food("М'ясо", 39, ListOfAnimals.Jaguars);
            Base.Foods.Add(meat);


            Ration forTigers = new Ration(meat, ListOfAnimals.Tigers);
            Base.Rations.Add(forTigers.Id, forTigers);
            Ration forJaguars = new Ration(meat, ListOfAnimals.Jaguars);
            Base.Rations.Add(forJaguars.Id, forJaguars);


            //І'мя, cкільки років, який вольєр, який тип тварин, коли їсть вранці, коли їсть вечером, тип живлення, що саме, чи голодна
            Animal animalZebra = new Animal(Guid.NewGuid(),
                                            "Майя",
                                            new DateTimeOffset(2000, 11, 4, 11, 02, 55, new TimeSpan(hourUtc, minuteUtc, 0)),
                                            (int)((time - new DateTimeOffset(2000, 11, 4, 11, 02, 55, new TimeSpan(hourUtc, minuteUtc, 0))).TotalDays / 365),
                                            TypeOfAnimals.Mammals,
                                            TypeOfAnimalsOnTutrion.Herbivores,
                                            ListOfAnimals.Tigers);
            Base.Animals.Add(animalZebra.Id, animalZebra);

            Animal animalSinica = new Animal(Guid.NewGuid(),
                                            "Рябуха",
                                             new DateTimeOffset(2010, 11, 4, 11, 02, 55, new TimeSpan(hourUtc, minuteUtc, 0)),
                                             (int)((time - new DateTimeOffset(2010, 11, 4, 11, 02, 55, new TimeSpan(hourUtc, minuteUtc, 0))).TotalDays / 365),
                                             TypeOfAnimals.Mammals,
                                             TypeOfAnimalsOnTutrion.Omnivorous,
                                             ListOfAnimals.Jaguars
                                             );
            Base.Animals.Add(animalSinica.Id, animalSinica);

            Animal animalDog = new Animal(Guid.NewGuid(),
                                          "Жук",
                                          new DateTimeOffset(2005, 11, 4, 11, 02, 55, new TimeSpan(hourUtc, minuteUtc, 0)),
                                          (int)((time - new DateTimeOffset(2005, 11, 4, 11, 02, 55, new TimeSpan(hourUtc, minuteUtc, 0))).TotalDays / 356),
                                          TypeOfAnimals.Mammals,
                                          TypeOfAnimalsOnTutrion.MeatEaters,
                                          ListOfAnimals.Jaguars);
            Base.Animals.Add(animalDog.Id, animalDog);

            //CheckedType.CheckedTypeOfAnimals();
            foreach (KeyValuePair<Guid, Aviary> keyValue in Base.Aviaries)
            {
                foreach (Animal animal in keyValue.Value.Animals)
                {
                    TypeOfAnimals animal2;
                    int number = 0;
                    number++;

                    if (number != keyValue.Value.Animals.Count)
                    {

                        animal2 = keyValue.Value.Animals.ElementAt(number).TypeOfAnimals;

                        if (animal2 != animal.TypeOfAnimals)
                        {
                            Console.WriteLine("У вас в одному вольєрі живуть різні типи тварин, перевірте у своїх вольєрах тварин!");
                        }
                    }
                }
            }

            // ChangeHungry.ChangeHungryOfAnimal();

            foreach (KeyValuePair<Guid, Animal> keyValue in Base.Animals)
            {

                Animal animal = keyValue.Value;
                // Console.WriteLine(keyValue.Value.Name);



                switch (keyValue.Value.ListAnimals)
                {
                    case ListOfAnimals.Tigers:
                        {
                            switch (keyValue.Value.Age)
                            {
                                case int n when (keyValue.Value.Age <= 2):
                                    {

                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 1;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 1;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 7, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time2 = new DateTimeOffset(time.Year, time.Month, time.Day, 11, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time3 = new DateTimeOffset(time.Year, time.Month, time.Day, 15, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time4 = new DateTimeOffset(time.Year, time.Month, time.Day, 16, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time5 = new DateTimeOffset(time.Year, time.Month, time.Day, 21, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);
                                                ration.Eating.Add(time2);
                                                ration.Eating.Add(time3);
                                                ration.Eating.Add(time4);
                                                ration.Eating.Add(time5);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }

                                case int n when (keyValue.Value.Age <= 10):
                                    {
                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 6;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 3;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 7, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time2 = new DateTimeOffset(time.Year, time.Month, time.Day, 17, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);
                                                ration.Eating.Add(time2);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case int n when (keyValue.Value.Age <= 10):
                                    {
                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 6;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 3;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 7, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time2 = new DateTimeOffset(time.Year, time.Month, time.Day, 17, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);
                                                ration.Eating.Add(time2);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case int n when (keyValue.Value.Age > 10):
                                    {
                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 2;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 3;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 7, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time2 = new DateTimeOffset(time.Year, time.Month, time.Day, 18, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);
                                                ration.Eating.Add(time2);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                            }

                            break;
                        }
                    case ListOfAnimals.Jaguars:
                        {
                            switch (keyValue.Value.Age)
                            {
                                case int n when (keyValue.Value.Age <= 1):
                                    {

                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 1;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 3;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 7, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time2 = new DateTimeOffset(time.Year, time.Month, time.Day, 11, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time3 = new DateTimeOffset(time.Year, time.Month, time.Day, 15, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time4 = new DateTimeOffset(time.Year, time.Month, time.Day, 16, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time5 = new DateTimeOffset(time.Year, time.Month, time.Day, 21, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);
                                                ration.Eating.Add(time2);
                                                ration.Eating.Add(time3);
                                                ration.Eating.Add(time4);
                                                ration.Eating.Add(time5);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case int n when (keyValue.Value.Age <= 5):
                                    {
                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 1;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 2;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 7, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time2 = new DateTimeOffset(time.Year, time.Month, time.Day, 10, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time3 = new DateTimeOffset(time.Year, time.Month, time.Day, 15, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time4 = new DateTimeOffset(time.Year, time.Month, time.Day, 19, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);
                                                ration.Eating.Add(time2);
                                                ration.Eating.Add(time3);
                                                ration.Eating.Add(time4);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case int n when (keyValue.Value.Age <= 10):
                                    {
                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 3;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 1;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 7, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time2 = new DateTimeOffset(time.Year, time.Month, time.Day, 17, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);
                                                ration.Eating.Add(time2);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case int n when (keyValue.Value.Age > 10):
                                    {
                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 1;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 3;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 7, 0, 00, new TimeSpan(2, 0, 0));

                                                DateTimeOffset time3 = new DateTimeOffset(time.Year, time.Month, time.Day, 22, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);

                                                ration.Eating.Add(time3);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }

                                        }
                                        break;
                                    }

                            }

                            break;
                        }
                    case ListOfAnimals.Delfins:
                        {
                            switch (keyValue.Value.Age)
                            {
                                case int n when (keyValue.Value.Age <= 2):
                                    {

                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 1;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 1;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 7, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time2 = new DateTimeOffset(time.Year, time.Month, time.Day, 11, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time3 = new DateTimeOffset(time.Year, time.Month, time.Day, 15, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time4 = new DateTimeOffset(time.Year, time.Month, time.Day, 16, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time5 = new DateTimeOffset(time.Year, time.Month, time.Day, 21, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);
                                                ration.Eating.Add(time2);
                                                ration.Eating.Add(time3);
                                                ration.Eating.Add(time4);
                                                ration.Eating.Add(time5);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case int n when (keyValue.Value.Age <= 5):
                                    {
                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 6;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 4;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 7, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time2 = new DateTimeOffset(time.Year, time.Month, time.Day, 17, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);
                                                ration.Eating.Add(time2);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case int n when (keyValue.Value.Age <= 5):
                                    {
                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 2;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 3;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 7, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time2 = new DateTimeOffset(time.Year, time.Month, time.Day, 17, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);
                                                ration.Eating.Add(time2);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case int n when (keyValue.Value.Age <= 10):
                                    {
                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 4;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 3;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 7, 0, 00, new TimeSpan(2, 0, 0));

                                                DateTimeOffset time3 = new DateTimeOffset(time.Year, time.Month, time.Day, 19, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);

                                                ration.Eating.Add(time3);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }

                                        }
                                        break;
                                    }
                                case int n when (keyValue.Value.Age > 10):
                                    {
                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 4;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 3;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 7, 0, 00, new TimeSpan(2, 0, 0));

                                                DateTimeOffset time3 = new DateTimeOffset(time.Year, time.Month, time.Day, 19, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);

                                                ration.Eating.Add(time3);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }

                                        }
                                        break;
                                    }
                            }

                            break;
                        }
                    case ListOfAnimals.Zebras:
                        {
                            switch (keyValue.Value.Age)
                            {
                                case int n when (keyValue.Value.Age <= 3):
                                    {

                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 1;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 3;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 7, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time2 = new DateTimeOffset(time.Year, time.Month, time.Day, 11, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time3 = new DateTimeOffset(time.Year, time.Month, time.Day, 15, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time4 = new DateTimeOffset(time.Year, time.Month, time.Day, 16, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time5 = new DateTimeOffset(time.Year, time.Month, time.Day, 21, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);
                                                ration.Eating.Add(time2);
                                                ration.Eating.Add(time3);
                                                ration.Eating.Add(time4);
                                                ration.Eating.Add(time5);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case int n when (keyValue.Value.Age <= 5):
                                    {
                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 2;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 3;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 7, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time2 = new DateTimeOffset(time.Year, time.Month, time.Day, 17, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);
                                                ration.Eating.Add(time2);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case int n when (keyValue.Value.Age <= 10):
                                    {
                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 1;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 4;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 7, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time2 = new DateTimeOffset(time.Year, time.Month, time.Day, 14, 0, 00, new TimeSpan(2, 0, 0));
                                                DateTimeOffset time3 = new DateTimeOffset(time.Year, time.Month, time.Day, 19, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);
                                                ration.Eating.Add(time2);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case int n when (keyValue.Value.Age > 10):
                                    {
                                        foreach (Ration ration in Base.Rations.Values)
                                        {
                                            if (animal.ListAnimals == ration.ListAnimals)
                                            {
                                                int weight = ration.WeightPortion;
                                                weight = 4;
                                                ration.Weight(weight);
                                                int coef = ration.Coefficient;
                                                coef = 3;
                                                ration.Coef(coef);
                                                DateTimeOffset time1 = new DateTimeOffset(time.Year, time.Month, time.Day, 9, 0, 00, new TimeSpan(2, 0, 0));

                                                DateTimeOffset time3 = new DateTimeOffset(time.Year, time.Month, time.Day, 19, 0, 00, new TimeSpan(2, 0, 0));
                                                ration.Eating.Add(time1);

                                                ration.Eating.Add(time3);
                                                foreach (DateTimeOffset t in ration.Eating)
                                                {
                                                    if (time.Hour > t.Hour + weight * coef)
                                                    {
                                                        animal.ChangeHungry(true);
                                                    }
                                                    else
                                                    {
                                                        animal.ChangeHungry(false);
                                                    }
                                                }
                                            }

                                        }
                                        break;
                                    }
                            }

                            break;
                        }




                }
            }


            foreach (KeyValuePair<Guid, Aviary> keyValue in Base.Aviaries)
            {
                Console.WriteLine(keyValue.Value.Number);
                foreach (Animal animal in keyValue.Value.Animals)
                {


                    if (animal.ListAnimals == keyValue.Value.ListAnimals)
                    {

                        Console.WriteLine("Ім'я тварини: " + animal.Name + ", " + "Дата народження: " + animal.YearOfBirth + ", Age: " + animal.Age + ", Вольєр " + keyValue.Value.Number + "  " + animal.ListAnimals + "Чи голодна тварина? " + animal.Hungry + ", " + "Яка тварина? " + animal.TypeOfAnimalsOnTutrion + ", Раціон : ");
                    }
                }

            }

            Console.WriteLine("Вивести список голодних тварин?");
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                
                    foreach (KeyValuePair<Guid, Animal> animal in Base.Animals)
                    {
                        bool r = animal.Value.Hungry;
                        if (r == true)
                        {
                            HungryAnimal.Add(animal.Value);
                        }
                    }
                
            }
            foreach (Animal animal in HungryAnimal)
            {

                Console.WriteLine("Список голодних тварин: " + animal.Name + animal.ListAnimals);
            }


            if (HungryAnimal.Count == 0)
            {
                Console.WriteLine("У вас немає голодних тварин");
            }
            else
            {
                for (int i = HungryAnimal.Count; i > 0; i--)
                {
                    int count = HungryAnimal.Count;
                    Console.WriteLine(count);

                    for (int l = count; l > 0; l--)
                    {
                        Console.WriteLine("Ваші запаси їжї");

                        foreach (Food food in Base.Foods)
                        {
                            Console.WriteLine(food.Name + " " + food.Weight);
                        }
                    }

                    Console.WriteLine("Ви хочете нагодувати тварин?");
                    string answer3 = Console.ReadLine();
                    if (answer3 == "y")
                    {

                        Console.WriteLine("Кого хочете нагодувати? Введить ім'я :");
                        string answer2 = Console.ReadLine();
                        foreach (KeyValuePair<Guid, Aviary> keyValue in Base.Aviaries)
                        {
                            foreach (Animal animal in keyValue.Value.Animals)
                            {
                                if (animal.Name == answer2)
                                {
                                    bool k = animal.Hungry;
                                    k = false;
                                    HungryAnimal.Remove(animal);
                                    animal.ChangeHungry(k);

                                    foreach (Food food in Base.Foods)
                                    {
                                        foreach (KeyValuePair<Guid, Ration> rat in Base.Rations)
                                        {
                                            if (food.ListAnimals == rat.Value.ListAnimals)
                                            {
                                                int weight = food.Weight;
                                                weight -= rat.Value.WeightPortion;
                                                food.ChangeWeight(weight);
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }

                }
            }
        }
    }
}