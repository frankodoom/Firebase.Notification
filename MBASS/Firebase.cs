using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FireBase.Notification
{
    //ref https://www.codeproject.com/Articles/1206069/Sending-Push-Notifications-to-Android-with-Csharp

    public class Firebase: IDisposable
    {
        /// <summary>
        ///  This is your Firebase Server Key
        /// </summary>
        public string ServerKey { get; set; }
  
        /// <summary>
        /// Set an optional notification icon
        /// </summary>
        /// <example>https://placeimg.com/250/250/nature</example>
        public string Icon { get; set; }

        public void Dispose()
        {
            this.Dispose();
            Console.ReadKey();
        }

        /// <summary>
        /// Send push notification to a specific device
        /// </summary>
        /// <param name="Id">
        /// Firebase Sender Id
        /// </param>
        /// <param name="Message">
        ///  Your Firebase Notification Message
        /// </param>
        /// <param name="Title">
        ///  Notification Title
        /// </param>
        /// <returns> Returns the response stream from the FCM server</returns>
        public async Task<string> PushNotifyAsync(string Id, string Title, string Message)
        {
            try
            {
                var result = "";
                var webAddr = "https://fcm.googleapis.com/fcm/send";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, $"key={ServerKey}");
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
                {
                    var obj = new
                    {
                        to = Id,
                        data = new
                        {
                            title = Title,
                            text =  Message,
                             icon = Icon
                        }
                    };

                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                Console.WriteLine(result);
                return result;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString(), "Firebase.Notification");
                //throw;
            }

            return "failed";
        }

        /// <summary>
        /// Send push notification to a specific device
        /// </summary>
        /// <param name="Id">
        /// Firebase Sender Id
        /// </param>
        /// <param name="Message">
        ///  Your Firebase Notification Message
        /// </param>
        /// <param name="Title">
        ///  Notification Title
        /// </param>
        /// <returns>Returns the response stream from the FCM server</returns>
        public async Task<string> PushNotifyAsync(string[] ids, string Title, string Message )
        {
            try
            {

                var result = "";
                var webAddr = "https://fcm.googleapis.com/fcm/send";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, $"key={ServerKey}");
                //httpWebRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
                {

                    var obj = new
                    {
                        to = ids,
                        data = new
                        {
                            title = Title,
                            text = Message,
                            //sound = "default",
                            icon = Icon
                        }
                    };

                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                return result;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString(), "Firebase.Notification");
                //throw;
            }
            return "failed";
           
        }
    }
}
