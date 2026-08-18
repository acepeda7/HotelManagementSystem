using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Data
{
    //this cs represent the conecction beetwen csharp and SQLite
    public class AppDbContext : DbContext
    {
        //all the tables in the db
        public DbSet<User> Users { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public static string DatabasePath
        {
            get
            {
                string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "HotelManagementSystem");

                Directory.CreateDirectory(folder);

                return Path.Combine(folder, "hotel.db");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DatabasePath}");
        }
        //OnModelCreating represent all the relationship
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureUsers(modelBuilder);
            ConfigureHotelsAndRooms(modelBuilder);
            ConfigureBookings(modelBuilder);
            ConfigurePayments(modelBuilder);
            ConfigureDiscounts(modelBuilder);
            ConfigureNotifications(modelBuilder);

        }
        private static void ConfigureUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Guest>("Guest")
                .HasValue<Manager>("Manager")
                .HasValue<Admin>("Admin");

            modelBuilder.Entity<User>()
                .HasIndex(user => user.Email)
                .IsUnique();
        }

        private static void ConfigureHotelsAndRooms(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasOne(hotel => hotel.Manager)
                .WithMany(manager => manager.Hotels)
                .HasForeignKey(hotel => hotel.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Room>()
                .HasOne(room => room.Hotel)
                .WithMany(hotel => hotel.Rooms)
                .HasForeignKey(room => room.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Room>()
                .HasIndex(room => new
                {
                    room.HotelId,
                    room.Number
                })
                .IsUnique();
        }

        private static void ConfigureBookings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasOne(booking => booking.Guest)
                .WithMany(guest => guest.Bookings)
                .HasForeignKey(booking => booking.GuestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(booking => booking.Room)
                .WithMany(room => room.Bookings)
                .HasForeignKey(booking => booking.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigurePayments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasOne(booking => booking.Payment)
                .WithOne(payment => payment.Booking)
                .HasForeignKey<Payment>(
                    payment => payment.BookingId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private static void ConfigureDiscounts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discount>()
                .HasIndex(discount => discount.Code)
                .IsUnique();

            modelBuilder.Entity<Booking>()
                .HasOne(booking => booking.Discount)
                .WithMany(discount => discount.Bookings)
                .HasForeignKey(booking => booking.DiscountId)
                .OnDelete(DeleteBehavior.SetNull);
        }

        private static void ConfigureNotifications(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>()
                .HasOne(notification => notification.User)
                .WithMany(user => user.Notifications)
                .HasForeignKey(notification => notification.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
