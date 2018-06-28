using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FireBase.Notification
{
    class Program
    {
        static void Main(string[] args)
        {

          
            using (var firebase = new Firebase())
            {
                firebase.ServerKey = "{Your Server Key}";
                string[] Ids = null ;
                firebase.PushNotifyAsync(Ids,"Hello","World").Wait();
                Console.ReadLine();
            }               
        }
    }
}
