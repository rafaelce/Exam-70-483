using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skill_1._1_PARALLEL
{
    class Program
    {
        static void Main(string[] args)
        {
            //PARALLEL.INVOKE: Starting a large number of a tasks at once.
            Parallel.Invoke(() => Task1(), () => Task2());

            Console.WriteLine("Finished Parallel.Invoke processing. Press a key to end.\n\n");
            Console.ReadKey();

            //PARALLEL.FOREACH: performs a parallel implementation of the foreach loop construction
            var items = Enumerable.Range(0,500);
            Parallel.ForEach(items, item => {
                WorkOnItem(item);
            });

            Console.WriteLine("Finished Parallel.ForEach processing. Press a key to end.\n\n");
            Console.ReadKey();

            //PARALLEL.FOR: performs a parallel implementation of the for loop construction
            var itemsFor = Enumerable.Range(0, 500).ToArray();
            Parallel.For(0, itemsFor.Length, i => {
                WorkOnItem(itemsFor[i]);
            });

            Console.WriteLine("Finished Parallel.For processing. Press a key to end.\n\n");
            Console.ReadKey();
        }

        #region "Methods"

        public static void Task1()
        {
            Console.WriteLine("Task 1 starting");
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 ending");
        }

        public static void Task2()
        {
            Console.WriteLine("Task 2 starting");
            Thread.Sleep(1000);
            Console.WriteLine("Task 2 ending");
        }

        public static void WorkOnItem(object item)
        {
            Console.WriteLine("Starting working on:" + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on:" + item);
        }
        #endregion
    }
}
