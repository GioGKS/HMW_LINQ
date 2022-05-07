using System;
namespace HMW_LINQ
{
    public class Agent
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string AgencyName { get; set;}

        public Agent(string name)
        {
            Name = name;
        }

        public Agent(string name, int age, string agencyName)
        {
            Name = name;
            Age = age;
            AgencyName = agencyName;
        }
    }
}
