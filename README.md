# Firebase.Notification
This is a C# library for sending push notification using Google Firebase Service


### Install package
```c#
PM> Install-Package Firebase.Notification -Version 1.0.0
```
### Send to Single Device
``` c#
static void Main(string[] args)
        {
            using (var firebase = new Firebase())
            {
                firebase.ServerKey = "{Your Server Key}";
                var id = "{Your Device Id}";
                firebase.PushNotifyAsync(id,"Hello","World").Wait();
                Console.ReadLine();
            }               
        }
 ```
        
        
        
 ### Send to all subscribers
 To send push notification to multiple subscribers suplly a `string[]` of all subscribed Device Id's to the Id parameter of the `PushNotifyAsync()` method.
``` c#
static void Main(string[] args)
        {
            using (var firebase = new Firebase())
            {
                firebase.ServerKey = "{Your Server Key}";
                var id = {"string[] of device Id's"};
                firebase.PushNotifyAsync(id,"Hello","World").Wait();
                Console.ReadLine();
            }               
        }
```

### Debugging
Trace errors in your output window, all errors from this library will be captured under the category `Firebase.Notification` for easy debugging.
