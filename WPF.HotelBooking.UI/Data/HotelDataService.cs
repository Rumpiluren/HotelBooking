using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.HotelBooking.DataAccess;
using WPF.HotelBooking.Model;
using WPF.HotelBooking.UI.Model;

namespace WPF.HotelBooking.UI.Data
{
    public class HotelDataService : IHotelDataService
    {
        private readonly Func<HotelBookingDbContext> _dbContext;

        public HotelDataService(Func<HotelBookingDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserById(int userId)
        {
            using(var context = _dbContext())
            {
                return await context.Users.SingleAsync(e => e.Id == userId);
            }
        }
        public async Task<List<Room>> GetRooms()
        {
            using (var context = _dbContext())
            {
                return await context.Rooms.ToListAsync();
            }
        }
        public async Task<List<Hotel>> GetHotels()
        {
            using (var context = _dbContext())
            {
                return await context.Hotels.ToListAsync();
            }
        }
        public async Task<Room> GetRoomById(int roomId)
        {
            using (var context = _dbContext())
            {
                return await context.Rooms.SingleAsync(e => e.RoomId == roomId);
            }
        }

        public async Task SaveAsync(User user)
        {
            using(var context = _dbContext())
            {
                context.Users.Attach(user);
                context.Entry(user).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
