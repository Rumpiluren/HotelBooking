using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.HotelBooking.UI.Model;

namespace WPF.HotelBooking.Model
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
