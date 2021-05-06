using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Bluetooth.LE;
using Android.Bluetooth;
using Xamarin.Forms;


[assembly: Xamarin.Forms.Dependency(typeof(BluetoothTesting.Droid.AndroidBluetoothConnect))]
namespace BluetoothTesting.Droid
{
    class AndroidBluetoothConnect : Activity, IBluetoothConnect
    {
        BluetoothAdapter bleAdapter = null;
        
      
        const int REQUEST_CONNECT_DEVICE_SECURE = 1;
        const int REQUEST_CONNECT_DEVICE_INSECURE = 2;
        const int REQUEST_ENABLE_BT = 3;
     

        public void BluetoothInit()
        {
            //bleManger = (BluetoothManager)Android.App.Application.Context.GetSystemService(Context.BluetoothService);
            bleAdapter = BluetoothAdapter.DefaultAdapter;

            if (bleAdapter == null || !bleAdapter.IsEnabled) {
                Intent enableBtIntent = new Intent(BluetoothAdapter.ActionRequestEnable);
                StartActivityForResult(enableBtIntent, REQUEST_ENABLE_BT);
               

            }

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);



            switch (requestCode)
            {
                case REQUEST_CONNECT_DEVICE_SECURE:

                    break;
                case REQUEST_CONNECT_DEVICE_INSECURE:

                    break;
                case REQUEST_ENABLE_BT:
                    if (Result.Ok == resultCode)
                    {
                        Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                        AlertDialog alert = dialog.Create();
                        alert.SetTitle("Title");
                        alert.SetMessage("Simple Alert");
                        alert.SetButton("OK", (c, ev) => {


                        });
                        alert.Show();
                    }
                    break;
            }

        }


    }
}