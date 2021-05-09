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
        public IAdapter _bluetoothAdapter;
        public IDevice _bluetoothDevice;


    }
}
