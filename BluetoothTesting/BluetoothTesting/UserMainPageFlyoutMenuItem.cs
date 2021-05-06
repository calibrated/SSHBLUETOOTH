using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluetoothTesting
{
    public class UserMainPageFlyoutMenuItem
    {
        public UserMainPageFlyoutMenuItem()
        {
            TargetType = typeof(UserMainPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}