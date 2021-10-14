using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JWT_Auth
{
    public static class RequestHandler
    {
        private static Dictionary<string, Delegate> Commands = new Dictionary<string, Delegate>();
        private static string GetCommand(NameValueCollection post)
        {
            return post["Command"];
        }
        private static string GetPost(HttpListenerContext context)
        {
            Dictionary<string, string> postParams = new Dictionary<string, string>();
            string[] rawParams = context.Request.InputStream.ToString().Split('&');
            foreach (string param in rawParams)
            {
                string[] kvPair = param.Split('=');
                string key = kvPair[0];
                string value = HttpUtility.UrlDecode(kvPair[1]);
                postParams.Add(key, value);
            }
            return "";
        }

        private static bool ValidateCommand(NameValueCollection post, string command)
        {
            // 100% for sure, trust it, no crashes. (dying inside)
            return true;
        }
        private static string RunChoosenCommand(NameValueCollection post)
        {
            string command = GetCommand(post);
            if (!ValidateCommand(post, command))
                return "";
            Console.WriteLine(command);
            switch (command) 
            {
                case "GenerateToken": 
                    return TokenComponent.GenerateToken(post["Username"], post["Password"]);
                case "ValidateToken":
                    return TokenComponent.ValidateToken(post["Token"]).ToString();
                case "GetCurrencyValue":
                    return WebScrapper.Scrapper.GetCurrencyValue(post["Currency"]).ToString();
            }
            return "no case";
        }
        public static void respondContext(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            string msg = "ok";

            NameValueCollection post = HttpUtility.ParseQueryString(GetPost(context));
            Console.WriteLine("responding, " + context.Request.RemoteEndPoint.Address.ToString() + " " + context.Request);
            byte[] buffer = Encoding.UTF8.GetBytes(RunChoosenCommand(post));
            
            response.ContentLength64 = buffer.Length;
            response.ContentType = "";
            Stream st = response.OutputStream;
            st.Write(buffer, 0, buffer.Length);
            st.Close();
            context.Response.Close();
        }
    }
}
