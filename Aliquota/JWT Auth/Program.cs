using System;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading;

namespace JWT_Auth
{


     class Program
    {

        static public Queue<HttpListenerContext> contexts = new Queue<HttpListenerContext>();
        static public Semaphore costumers = new Semaphore(initialCount: 0, maximumCount: 300, name: "costumers");
        static Dictionary<string,int> ipRequests = new Dictionary<string,int>();
        static List<IPAddress> allowedIp = new List<IPAddress>();
        static void Main(string[] args)
        {

            ThreadHandler.StartThreads();
            allowedIp.Add(IPAddress.Parse("127.0.0.1"));
            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://127.0.0.1:5320/");
            server.Prefixes.Add("http://localhost:5320/");
            server.Start();
            Console.ForegroundColor = ConsoleColor.Green;

            while (true)
            {
                HttpListenerContext context = server.GetContext();
                IPAddress endereco =  context.Request.LocalEndPoint.Address;

                if (!ValidContext(context))
                    continue;
                contexts.Enqueue(context);
                costumers.Release();
            }

        }

        private static string GetPost(HttpListenerContext context)
        {
            string documentContents;
            using (Stream receiveStream = context.Request.InputStream)
            {
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    documentContents = readStream.ReadToEnd();
                }
            }
            return documentContents;
        }
        private static bool ValidContext(HttpListenerContext context)
        {
            var post = HttpUtility.ParseQueryString(GetPost(context));
            return true;
        }
    }

}
