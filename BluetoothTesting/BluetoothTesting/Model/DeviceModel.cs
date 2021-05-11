using System;
using System.Collections.Generic;
using System.Text;
using Plugin.BLE;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;



namespace BluetoothTesting.Model
{
    public class DeviceModel
    {

        private static DeviceModel instance;
        
        public IAdapter _bluetoothAdapter;
        public IDevice _bluetoothDevice;

        DeviceModel()
        {
            _bluetoothAdapter = CrossBluetoothLE.Current.Adapter;

        }

        public static DeviceModel GetInstance()
        {
            if (instance == null)
            {
                instance = new DeviceModel();       
            }

            return instance;
        }
    }
}
