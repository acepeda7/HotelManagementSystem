using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Models;
using System.Linq.Expressions;

namespace HotelManagementSystem.Services
{
    public static class BookingValidator
    {
        public static Expression<Func<Booking, bool>>
            ConflictsWith(
                int roomId,
                DateTime checkIn,
                DateTime checkOut,
                int? excludedBookingId = null)
        {
            return booking =>
                (!excludedBookingId.HasValue ||
                 booking.Id != excludedBookingId.Value) &&
                booking.RoomId == roomId &&
                booking.Status != BookingStatus.Cancelled &&
                booking.Status != BookingStatus.Rejected &&
                checkIn < booking.CheckOutDate &&
                checkOut > booking.CheckInDate;
        }
    }
}
