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

        static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        static void addRangeOfValuesLock(int start, int end)
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

        static void Clock()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                Console.WriteLine("Tick");
                Thread.Sleep(500);
            }
        }

        static void addRangeOfValuesMonitors(int start, int end)
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

        static void addRangeOfValuesInterlock(int start, int end)
        {
            long subTotal = 0;

            while (start < end)
            {
                subTotal = subTotal + items[start];
                start++;
            }

            Interlocked.Add(ref sharedTotal, subTotal);
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

                tasks.Add(Task.Run(() => addRangeOfValues(rs, re)));
                rangeStart = rangeEnd;
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"The total is: {sharedTotal}");
            Console.ReadKey();

            Task.Run(() => Clock());
            Console.WriteLine($"Press any key to stop the clock.");
            Console.ReadKey();

            cancellationTokenSource.Cancel();
            Console.WriteLine($"Clock stopped.");
            Console.ReadKey();

        }
    }
}
