using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skill_1._2_Manage_Multithreading
{
    class Program
    {
        static long sharedTotal;

        static int[] items = Enumerable.Range(0, 500001).ToArray();
        static object sharedTotalLock = new object();

        /// <summary>
        /// This method work with Monitors for executer.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        static void addRangeOfValuesWithMonitor(int start, int end)
        {
            long subTotal = 0;

            while (start < end)
            {
                subTotal = subTotal + items[start];
                start++;
            }

            Monitor.Enter(sharedTotalLock);
            sharedTotal = sharedTotal + subTotal;
            Monitor.Exit(sharedTotalLock);
        }

        static void addRangeOfValuesWithLock(int start, int end)
        {
            while (start < end)
            {
                lock (sharedTotalLock)
                {
                    sharedTotal = sharedTotal + items[start];
                }
                start++;
            }
        }

        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();

            int rangeSize = 1000;
            int rangeStart = 0;

            while (rangeStart < items.Length)
            {
                int rangeEnd = rangeStart + rangeSize;

                if (rangeSize > items.Length)
                {
                    rangeEnd = items.Length;
                }

                // creates local copies of a parameters
                int rs = rangeStart;
                int re = rangeEnd;

                tasks.Add(Task.Run(() => addRangeOfValuesWithLock(rs, re)));
                rangeStart = rangeEnd;
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"The total is: {sharedTotal}");
            Console.ReadKey();
        }
    }
}
