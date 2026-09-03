using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Models;
using HotelManagementSystem.Services;
using Xunit;

namespace HotelManagementSystem.Tests
{
    public class BookingValidatorTests
    {
        [Fact]
        public void ConflictsWith_OverlappingBooking_ReturnsTrue()
        {
            Booking existingBooking = CreateBooking(
                id: 1,
                roomId: 10,
                checkIn: new DateTime(2026, 9, 10),
                checkOut: new DateTime(2026, 9, 15));

            Func<Booking, bool> predicate =
                BookingValidator.ConflictsWith(
                    roomId: 10,
                    checkIn: new DateTime(2026, 9, 12),
                    checkOut: new DateTime(2026, 9, 17))
                .Compile();

            Assert.True(predicate(existingBooking));
        }

        [Fact]
        public void ConflictsWith_NewBookingInsideExisting_ReturnsTrue()
        {
            Booking existingBooking = CreateBooking(
                id: 1,
                roomId: 10,
                checkIn: new DateTime(2026, 9, 10),
                checkOut: new DateTime(2026, 9, 20));

            Func<Booking, bool> predicate =
                BookingValidator.ConflictsWith(
                    roomId: 10,
                    checkIn: new DateTime(2026, 9, 12),
                    checkOut: new DateTime(2026, 9, 15))
                .Compile();

            Assert.True(predicate(existingBooking));
        }

        [Fact]
        public void ConflictsWith_AdjacentDates_ReturnsFalse()
        {
            Booking existingBooking = CreateBooking(
                id: 1,
                roomId: 10,
                checkIn: new DateTime(2026, 9, 10),
                checkOut: new DateTime(2026, 9, 15));

            Func<Booking, bool> predicate =
                BookingValidator.ConflictsWith(
                    roomId: 10,
                    checkIn: new DateTime(2026, 9, 15),
                    checkOut: new DateTime(2026, 9, 20))
                .Compile();

            Assert.False(predicate(existingBooking));
        }

        [Fact]
        public void ConflictsWith_DifferentRoom_ReturnsFalse()
        {
            Booking existingBooking = CreateBooking(
                id: 1,
                roomId: 20,
                checkIn: new DateTime(2026, 9, 10),
                checkOut: new DateTime(2026, 9, 15));

            Func<Booking, bool> predicate =
                BookingValidator.ConflictsWith(
                    roomId: 10,
                    checkIn: new DateTime(2026, 9, 12),
                    checkOut: new DateTime(2026, 9, 17))
                .Compile();

            Assert.False(predicate(existingBooking));
        }

        [Fact]
        public void ConflictsWith_CancelledBooking_ReturnsFalse()
        {
            Booking existingBooking = CreateBooking(
                id: 1,
                roomId: 10,
                checkIn: new DateTime(2026, 9, 10),
                checkOut: new DateTime(2026, 9, 15),
                status: BookingStatus.Cancelled);

            Func<Booking, bool> predicate =
                BookingValidator.ConflictsWith(
                    roomId: 10,
                    checkIn: new DateTime(2026, 9, 12),
                    checkOut: new DateTime(2026, 9, 17))
                .Compile();

            Assert.False(predicate(existingBooking));
        }

        [Fact]
        public void ConflictsWith_RejectedBooking_ReturnsFalse()
        {
            Booking existingBooking = CreateBooking(
                id: 1,
                roomId: 10,
                checkIn: new DateTime(2026, 9, 10),
                checkOut: new DateTime(2026, 9, 15),
                status: BookingStatus.Rejected);

            Func<Booking, bool> predicate =
                BookingValidator.ConflictsWith(
                    roomId: 10,
                    checkIn: new DateTime(2026, 9, 12),
                    checkOut: new DateTime(2026, 9, 17))
                .Compile();

            Assert.False(predicate(existingBooking));
        }

        [Fact]
        public void ConflictsWith_ExcludedBooking_ReturnsFalse()
        {
            Booking existingBooking = CreateBooking(
                id: 25,
                roomId: 10,
                checkIn: new DateTime(2026, 9, 10),
                checkOut: new DateTime(2026, 9, 15));

            Func<Booking, bool> predicate =
                BookingValidator.ConflictsWith(
                    roomId: 10,
                    checkIn: new DateTime(2026, 9, 12),
                    checkOut: new DateTime(2026, 9, 17),
                    excludedBookingId: 25)
                .Compile();

            Assert.False(predicate(existingBooking));
        }

        private static Booking CreateBooking(
            int id,
            int roomId,
            DateTime checkIn,
            DateTime checkOut,
            BookingStatus status = BookingStatus.Pending)
        {
            return new Booking
            {
                Id = id,
                RoomId = roomId,
                CheckInDate = checkIn,
                CheckOutDate = checkOut,
                Status = status
            };
        }
    }
}
