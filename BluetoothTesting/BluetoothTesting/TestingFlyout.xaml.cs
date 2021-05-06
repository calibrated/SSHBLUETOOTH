using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.IO;
using System.Net;
using System.Timers;

namespace BluetoothTesting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestingFlyout : ContentPage
    {
        IAdapter adapter;
        IBluetoothLE bluetoothBLE;
        IDevice device;

        public TestingFlyout()
        {
            InitializeComponent();

            BindingContext = new TestingFlyoutViewModel();

            bluetoothBLE = CrossBluetoothLE.Current;
            adapter = CrossBluetoothLE.Current.Adapter;
            //DevicesList.ItemsSource = list;


            if (adapter.ConnectedDevices.Count == 0)
            {
                DeviceName.Text = "연결된기기 없음";
            }
            else
            {
                DeviceName.Text = adapter.ConnectedDevices[0].Name;
            
            }
           
            

        }

        private void CheckTurnOnOffBluetooth(object sender, ElapsedEventArgs e)
        { 
           
        
        }
        class TestingFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<TestingFlyoutMenuItem> MenuItems { get; set; }

            public TestingFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<TestingFlyoutMenuItem>(new[]
                {
                    new TestingFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new TestingFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new TestingFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new TestingFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new TestingFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }


        private async void OnACtionSettingButton(object sender, EventArgs e)
        {

            string StrRequestShowDeviceList = "연결 가능한 리스트 보기";
            string action = await DisplayActionSheet("ActionSheet: Send to?", "Cancel", null, StrRequestShowDeviceList);

            if (action.Equals(StrRequestShowDeviceList))
            {

                await Navigation.PushAsync(new ShowDeviceList());

            }
            
            

        }
      



    }
}