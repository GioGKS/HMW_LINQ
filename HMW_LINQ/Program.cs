using System;
using System.Collections.Generic;
using System.Linq;

namespace HMW_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lists 
            List<int> GroupOfNumbers = new List<int>() {1, 3, 20, 45, 92, 4, 17, 21, 47, 9 };
            List<string> GroupOfNames = new List<string>()
            {
                "Jimmy",
                "Mike",
                "Nicky",
                "Sam",
                "Jenifer",
                "Megan",
                "Alex",
                "Johny"
            };

            #region Syntax Method

            Console.WriteLine("* * * * * EXCERCISE 4 * * * * *");
            List<string> SelectOption = GroupOfNumbers.Select(num => num.ToString() + ",").ToList();
            foreach (var num in SelectOption)
            {
                Console.Write(num);
            }
            Console.WriteLine("\n");

            var SelectOptionQuery = from num in GroupOfNumbers
                                    select num;
            SelectOptionQuery.ToList().ForEach(num => Console.Write(num + ","));
            Console.WriteLine("\n");
                
            Console.WriteLine("* * * * * EXCERCISE 5 * * * * * \n");
           
            List<string> WhereOption = GroupOfNames.ToList();
            foreach (var Name in WhereOption)
            {
                if(Name.Length > 4)
                {
                    Console.WriteLine(Name);
                }
            }

            Console.WriteLine();
            Console.WriteLine("* * * * * EXCERCISE 6 * * * * * \n");
            
            List<int> SortingOrderBy = GroupOfNumbers.OrderBy(num => num).ToList();
            Console.WriteLine("Order By Numbers:");
            foreach (var item in SortingOrderBy)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine("\n");


            List<int> SortingByDescending = GroupOfNumbers.OrderByDescending(num => num).ToList();
            Console.WriteLine("Descending Numbers:");
            foreach (var num in SortingByDescending)
            {
                Console.Write(num + ",");
            }
            Console.WriteLine("\n");

            List<string> SortingStringsOrderBy = GroupOfNames.OrderBy(name => name.Length).ToList();
            Console.WriteLine("Order By String:");
            foreach (var name in SortingStringsOrderBy)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            List<string> StringByDescending = GroupOfNames.OrderByDescending(name => name.Length).ToList();
            Console.WriteLine("By Descending:");
            foreach (var name in StringByDescending)
            {
                Console.WriteLine(name);
            }



            Console.WriteLine();
            Console.WriteLine("* * * * * EXCERCISE 7 * * * * * \n");
            

            List<int> FirstNumberGroup = new List<int>() { 10, 88, 35, 40, 22 };
            List<int> SecondNumberGroup = new List<int>() { 3, 88, 50, 47, 90 };
            Console.WriteLine("EXCERCISE 7 - A)");
            List<int> SameNum = FirstNumberGroup.Intersect(SecondNumberGroup).ToList();
            SameNum.ForEach(num => Console.WriteLine(num + "\n"));

            Console.WriteLine("EXCERCISE 7 - B)");
            List<int> ExpectNums = FirstNumberGroup.Except(SecondNumberGroup).ToList();
            ExpectNums.ForEach(num => Console.Write(num + ","));
            Console.WriteLine("\n");

            Console.WriteLine("EXCERCISE 7 - C)");
            List<int> NoSameNumbersTwice = FirstNumberGroup.Except(SecondNumberGroup).Concat(SecondNumberGroup.Except(FirstNumberGroup)).ToList();
            NoSameNumbersTwice.ForEach(num => Console.Write(num + ","));
            Console.WriteLine("\n");

            Console.WriteLine("EXCERCISE 7 - D)");
            List<int> GroupsConact = FirstNumberGroup.Concat(SecondNumberGroup).ToList();
            int BiggerThan12 = GroupsConact.Where(num => num > 12).Select(num => num).First();
            Console.WriteLine(BiggerThan12);



            Console.WriteLine();
            Console.WriteLine("* * * * * EXCERCISE 8 * * * * * \n");


            List<Agent> Agents = new()
            {
                new("Jason"),
                new("Michael"),
                new("Bruce"),
                new("Andy")
            };

            List<Costumer> Costumers = new()
            {
                new("Nick", Agents[new Random().Next(Agents.Count)]),
                new("Nancy", Agents[new Random().Next(Agents.Count)]),
                new("Mika", Agents[new Random().Next(Agents.Count)]),
                new("Tony", Agents[new Random().Next(Agents.Count)])
            };

            List<OrderByCostumer> orders = new List<OrderByCostumer>();
            orders.Add(new("IPhone", 1700, Costumers[0]));
            orders.Add(new("NoteBook", 3000, Costumers[1]));
            orders.Add(new("SunGlasses", 1199, Costumers[2]));
            orders.Add(new("Shoes", 270, Costumers[3]));

            var JoinCostumersWithAgents = Costumers.Join(Costumers,
                CostName => CostName.Name,
                agentName => agentName.Name,
                (Costumer, Agent) => new
                {
                    Costumers = Costumer.Name,
                    Agents = Agent.Name
                });

            var CostumerAndOrder = Costumers.Join(Costumers,
                first => first.Name,
                scd => scd.Name,
                (Costumers, Order) => new
                {
                    Costumers = Costumers.Name,
                    orders = Costumers.Orders
                }).ToList();


            #endregion Query Method

            #region Query Method

            Console.WriteLine("* * * * * EXCERCISE 4 FROM QUERY * * * * *\n");

            var SelectFromQuery = from num in GroupOfNumbers
                                  select num;
            SelectFromQuery.ToList().ForEach(num => Console.Write(num + " | "));
            Console.WriteLine("\n");


            Console.WriteLine("* * * * * EXCERCISE 5 FROM QUERY * * * * *\n");

            var WhereFromQuery = from name in GroupOfNames
                                 where name.Length > 4
                                 select name;
            WhereFromQuery.ToList().ForEach(name => Console.WriteLine(name + ","));
            Console.WriteLine("\n");

            Console.WriteLine("* * * * * EXCERCISE 6 FROM QUERY * * * * *\n");


            var OrderByNum = from num in GroupOfNumbers
                             orderby num
                             select num;
            OrderByNum.ToList().ForEach(byNum => Console.Write(byNum.ToString() + " | "));
            Console.WriteLine();
            var orderByDisitnc = from name in GroupOfNames
                                 orderby name
                                 select name;
            orderByDisitnc.ToList().ForEach(stName => Console.WriteLine(stName + ","));
            Console.WriteLine("\n");

            Console.WriteLine("* * * * * EXCERCISE 7 FROM QUERY * * * * *\n");

            var SameNums = from numb in GroupOfNumbers
                               join numb2 in GroupOfNumbers
                               on numb equals numb2
                               select numb2;
            Console.WriteLine("The Same Numbers In both Lists: ");
            SameNums.ToList().ForEach(numb => Console.Write(numb + " | "));
            Console.WriteLine("\n");

            Console.WriteLine("The different numbers between the lists are: ");
            var dNums = from num in GroupOfNumbers
                        select num;
            var fNums = from num2 in GroupOfNumbers
                        select num2;

            dNums.Except(fNums).ToList().ForEach(num2 => Console.Write(num2 + " | "));
            Console.WriteLine("\n");

            Console.WriteLine("Numbers Without Doublings: ");
            var onlyOnce = from num in GroupOfNumbers
                           select num;
            onlyOnce.Distinct().ToList().ForEach(s => Console.Write(s + " | "));
            Console.WriteLine("\n");

            Console.WriteLine("First Number Bigger Than 12 Is: ");
            var Maxum = from num in GroupOfNumbers
                        where num > 12
                        select num;

            Maxum.ToList();
            Console.WriteLine(Maxum.First().ToString());

            Console.WriteLine();

            #endregion
        }
    }
}
