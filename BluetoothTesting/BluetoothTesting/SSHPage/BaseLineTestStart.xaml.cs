using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using BluetoothTesting.Model;


namespace BluetoothTesting.SSHPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseLineTestStart : ContentPage
    {
        private IDevice _connectedDevice;
        float _roll1, _pitch1, _yaw1, _roll2, _pitch2, _yaw2;
        int count = 0;

        public BaseLineTestStart()
        {
            InitializeComponent();
            _connectedDevice = DeviceModel.GetInstance()._bluetoothDevice;
            StartReveiceData();
        }

        private ICharacteristic sendCharacteristic;
        private ICharacteristic receiveCharacteristic;


        private async void StartReveiceData()
        {
            try
            {
                var service = await _connectedDevice.GetServiceAsync(GattIdentifiers.UartGattServiceId);

                if (service != null)
                {
                    sendCharacteristic = await service.GetCharacteristicAsync(GattIdentifiers.UartGattCharacteristicSendId);

                    receiveCharacteristic = await service.GetCharacteristicAsync(GattIdentifiers.UartGattCharacteristicReceiveId);
                    if (receiveCharacteristic != null)
                    {
                        var descriptors = await receiveCharacteristic.GetDescriptorsAsync();

                        receiveCharacteristic.ValueUpdated += (o, args) =>
                        {
                            var receivedBytes = args.Characteristic.Value;
                            Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
                            {
                                Output.Text = Encoding.UTF8.GetString(receivedBytes, 0, receivedBytes.Length) + Environment.NewLine;
                                ConvertOutputTextToValue(Output.Text);
                            });
                        };

                        await receiveCharacteristic.StartUpdatesAsync();
                       

                    }
                }
                else
                {
                    Output.Text += "UART GATT service not found." + Environment.NewLine;
                }
            }
            catch
            {
                Output.Text += "Error initializing UART GATT service." + Environment.NewLine;
            }

        }

        private void ConvertOutputTextToValue(string _OutputString)
        {
             count++;
            Output.Text = count.ToString();
            //string outpuytext = _OutputString;
           
            
            //string[] RemoveCommaString = outpuytext.Split(',');
           
            //_roll1 =  float.Parse(RemoveCommaString[0]);
            //_pitch1 = float.Parse(RemoveCommaString[1]);
            //_yaw1 = float.Parse(RemoveCommaString[2]);
            //_roll2 = float.Parse(RemoveCommaString[3]);
            //_pitch2 = float.Parse(RemoveCommaString[4]);
            //_yaw2 = float.Parse(RemoveCommaString[5]);

            //float UserAngle = _roll2 - _roll1;

            //UserSpineAngle.Text =  UserAngle.ToString();

        }

        public void BtnStopClicked(object sender, EventArgs e)
        {

            receiveCharacteristic.StopUpdatesAsync();


        }


    }
}