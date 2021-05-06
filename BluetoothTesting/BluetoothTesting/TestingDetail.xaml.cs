using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BluetoothTesting
{
 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestingDetail : ContentPage
    {

        IAdapter adapter;
        IBluetoothLE bluetoothBLE;
        IDevice device;


        public TestingDetail()
        {
            InitializeComponent();
            device = ShowDeviceList.device;


            _ = GetDeviceDataAsync();

        }





        public async Task GetDeviceDataAsync() {

                var services = await device.GetServicesAsync();

                var service1 = await device.GetServiceAsync(services[0].Id);
                var service2 = await device.GetServiceAsync(services[1].Id);
                var service3 = await device.GetServiceAsync(services[2].Id);
                var service4 = await device.GetServiceAsync(services[3].Id);

                var characteristics1 = await service1.GetCharacteristicsAsync();
                var characteristics2 = await service2.GetCharacteristicsAsync();
                var characteristics3 = await service3.GetCharacteristicsAsync();
                var characteristics4 = await service4.GetCharacteristicsAsync();

                var characteristic = await service1.GetCharacteristicAsync(characteristics1[2].Id);

                var bytes = await characteristic.ReadAsync();

                var str = Encoding.UTF8.GetString(bytes);
         
        }
    }
}