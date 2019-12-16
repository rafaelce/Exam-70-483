using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter_1_Skill_1._1_TASK
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //A task can also be created and started using a single method, called Run.
            Task newTask = Task.Run(() => DoWork());
            newTask.Wait();

            //A task with return value
            Task<int> task = Task.Run(() => {
                return CalculateResult();
            });

            //Wait for tasks to complete
            Task[] listTask = new Task[10];

            for (int i = 0; i < 10; i++) {

                int taskNum = i;

                listTask[i] = Task.Run(() => DoWork());
            }

            Task.WaitAll(listTask);

            // Continuation Tasks
            Task continuationTask = Task.Run(() => HelloTask());
            continuationTask.ContinueWith((prevTask) => WorldTask()); //the mehtod ContinueWith can be used to spicify a continuation task. 
                                                                      //prevTask: antecedent task.
                                                                      
            Task continuationTaskOverload = Task.Run(() => HelloTask());
            continuationTaskOverload.ContinueWith((prevTask) => TaskContinuationOptions
                                                                .OnlyOnRanToCompletion);

            continuationTaskOverload.ContinueWith((prevTask) => ExceptionTask(), TaskContinuationOptions.OnlyOnFaulted);

            // Child Tasks
            var parent = Task.Factory.StartNew(() => {
                Console.WriteLine("Parent starts");

                for(int i = 0; i < 10; i++){
                    int taskNo = i;

                    Task.Factory.StartNew(
                            (x) => DoChild(x),
                                   taskNo,  //state object
                                   TaskCreationOptions.AttachedToParent);

                }
            });

            parent.Wait();
            Console.WriteLine("Parent finished.\n");

            Console.WriteLine(task.Result);
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }

        private static void ExceptionTask()
        {
            throw new NotImplementedException();
        }

        #region "Methods"
        
        public static void DoWork()
        {
            Console.WriteLine("WriteLine: Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("WriteLine: Work finished");
        }

        public static int CalculateResult() {
            Console.WriteLine("CalculateResult: Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("CalculateResult: Work finished");
            return 99;
        }

        public static void HelloTask() {
            Thread.Sleep(2000);
            Console.WriteLine("HelloTask: Hello");
        }

        public static void WorldTask(){
            Thread.Sleep(2000);
            Console.WriteLine("WorldTask: World");
        }

        public static void DoChild(object state) {
            Console.WriteLine("DoChild: Child {0} starting", state);
            Thread.Sleep(2000);
            Console.WriteLine("DoChild: Child {0} finished", state);
        }

        #endregion
    }
}
