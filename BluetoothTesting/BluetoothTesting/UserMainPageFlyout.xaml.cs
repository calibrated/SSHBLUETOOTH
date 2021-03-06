using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BluetoothTesting.SSHPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BluetoothTesting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserMainPageFlyout : ContentPage
    {
        public ListView ListView;

        public UserMainPageFlyout()
        {
            InitializeComponent();

            BindingContext = new UserMainPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class UserMainPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<UserMainPageFlyoutMenuItem> MenuItems { get; set; }

            public UserMainPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<UserMainPageFlyoutMenuItem>(new[]
                {
                    new UserMainPageFlyoutMenuItem { Id = 0, Title = "BaseLineTest",TargetType = typeof(BaseLineTest)},
                    new UserMainPageFlyoutMenuItem { Id = 1, Title = "알람" },
                    new UserMainPageFlyoutMenuItem { Id = 2, Title = "교육 영상" },
                    new UserMainPageFlyoutMenuItem { Id = 3, Title = "UserMainPage" },
                    new UserMainPageFlyoutMenuItem { Id = 4, Title = "로그아웃" },
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
    }
}