using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skill_1._1_THREADS
{
    class Program
    {
        static void Main(string[] args)
        {
            // first way for create a thread.
            Thread thread = new Thread(ThreadHello);
            thread.Start();

            // second way for create a thread.
            Thread t = new Thread(() => {
                Console.WriteLine("Hello from the thread with lambda.");
                Thread.Sleep(1000);
            });
            t.Start();

            //Passing data into a thread.
            ParameterizedThreadStart ps = new ParameterizedThreadStart(WorkOnData);
            Thread th = new Thread(ps);
            th.Start(99);

            //Another way for passing data into a thread.
            Thread threadData = new Thread((data) => {
                WorkOnData(data);
            });
            threadData.Start(999);

            Console.WriteLine("Press key to end.");
            Console.ReadKey();

            //Abort a thread.
            //For aborted a thread use the Thread.Abort() method.

            //thread executin context.
            Thread.CurrentThread.Name = "Main Method";
            DisplayThread(Thread.CurrentThread);

            Console.WriteLine("Press key to end.");
            Console.ReadKey();

            //thread pools
            for (int i = 0; i < 50; i++) {
                int stateNumber = i;
                ThreadPool.QueueUserWorkItem(state => DoWorkThreadPool(stateNumber));
            }

            Console.WriteLine("Press key to end.");
            Console.ReadKey();
        }

        #region "Methods"

        public static void ThreadHello() {
            Console.WriteLine("Hello from the thread");
            Thread.Sleep(2000);
        }

        static void WorkOnData(object data) {
            Console.WriteLine("Working on: {0}", data);
            Thread.Sleep(1000);
        }

        static void DisplayThread(Thread t) {
            Console.WriteLine("Name: {0}", t.Name);
            Console.WriteLine("Culture: {0}", t.CurrentCulture);
            Console.WriteLine("Priority: {0}", t.Priority);
        }

        static void DoWorkThreadPool(object state) {
            Console.WriteLine("Doing work: {0}", state);
            Thread.Sleep(500);
            Console.WriteLine("Work finished: {0}", state);
        }
        #endregion
    }
}
