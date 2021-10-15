using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.HotelBooking.Model;
using WPF.HotelBooking.UI.Data;
using WPF.HotelBooking.UI.Model;

namespace WPF.HotelBooking.UI.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel(INavigationViewModel navigationViewModel,
            IUserDetailViewModel userDetailViewModel,
            IRoomDetailViewModel roomDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            UserDetailViewModel = userDetailViewModel;
            RoomDetailViewModel = roomDetailViewModel;
        }

        public async Task Load()
        {
            await NavigationViewModel.Load();
        }

        public INavigationViewModel NavigationViewModel { get; }
        public IUserDetailViewModel UserDetailViewModel { get; }
        public IRoomDetailViewModel RoomDetailViewModel { get; }
    }
}
