using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JWT_Auth
{
    public static class ThreadHandler
    {
        public static int MinimumAmount = 3;
        public static int MaximumAmount = 30;
        public static decimal IdealRequestperThreadRatio = 1/5; 
        private static int IdCount = 0;
        private static Dictionary<int, Thread> threads = new Dictionary<int, Thread>();
        static Mutex check = new Mutex(false, "Checkthread");
       
        public static void StartThreads() {
            addThread(MinimumAmount);
            Thread thread = new Thread(ThreadManager);
            thread.IsBackground = true;
            //thread.Start();

        }
        public static void ThreadManager()
        {
            while (true)
            {
                check.WaitOne();
                if (TooManyRequests())
                {
                    addThread(1);
                }
            }
        }
        private static void addThread(int Amount)
        {
            for (int i = 0; i < Amount; i++)
            {
                if (threads.Count >= MaximumAmount)
                    return;
                Thread thread = new Thread(ThreadLoop);
                thread.IsBackground = true;
                threads.Add(IdCount++, thread);
                thread.Start();
            }
        }
        private static bool TooManyRequests() =>
            Program.contexts.Count > (threads.Count * IdealRequestperThreadRatio);
        public static void ThreadLoop() {
            while (true)
            {
                Program.costumers.WaitOne();
                HttpListenerContext context = Program.contexts.Dequeue();
                RequestHandler.respondContext(context);
            }
        }
    }
}
