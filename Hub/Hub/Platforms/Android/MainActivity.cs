using Android.App;
using Android.Content.PM;
using Android.Gms.Tasks;
using Android.OS;
using Firebase.Messaging;
using System.Reflection.Metadata;

namespace Hub;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Initialize firebase-services
        Firebase.FirebaseApp.InitializeApp(this);

        // Enables automatic initialization for Firebase Cloud Messaging(FCM). 
        // Handle token generation and registration with FCM servers.
        FirebaseMessaging.Instance.AutoInitEnabled = true;

        // Registrera för FCM
        FirebaseMessaging.Instance.SubscribeToTopic("test");

        // Get token from device/phone and provide it to MyOnSuccessListener.
        FirebaseMessaging.Instance.GetToken()
        .AddOnSuccessListener(this, new MyOnSuccessListener());
    }

    public class MyOnSuccessListener : Java.Lang.Object, IOnSuccessListener
    {
        public void OnSuccess(Java.Lang.Object result)
        {
            var token = result.ToString();
            // Use tokens to send messages to this unit.
            Console.WriteLine($"FCM Token: {token}");
        }
    }
}

