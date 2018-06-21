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

            //Send Single 
            using (var firebase = new Firebase())
            {
                firebase.ServerKey = "{Your Server Key}";
                var id = "{Your Device Id}";
                firebase.PushNotifyAsync(id,"Hello","World").Wait();
                Console.ReadLine();
            }               
        }
    }
}
