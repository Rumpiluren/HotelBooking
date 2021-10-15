using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.HotelBooking.UI.Data;
using WPF.HotelBooking.UI.Event;
using WPF.HotelBooking.UI.Model;

namespace WPF.HotelBooking.UI.ViewModel
{
    public class UserDetailViewModel : INotifyPropertyChanged, IUserDetailViewModel
    {
        private readonly IHotelDataService _hotelDataService;
        private readonly IEventAggregator _eventAggregator;
        private User _user;

        public event PropertyChangedEventHandler PropertyChanged;

        public User SelectedUser
        {
            get { return _user; }
            set 
            { 
                _user = value;
                WhenPropertyChanged(nameof(SelectedUser));
            }
        }


        public UserDetailViewModel(IHotelDataService hotelDataService, IEventAggregator eventAggregator)
        {
            _hotelDataService = hotelDataService;
            _eventAggregator = eventAggregator;
            //LoadUser(1);

            //_eventAggregator.GetEvent<OpenObjectDetailsEvent>().Subscribe(HandleUserSelectedEvent);
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private bool OnSaveCanExecute()
        {
            return true;
        }

        private async void OnSaveExecute()
        {
            await _hotelDataService.SaveAsync(_user);
            _eventAggregator.GetEvent<AfterSavedEvent>().Publish(new InfoAboutChangedEntityArgs { Id = _user.Id, Name = _user.FirstName });
        }

        public async Task LoadUser(int userId)
        {
            var user = await _hotelDataService.GetUserById(userId);
            SelectedUser = user;
        }
        private void WhenPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SaveCommand { get; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
