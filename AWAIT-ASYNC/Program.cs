using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AWAIT_ASYNC
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            1. Main starts the long running method via TestAsyncAwaitMethods.That immediately returns without 
               halting the current thread and we immediately see 'Press any key to exit' message
            
            2. All this while, the LongRunningMethod is running in the background. Once its completed, another 
               thread from Threadpool picks up this context and displays the final message
           */

            MyMethodAsync();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
        #region Methods

        public async static void  MyMethodAsync()
        {
            try {
                await LongRunningMethod();
            } catch(Exception ex) {
                Console.WriteLine("exceptions:" + ex.Message);
            }
        }

        public static async Task<int> LongRunningMethod()
        {
            Console.WriteLine("Starting Long Running method...");
            await Task.Delay(5000);
            Console.WriteLine("End Long Running method...");
            return 1;
        }

        public static async Task<string> FetchWebPage(string url) {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync(url);
        }

        public static async Task<IEnumerable<string>> FetchwebPages(string[] urls) {
            var tasks = new List<Task<String>>();

            foreach (string url in urls) {
                tasks.Add(FetchWebPage(url));
            }

            return await Task.WhenAll(tasks);
        }
        #endregion
    }
}
