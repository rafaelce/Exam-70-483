using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_1_Skill_1._1_PLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[] {
                new Person { Name = "Alan", City = "Hull"},
                new Person { Name = "Beryl", City = "Seattle"},
                new Person { Name = "Charles", City = "London"},
                new Person { Name = "David", City = "Seattle"},
                new Person { Name = "Eddy", City = "Paris"},
                new Person { Name = "Fred", City = "Berlin"},
                new Person { Name = "Gordon", City = "Hull"},
                new Person { Name = "Henry", City = "Seattle"},
                new Person { Name = "Issac", City = "Seattle"},
                new Person { Name = "James", City = "London"}
            };

            //using PLINQ
            var result = from person in people.AsParallel()
                         where person.City == "Seattle"
                         select person;

            foreach (var person in result)
                Console.WriteLine(person.Name);

            Console.WriteLine("\n-----------------------------------------------\n");

            //using ForAll
            result.ForAll(person => Console.WriteLine(person.Name));

            Console.WriteLine("\n-----------------------------------------------\n");

            //Exception in queries
            try {

                result = from person in people.AsParallel()
                         where CheckCity(person.City)
                         select person;

                result.ForAll(person => Console.WriteLine(person.Name));
            }
            catch (AggregateException ex) {

                Console.WriteLine(ex.InnerExceptions.Count + "exceptions.");
            }

            Console.WriteLine("\n-----------------------------------------------\n");

            // End Program
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();

        }

        public static bool CheckCity(string name)
        {
            if (name == "")
                throw new ArgumentException(name);

            return name == "Seattle";
        }
    }

    class Person {
        public string Name { get; set; }
        public string City { get; set; }
    }
}
