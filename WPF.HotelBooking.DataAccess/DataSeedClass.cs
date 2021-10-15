using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.HotelBooking.Model;
using WPF.HotelBooking.UI.Model;

namespace WPF.HotelBooking.DataAccess
{
    public static class DataSeedClass
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Test", LastName = "Hej", Email = "new@gmail.com" }
            );

            var random = new Random();
            var generatedHotels = HotelGenerator();
            var generatedRooms = RoomGenerator(generatedHotels.Count());

            foreach (var room in generatedRooms)
            {
                modelBuilder.Entity<Room>().HasData( room );
            }
            foreach (var hotel in generatedHotels)
            {
                modelBuilder.Entity<Hotel>().HasData(hotel);
            }
        }

        private static List<Hotel> HotelGenerator()
        {
            List<Hotel> hotels = new List<Hotel>();
            for (int i = 1; i < 10; i++)
            {
                Hotel newHotel = new Hotel { HotelId = i, Name = NameGenerator() };
                hotels.Add(newHotel);
            }
            return hotels;
        }
        private static List<Room> RoomGenerator(int maxHotelId)
        {
            List<Room> rooms = new List<Room>();
            Random random = new Random();
            for (int i = 1; i < 50; i++)
            {
                Room newRoom = new Room { RoomId = i, Name = "Room " + i, HotelId = random.Next(1, maxHotelId) } ;
                rooms.Add(newRoom);
            }
            return rooms;
        }

        private static string NameGenerator()
        {
            List<String> firstName = new List<String>();
            List<String> lastName = new List<String>();

            firstName.Add("Royal");
            firstName.Add("Majestic");
            firstName.Add("Dreamland");
            firstName.Add("The");
            firstName.Add("Gentle");
            firstName.Add("Depressing");
            firstName.Add("Regal");
            firstName.Add("Private");
            firstName.Add("Asylum");

            lastName.Add("Resort");
            lastName.Add("Hotel & Spa");
            lastName.Add("Motel");
            lastName.Add("Circus Hotel");
            lastName.Add("Coffee Hotel");
            lastName.Add("Dreams Inn");
            lastName.Add("Shack");
            lastName.Add("House");

            var random = new Random();

            return new string
                (
                    firstName[random.Next(firstName.Count)] + " " + 
                    lastName[random.Next(lastName.Count)]
                );
        }
    }
}
