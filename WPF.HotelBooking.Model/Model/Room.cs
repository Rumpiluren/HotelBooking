using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.HotelBooking.Model;

namespace WPF.HotelBooking.UI.Model
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Size { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
