using System;
using System.Collections.Generic;

namespace HMW_LINQ
{
    public class Costumer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<OrderByCostumer> Orders = new List<OrderByCostumer>();

        public Costumer(string name, Agent agent)
        {
            Name = name;
        }

        public Costumer(string name, int age)
        {
            Name = name;
            Age = age;
        }

        
        
    }
}
