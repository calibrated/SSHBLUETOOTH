using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Threading;
using Xamarin.Essentials;

namespace BluetoothTesting
{
    public partial class MainPage : ContentPage
    {

        private bool IsFirstRun = false;
       

        public MainPage()
        {
            InitializeComponent();

            // 이전에 앱을 실행했었는지 검사를한다.
            // 이름과 생년월일을 입력하면 이용자의 고유번호를 만든다.
            // 센서 연동 시작 버튼을 눌렀을때 블루투스가 켜져있지 않으면 블루투스를 켜라고 한다.
            // 센서 연동 시작 버튼을 눌렀을때 첫구동이면 블루투스 기기 설정 페이지로 이동한다.
            // 센서 연동 시작 버튼을 눌렀을때 첫구동이 아니면 이전에 연결했던 기기와 연결한후 사용자메인 페이지로 이동한다.

            if (CheckDeviceHistory() == "NOHISTORY")
            {
                IsFirstRun = true;

            }
            else
            {
                IsFirstRun = false;

            }


        }

        public void SensorLinkButton_Clicked(object sender, EventArgs e)
        {
            if (!CrossBluetoothLE.Current.IsOn)
            {
                DisplayAlert("블루투스 연결확인", "블루투스 연결을 확인해 주세요", "OK");

            }
            else
            {
                if (IsFirstRun)
                {
                    //블루투스 검색페이지 이동
                    //Navigation.PushAsync(new ScanBLEDevicePage());
                }
                else
                {

                    //블루투스 자동연결
                    AuthoLogin();
                }

            }

        }


        public string CheckDeviceHistory()
        {

            return "NOHISTORY";
        }


        public void AuthoLogin() { 
        
        
        
        }
    }
}
