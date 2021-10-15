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
    public class RoomDetailViewModel : INotifyPropertyChanged, ICommand, IRoomDetailViewModel
    {
        private readonly IHotelDataService _hoteDataService;
        private Room _room;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        public Room SelectedRoom
        {
            get { return _room; }
            set { _room = value; }
        }

        public IEventAggregator _eventAggregator { get; }

        public RoomDetailViewModel(IHotelDataService hoteDataService, IEventAggregator eventAggregator)
        {
            _hoteDataService = hoteDataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenObjectDetailsEvent>().Subscribe(HandleRoomSelectedEvent);
        }

        private async void HandleRoomSelectedEvent(int roomId)
        {
            await LoadRoom(roomId);
        }

        public async Task LoadRoom(int roomId)
        {
            var room = await _hoteDataService.GetRoomById(roomId);
            SelectedRoom = room;
        }
        private void WhenPropertyChanges(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
