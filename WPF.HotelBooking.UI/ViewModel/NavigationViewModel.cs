using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.HotelBooking.Model;
using WPF.HotelBooking.UI.Data;
using WPF.HotelBooking.UI.Event;
using WPF.HotelBooking.UI.Model;

namespace WPF.HotelBooking.UI.ViewModel
{
    public class NavigationViewModel : INotifyPropertyChanged, INavigationViewModel
    {
        private readonly IHotelDataService _hotelDataService;
        public ObservableCollection<Hotel> Hotels { get; private set; }
        public ObservableCollection<Room> Rooms { get; private set; }

        private Hotel _selectedHotel;
        private Room _selectedRoom;

        public event PropertyChangedEventHandler PropertyChanged;
        public IEventAggregator _eventAggregator { get; }

        public Hotel selectedHotel
        {
            get { return _selectedHotel; }
            set
            {
                _selectedHotel = value;
                WhenPropertyChanged(nameof(selectedHotel));
                _eventAggregator.GetEvent<OpenObjectDetailsEvent>().Publish(_selectedHotel.HotelId);
                //if (selectedHotel != null) LoadRooms();
            }
        }
        public Room selectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                if (value != null)
                {
                    _selectedRoom = value;
                    WhenPropertyChanged(nameof(selectedRoom));
                    _eventAggregator.GetEvent<OpenObjectDetailsEvent>().Publish(_selectedRoom.RoomId);
                }
            }
        }

        public NavigationViewModel(IHotelDataService hotelDataService, IEventAggregator eventAggregator)
        {
            _hotelDataService = hotelDataService;
            _eventAggregator = eventAggregator;
            Hotels = new ObservableCollection<Hotel>();
            Rooms = new ObservableCollection<Room>();
        }

        public async Task Load()
        {
            var hotels = await _hotelDataService.GetHotels();
            Hotels.Clear();
            foreach (var Hotel in hotels)
            {
                Hotels.Add(Hotel);
            }
            await LoadRooms();
        }

        public async Task LoadRooms()
        {
            if (selectedHotel != null)
            {
                var rooms = await _hotelDataService.GetRooms();
                Rooms.Clear();
                foreach (var Room in rooms)
                {
                    if (Room.HotelId == selectedHotel.HotelId)
                    {
                        Rooms.Add(Room);
                    }
                }
            }
        }
        private void WhenPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
