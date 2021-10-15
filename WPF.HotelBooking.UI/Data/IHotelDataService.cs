using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.HotelBooking.Model;
using WPF.HotelBooking.UI.Model;

namespace WPF.HotelBooking.UI.Data
{
    public interface IHotelDataService
    {
        Task<User> GetUserById(int userId);
        Task<List<Room>> GetRooms();
        Task<List<Hotel>> GetHotels();
        Task<Room> GetRoomById(int roomId);
        Task SaveAsync(User user);
    }
}
