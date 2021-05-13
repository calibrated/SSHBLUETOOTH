using Plugin.Segmented.Event;
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
    public partial class AlramTypeAndStrength : ContentPage
    {
        public AlramTypeAndStrength()
        {
            InitializeComponent();
        }

       
        public void OnElementChildrenChanging(object sender, EventArgs e) {
          
        
        }

        public void StartButtonClicked(object sender, EventArgs e)
        {



            var tt = TypeSegmente.SelectedSegment;
            Navigation.PushAsync(new BaseLineTestStart());
        }
    }
}