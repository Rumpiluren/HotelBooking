using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.HotelBooking.UI.Model;
using WPF.HotelBooking.UI.ViewModel;

namespace WPF.HotelBooking.UI.Wrappers
{
    public class UserWrapper : ViewModelPropertyChangedNotifier
    {
        public User Model { get; }
        private string _firstName;

        public UserWrapper(User model)
        {
            Model = model;
        }

        public int Id { get { return Model.Id; } }
        public string FirstName
        { 
            get { return _firstName; }
            set {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName { get { return Model.LastName; } }
        public string Email { get { return Model.Email; } }
        public int PhoneNumber { get { return Model.PhoneNumber; } }

    }
}
