using Android.App;
using Firebase.Messaging;
using Hub.Infrastructure.MQTT;
using MQTTnet;
using MQTTnet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub.Platforms.Android
{
    [Service(Exported = false)]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MessageService : FirebaseMessagingService
    {
        // This method only fire when a new token is created and can then be 
        // further handled. 
        public override void OnNewToken(string token)
        {
            base.OnNewToken(token);

            // Handle token further, send it to DB etc


            // Logging the token for FCM-testing purposes
            System.Diagnostics.Debug.WriteLine($"FCM Token: {token}");
        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);

            // Sorting of FCM message
            string fcmTitle = message.GetNotification().Title;
            string fcmDescription = message.GetNotification().Body;

            // Example of tranforming FCM message to MQTT
            string topic = fcmTitle;
            string payload = fcmDescription;

            // For debugging purposes, can be left out in the future
            Console.WriteLine(message.Data);
        }
    }
}

