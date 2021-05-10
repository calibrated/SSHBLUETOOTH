using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BluetoothTesting.SSHPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseLineTest : ContentPage
    {
        public BaseLineTest()
        {
            InitializeComponent();
        }

        public void AlramTypeAndStrengthClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new AlramTypeAndStrength());
        }
    }
}