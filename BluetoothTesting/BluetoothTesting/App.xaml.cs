using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BluetoothTesting
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // await Navigation.PushAsync(new Testing());
            MainPage = new NavigationPage(new UARTTestPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        
    }
}
