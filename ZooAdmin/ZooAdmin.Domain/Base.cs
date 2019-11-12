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
            public static Dictionary<Guid, Food> Foods = new Dictionary<Guid, Food>();
            
            public static Dictionary<Guid, Ration> Rations = new Dictionary<Guid, Ration>();
            public string Name { get; }

            public Guid Id { get; private set; }



            public Base(string name)
            {
                Id = Guid.NewGuid();
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

