using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BluetoothTesting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowDeviceList : ContentPage
    {
        IAdapter adapter;
        IBluetoothLE bluetoothBLE;
        ObservableCollection<IDevice> list;
        public static IDevice device;
        Timer timer;
        public ShowDeviceList()
        {
            InitializeComponent();

            bluetoothBLE = CrossBluetoothLE.Current;
            adapter = CrossBluetoothLE.Current.Adapter;

            list = new ObservableCollection<IDevice>();
            DevicesList.ItemsSource = list;


            if (bluetoothBLE.State == BluetoothState.Off)
            {
                 DisplayAlert("알림", "블루투스가 켜져있지 않습니다.", "OK");
            }


            timer = new System.Timers.Timer();
            timer.Interval =  1000; 
            timer.Elapsed += new ElapsedEventHandler(SearchDv);
            timer.Start();


           
        }


        private async void SearchDv(object sender, ElapsedEventArgs e)
        {

            if (adapter.ConnectedDevices.Count != 0)
                return;

           
                

                adapter.ScanTimeout = 10000;
                adapter.ScanMode = ScanMode.Balanced;


                //디바이스 스캔
                adapter.DeviceDiscovered += (obj, a) =>
                {
                    if (!list.Contains(a.Device)&&a.Device.Name != null)
                        list.Add(a.Device);
                };

                await adapter.StartScanningForDevicesAsync();
            

        }


        private async void DevicesList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
            device = DevicesList.SelectedItem as IDevice;

            var result = await DisplayAlert("Call", "이 기기에 연결하시겠습니까?", "연결", "취소");

            if (!result)
                return;

            //Stop Scanner
            await adapter.StopScanningForDevicesAsync();

            try
            {
                await adapter.ConnectToDeviceAsync(device); //장치가 성공적으로 완료되는 태스크 반환

                await DisplayAlert("연결", "상태:" + device.State, "OK");

                await Navigation.PushAsync(new Testing());
                timer.Stop();


            }
            catch (DeviceConnectionException ex)
            {
                await DisplayAlert("에러", ex.Message, "OK");
            }
        }
    }
}