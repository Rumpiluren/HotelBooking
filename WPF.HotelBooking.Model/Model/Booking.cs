using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.HotelBooking.UI.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Room Room { get; set; }
        public int Price { get; set; }
        public bool Allinclusive { get; set; }
        public bool Breakfast { get; set; }
        public bool Transport { get; set; }
    }
}
