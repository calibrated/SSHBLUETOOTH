using Plugin.BLE;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinEssentials = Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using BluetoothTesting.Model;

namespace BluetoothTesting
{
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanBLEDevicePage : ContentPage
    {
       
        static public DeviceModel _device;
        private List<IDevice> _gattDevices = new List<IDevice>();
        public ScanBLEDevicePage()
        {
            InitializeComponent();
            _device = new DeviceModel();
            _device._bluetoothAdapter = CrossBluetoothLE.Current.Adapter;
            _device._bluetoothAdapter.DeviceDiscovered += (sender, foundBleDevice) =>
            {
                if (foundBleDevice.Device != null && !string.IsNullOrEmpty(foundBleDevice.Device.Name))
                    _gattDevices.Add(foundBleDevice.Device);
            };
        }

        private async Task<bool> PermissionsGrantedAsync()
        {
            var locationPermissionStatus = await XamarinEssentials.Permissions.CheckStatusAsync<XamarinEssentials.Permissions.LocationAlways>();

            if (locationPermissionStatus != XamarinEssentials.PermissionStatus.Granted)
            {
                var status = await XamarinEssentials.Permissions.RequestAsync<XamarinEssentials.Permissions.LocationAlways>();
                return status == XamarinEssentials.PermissionStatus.Granted;
            }
            return true;
        }

        private async void ScanButton_Clicked(object sender, EventArgs e)
        {
            IsBusyIndicator.IsVisible = IsBusyIndicator.IsRunning = !(ScanButton.IsEnabled = false);
            foundBleDevicesListView.ItemsSource = null;

            if (!await PermissionsGrantedAsync())
            {
                await DisplayAlert("Permission required", "Application needs location permission", "OK");
                IsBusyIndicator.IsVisible = IsBusyIndicator.IsRunning = !(ScanButton.IsEnabled = true);
                return;
            }

            _gattDevices.Clear();

            foreach (var device in _device._bluetoothAdapter.ConnectedDevices)
                _gattDevices.Add(device);

            await _device._bluetoothAdapter.StartScanningForDevicesAsync();

            foundBleDevicesListView.ItemsSource = _gattDevices.ToArray();
            IsBusyIndicator.IsVisible = IsBusyIndicator.IsRunning = !(ScanButton.IsEnabled = true);
        }

        private async void FoundBluetoothDevicesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            IsBusyIndicator.IsVisible = IsBusyIndicator.IsRunning = !(ScanButton.IsEnabled = false);
            _device._bluetoothDevice = e.Item as IDevice;

            if (_device._bluetoothDevice.State == DeviceState.Connected)
            {
                await Navigation.PushAsync(new UserMainPage());
            }
            else
            {
                try
                {
                    var connectParameters = new ConnectParameters(false, true);
                    await _device._bluetoothAdapter.ConnectToDeviceAsync(_device._bluetoothDevice, connectParameters);
                    await Navigation.PushAsync(new UserMainPage());
                }
                catch
                {
                    await DisplayAlert("Error connecting", $"Error connecting to BLE device: {_device._bluetoothDevice.Name ?? "N/A"}", "Retry");
                }
            }

            IsBusyIndicator.IsVisible = IsBusyIndicator.IsRunning = !(ScanButton.IsEnabled = true);
        }
    }
}