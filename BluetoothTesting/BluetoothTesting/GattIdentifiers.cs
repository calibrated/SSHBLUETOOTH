﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothTesting
{
    public class GattIdentifiers
    {
        public static Guid UartGattServiceId = Guid.Parse("6E400001-B5A3-F393-E0A9-E50E24DCCA9E");
        public static Guid UartGattCharacteristicReceiveId = Guid.Parse("6E400003-B5A3-F393-E0A9-E50E24DCCA9E");
        public static Guid UartGattCharacteristicSendId = Guid.Parse("6E400002-B5A3-F393-E0A9-E50E24DCCA9E");
        public static Guid SpecialNotificationDescriptorId = Guid.Parse("00002902-0000-1000-8000-00805f9b34fb");
    }
}
    