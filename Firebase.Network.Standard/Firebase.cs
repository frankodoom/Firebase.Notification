using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Firebase.Network.Standard
{
    public class Firebase
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
            public async Task<HttpStatusCode> PushNotifyAsync(string Id, string Title, string Message)
            {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Cotent-Type", "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", $"key={ServerKey}");
                    //create object data
                    var obj = new
                    {
                        to = Id,
                        data = new
                        {
                            title = Title,
                            text = Message,
                            icon = Icon
                        }
                    };

                    //serialize object data to json
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                    // create an http string content
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("https://fcm.googleapis.com/fcm/send", data);
                    return response.StatusCode;
                }

            }
            catch (Exception)
            {
                return HttpStatusCode.BadRequest;
                //throw;
            }
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
            public async Task<HttpStatusCode> PushNotifyAsync(string[] ids, string Title, string Message)
            {
            try
            {
                using(var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Cotent-Type","application/json");
                    client.DefaultRequestHeaders.Add("Authorization", $"key={ServerKey}");

                    //create object data
                    var obj = new
                    {
                        to = ids,
                        data = new
                        {
                            title = Title,
                            text = Message,
                            icon = Icon
                        }
                    };

                    //serialize object data to json
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                    // create an http string content
                    var data = new StringContent(json, Encoding.UTF8, "application/json");              
                    HttpResponseMessage response = await client.PostAsync("https://fcm.googleapis.com/fcm/send",data);
                    return response.StatusCode;                 
                }

            }
            catch (Exception)
            {
                return HttpStatusCode.BadRequest;
                //throw;
            }

    }
     }
}

