using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Demo05_Threads
{
    public class Example3
    {
        public static void Start()
        {
            var worker = new Worker();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            
            // Background tasks can return a value as well.
            Task<int> t1 = Task.Run(() => worker.SomeLongLastingOperationThatReturnsInt(1));
            Task<int> t2 = Task.Run(() => worker.SomeLongLastingOperationThatReturnsInt(1));

            // The moment you try to access return value of a background thread,
            // thread from which you were calling task.Result() gets paused until the results become available.
            // Same as if you called task.Wait().
            int sum = t1.Result + t2.Result;
            
            // At this point, both t1 and t2 tasks were completed!
            stopWatch.Stop();
            Console.WriteLine($"Example 3 took {stopWatch.Elapsed.TotalSeconds} seconds");
        }
    }
}