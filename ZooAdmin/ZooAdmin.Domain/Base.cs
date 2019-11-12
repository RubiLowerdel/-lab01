using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ZooAdmin.Domain
{
        public class Base
        {
            public static Dictionary<Guid, Aviary> Aviaries = new Dictionary<Guid, Aviary>();
            public static Dictionary<Guid, Animal> Animals = new Dictionary<Guid, Animal>();
            public static List<Food> Foods = new List <Food>();
            
            public static Dictionary<Guid, Ration> Rations = new Dictionary<Guid, Ration>();
            public string Name { get; private set;  }

            public Guid Id { get; private set; }



            public Base(Guid identificator, string name)
            {
                Id = identificator;
                Name = name;
            if (String.IsNullOrEmpty(name) )
            {
                throw new ArgumentNullException();
            }
                

            }
            public override string ToString()
            {
                return Name;
            }
        
    }
    }

