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


        }
    }
}
