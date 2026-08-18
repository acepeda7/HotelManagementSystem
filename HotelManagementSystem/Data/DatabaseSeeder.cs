using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Models;
using HotelManagementSystem.Services;

namespace HotelManagementSystem.Data
{
    public static class DatabaseSeeder
    {
        public static void Seed(AppDbContext db)
        {
            SeedUsers(db);
            SeedHotelsAndRooms(db);
            SeedDiscounts(db);

        }
        //Date for the users that are used to do the testings
        private static void SeedUsers (AppDbContext db)
        {
            if (db.Users.Any())
            {
                return;
            }

            Guest guest = new Guest
            {
                FullName = "Demo Guest",
                Email = "guest@hotel.com",
                PasswordHash = PasswordHasher.HashPassword("1234"),
                IsActive = true
            };

            Manager manager = new Manager
            {
                FullName = "Demo Manager",
                Email = "manager@hotel.com",
                PasswordHash = PasswordHasher.HashPassword("1234"),
                IsActive = true
            };

            Admin admin = new Admin
            {
                FullName = "Demo Admin",
                Email = "admin@hotel.com",
                PasswordHash = PasswordHasher.HashPassword("1234"),
                IsActive = true
            };

            db.Users.AddRange(guest, manager, admin);
            db.SaveChanges();
        }
        //Data for Hotels and Rooms, it is introduced directe to SQLite
        private static void SeedHotelsAndRooms (AppDbContext db)
        {
            if(db.Hotels.Any())
            {
                return;
            }

            Manager? manager = db.Managers.FirstOrDefault();

            if(manager == null)
            {
                return;
            }

            //hotel 1
            Hotel riversideHotel = new Hotel
            {
                Name = "Riverside Hotel",
                Address = "10 Thames Walk, London",
                Description =
            "A comfortable four-star hotel beside the river.",
                StarRating = 4,
                ManagerId = manager.Id
            };

            riversideHotel.Rooms.Add(new Room
            {
                Number = "101",
                Type = "Standard",
                Capacity = 2,
                PricePerNight = 110.00m,
                Description =
                    "Queen-size bed, private bathroom and city view.",
                Status = RoomStatus.Available
            });

            riversideHotel.Rooms.Add(new Room
            {
                Number = "201",
                Type = "Deluxe",
                Capacity = 3,
                PricePerNight = 175.00m,
                Description =
                    "King-size bed, sitting area and river view.",
                Status = RoomStatus.Available
            });

            //hotel 2
            Hotel cityHotel = new Hotel
            {
                Name = "Central City Hotel",
                Address = "25 Oxford Street, London",
                Description =
                    "A modern hotel close to shops and restaurants.",
                StarRating = 3,
                ManagerId = manager.Id
            };

            cityHotel.Rooms.Add(new Room
            {
                Number = "12",
                Type = "Single",
                Capacity = 1,
                PricePerNight = 85.00m,
                Description =
                    "Single bed, desk and private bathroom.",
                Status = RoomStatus.Available
            });

            cityHotel.Rooms.Add(new Room
            {
                Number = "18",
                Type = "Family",
                Capacity = 4,
                PricePerNight = 210.00m,
                Description =
                    "Two beds, sofa bed and family bathroom.",
                Status = RoomStatus.Available
            });

            //to save the data in the db
            db.Hotels.AddRange(riversideHotel, cityHotel);
            db.SaveChanges();

        }

        private static void SeedDiscounts (AppDbContext db)
        {
            if (db.Discounts.Any())
            {
                return;
            }

            Discount discount = new Discount
            {
                Code = "WELCOME10",
                Percentage = 10,
                ValidFrom = DateTime.Today.AddMonths(-1),
                ValidUntil = DateTime.Today.AddYears(1),
                IsActive = true
            };

            db.Discounts.Add(discount);
            db.SaveChanges();

        }

    }
}
