using System;
using System.Threading;

namespace Demo05_Threads
{
    public class Worker
    {
        public void SomeLongLastingOperation(string taskName)
        {
            Console.WriteLine("START: {0} (ThreadId: {1})", taskName, Thread.CurrentThread.ManagedThreadId);
            //Simulate hard work
            Thread.Sleep(2000);
            Console.WriteLine("END: {0} (ThreadId: {1})", taskName, Thread.CurrentThread.ManagedThreadId);
        }

        public int SomeLongLastingOperationThatReturnsInt(int i)
        {
            //Simulate hard work
            Thread.Sleep(200);
            return i;
        }
        
    }
}