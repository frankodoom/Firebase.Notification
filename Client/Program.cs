using Firebase.Network.Standard;
using System;
using System.Net;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is the Dotnet Standard Library being consumed in a .Net Core Console
            using (var fb = new Firebase.Network.Standard.Firebase())
            {
                fb.ServerKey = "";
                string[] Ids = null;
                var statusCode = fb.PushNotifyAsync(Ids, "Title", "Message");
                Console.WriteLine(statusCode.Result);
                Console.ReadLine();
            }        
        }
    }
}
