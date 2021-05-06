using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Bluetooth.LE;
using Android.Bluetooth;
using Android.Content;
using static Android.App.Instrumentation;
using Android.Widget;
using Android;

//global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity

namespace BluetoothTesting.Droid
{
    [Activity(Label = "BluetoothTesting", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

       

        const int REQUEST_CONNECT_DEVICE_SECURE = 1;
        const int REQUEST_CONNECT_DEVICE_INSECURE = 2;
        const int REQUEST_ENABLE_BT = 3;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
             LoadApplication(new App());

            this.RequestPermissions(new[]
{
Manifest.Permission.AccessCoarseLocation,
Manifest.Permission.BluetoothPrivileged,
Manifest.Permission.BluetoothAdmin,
Manifest.Permission.AccessFineLocation,
Manifest.Permission.AccessNetworkState,
Manifest.Permission.AccessBackgroundLocation
}, 0);
        }

    
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

      

       
    }
}