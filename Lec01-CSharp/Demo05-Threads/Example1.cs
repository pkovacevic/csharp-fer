using System;
using System.Diagnostics;

namespace Demo05_Threads
{
    public class Example1
    {
        public static void Start()
        {
            var worker = new Worker();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            
            // Normal usage...
            // Single thread is used to execute all methods one by one. 
            // A has to finish for B to start etc.
            worker.SomeLongLastingOperation("A");
            worker.SomeLongLastingOperation("B");
            worker.SomeLongLastingOperation("C");
            worker.SomeLongLastingOperation("D");
            worker.SomeLongLastingOperation("E");
            
            stopWatch.Stop();
            Console.WriteLine($"Example 1 took {stopWatch.Elapsed.TotalSeconds} seconds");
        }
    }
}