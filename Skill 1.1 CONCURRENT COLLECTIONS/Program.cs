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
            // Blocking collection that can hold 5 items
            BlockingCollection<int> data = new BlockingCollection<int>(5);

            Task.Run(() => {
                
                // attempt to add 10 items to he collection - blocks after 5th
                for (int i = 0; i < 11 ; i++) {

                    data.Add(i);
                    Console.WriteLine("Data {0} added sucessfully.", i);

                }

                //indicate we have no more to add
                data.CompleteAdding();
            });

            Console.ReadKey();
            Console.WriteLine("Reading collection");

            Task.Run(() => {

                while (!data.IsCompleted) {
                    try {
                        
                        int v = data.Take();
                        Console.WriteLine("Data {0} taken sucessfully", v);

                    } catch (InvalidOperationException) { }
                }

            });

            Console.ReadKey();

            // Concurrent Queue
            ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
            
            queue.Enqueue("Rafael");
            queue.Enqueue("Cruz");

            string str;

            if (queue.TryPeek(out str)) {
                Console.WriteLine($"Peek: {str}");
            }

            if (queue.TryDequeue(out str)) {
                Console.WriteLine($"Dequeue: {str}");
            }

            Console.ReadKey();

            // Concurrent Stack
            ConcurrentStack<string> stack = new ConcurrentStack<string>();

            stack.Push("Rafael");
            stack.Push("Cruz");

            if (stack.TryPeek(out str)) {
                Console.WriteLine($"Peek: {str} ");
            }

            if (stack.TryPop(out str))
            {
                Console.WriteLine($"Pop: {str} ");
            }

            Console.ReadKey();

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
