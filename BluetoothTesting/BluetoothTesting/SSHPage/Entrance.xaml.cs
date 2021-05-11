using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BluetoothTesting.SSHPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Entrance : ContentPage
    {
        private bool IsFirstRun = true;
        public Entrance()
        {
            InitializeComponent();
          
        }

        public void SensorLinkButton_Clicked(object sender, EventArgs e)
        {
            if (CrossBluetoothLE.Current.State == BluetoothState.Off)
            {
                DisplayAlert("블루투스 연결확인", "블루투스 연결을 확인해 주세요", "OK");

            }
            else
            {
                if (IsFirstRun)
                {
                    //블루투스 검색페이지 이동
                    Navigation.PushAsync(new BLEScan());
                }
                else
                {

                    //블루투스 자동연결
                    AutoLogin();
                }

            }

        }


        public string CheckDeviceHistory()
        {

            return "NOHISTORY";
        }

        public void AutoLogin()
        {



        }
    }


}