using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Demo05_Threads
{
    public class Example2
    {
        public static void Start()
        {
            var worker = new Worker();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            
            // Parallel execution.
            // Task.Run starts a new thread and gives her work to do. New thread does the work in the background (in parallel).
            // Task.Run statements end almost immediately. Task.Run does not wait for actual work to be done...
            // Task.Run returns a Task object, also known as "promise". This is a promise to us that the action 
            // will end some time in the future. Task contains all information related to the work being done 
            // (you can use it to e.g. wait for the background task to finish...this is the most common usage)
            Task t1 = Task.Run(() => worker.SomeLongLastingOperation("A"));
            Task t2 = Task.Run(() => worker.SomeLongLastingOperation("B"));
            Task t3 = Task.Run(() => worker.SomeLongLastingOperation("C"));
            Task t4 = Task.Run(() => worker.SomeLongLastingOperation("D"));
            Task t5 = Task.Run(() => worker.SomeLongLastingOperation("E"));            
            // At this point, nobody guarantees that operations A, B, C, D and E are completed. We only started
            // their execution in parallel (other thread handles their execution).
            
            // If we'd like to wait for all background threads to finish their work, we use Task.WaitAll method
            // Or t1.Wait() -> if we need to wait individual task to finish.
            Task.WaitAll(t1, t2, t3, t4, t5);
            
            // At this point, all operations are completed.
            
            // Task.Wait is a blocking call. The thread that called the Wait method is paused until everything finishes. 
            // Not really ideal... Paused thread was maybe doing something important like drawing the UI.
            // Pausing the thread that draws the UI will lead to bad user experience and sluggish UI.
            // There is a better way to do this, check async await demo later. 
            
            stopWatch.Stop();
            // Since A, B, C, D and E operations were done in parallel, this took 5x less time than Example1 scenario!!!
            Console.WriteLine($"Example 2 took {stopWatch.Elapsed.TotalSeconds} seconds");
        }
    }
}