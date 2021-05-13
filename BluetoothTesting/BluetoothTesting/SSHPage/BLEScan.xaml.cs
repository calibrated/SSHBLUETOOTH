using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Collections.ObjectModel;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Exceptions;
using BluetoothTesting.Model;




namespace BluetoothTesting.SSHPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BLEScan : ContentPage
    {

        IAdapter adapter;
        IBluetoothLE bluetoothBLE;
        ObservableCollection<IDevice> list;
        IDevice device;


        public BLEScan()
        {
            InitializeComponent();

            bluetoothBLE = CrossBluetoothLE.Current;
            adapter = CrossBluetoothLE.Current.Adapter;
            DeviceModel.GetInstance()._bluetoothAdapter = adapter;
            list = new ObservableCollection<IDevice>();
            DevicesList.ItemsSource = list;
        }

        private async void searchDevice(object sender, EventArgs e)
        {
            if (bluetoothBLE.State == BluetoothState.Off)
            {
                await DisplayAlert("알림", "블루투스가 켜져있지 않습니다.", "OK");
            }
            else
            {
                list.Clear();

                adapter.ScanTimeout = 10000;
                adapter.ScanMode = ScanMode.Balanced;

                //디바이스 스캔
                adapter.DeviceDiscovered += (obj, a) =>
                {
                    if (!list.Contains(a.Device) && !string.IsNullOrEmpty(a.Device.Name))
                        list.Add(a.Device);
                };

                await adapter.StartScanningForDevicesAsync();

            }

        }


        private async void DevicesList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            device = DevicesList.SelectedItem as IDevice;

           

            var result = await DisplayAlert("Call", "이 기기에 연결하시겠습니까?", "연결", "취소");

            if (!result)
                return;

            //Stop Scanner
           // await adapter.StopScanningForDevicesAsync();

            try
            {
               

                //await DeviceModel.GetInstance()._bluetoothAdapter.ConnectToDeviceAsync(DeviceModel.GetInstance()._bluetoothDevice); //장치가 성공적으로 완료되는 태스크 반환

                await adapter.ConnectToDeviceAsync(device);



                await DisplayAlert("연결", "상태:" + device.State, "OK");

                //var service = await device.GetServiceAsync(GattIdentifiers.UartGattServiceId);
                //var receiveCharacteristic = await service.GetCharacteristicAsync(GattIdentifiers.UartGattCharacteristicReceiveId);
                //await receiveCharacteristic.StopUpdatesAsync();

                //await CrossBluetoothLE.Current.Adapter.DisconnectDeviceAsync(device);

                DeviceModel.GetInstance()._bluetoothDevice = device;

                await Navigation.PushAsync(new UserMainPage());

            }
            catch (DeviceConnectionException ex)
            {
                await DisplayAlert("에러", ex.Message, "OK");
            }
        }
    }
}