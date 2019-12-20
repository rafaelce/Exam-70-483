using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_1._1_CONCURRENT_COLLECTIONS
{
    class Program
    {
        static void Main(string[] args)
        {
            // BlockingCollection
            BlockingCollection<string> col = new BlockingCollection<string>();

            Task read = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(col.Take());
                }
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                }
            });

            write.Wait();

            // ConcurrentBag
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            bag.Add(42);
            bag.Add(21);
            int result;
            if (bag.TryTake(out result))
                Console.WriteLine(result);
            if (bag.TryPeek(out result))
                Console.WriteLine("There is a next item: { 0}", result);

            // Concurrent Dictionary
            ConcurrentDictionary<string, int> ages = new ConcurrentDictionary<string, int>();

            if (ages.TryAdd("Rafael", 21)) {
                Console.WriteLine("Rafael added successfuly.");
            }

            Console.WriteLine($"Rafael's age {ages["Rafael"]} ");

            Console.ReadKey();

            // set Rafael's age to 22 if it 21
            if (ages.TryUpdate("Rafael", 22, 21)) {
                Console.WriteLine("Age updated sucessfully.");
            }
            Console.WriteLine($"Rafael's new age {ages["Rafael"]} ");

            Console.ReadKey();

            // increment Rafael's age atomically using factor method.
            Console.WriteLine($"Rafael's age updated to: {ages.AddOrUpdate("Rafael", 1, (name, age) => age = age + 1)} ");
            Console.WriteLine($"Rafael's new age {ages["Rafael"]} ");

            Console.ReadKey();
        }
    }
}
