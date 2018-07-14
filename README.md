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
                firebase.ServerKey = "Your Server Key";
                var id = "Your Device Id";
                firebase.PushNotifyAsync(id,"title","message").Wait();
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
                firebase.ServerKey = "Your Server Key";
                string[] id = " an array of Ids";
                firebase.PushNotifyAsync(id,"title","message").Wait();
                Console.ReadLine();
            }               
        }
```

### Debugging
Trace errors in your output window, all errors from this library will be captured under the category `Firebase.Notification` for easy debugging.


# Licence

```
Copyright 2018 Frank Odoom

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
````

