using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public static class BookingCalculator
    {
        public static int CalculateNights(
            DateTime checkIn,
            DateTime checkOut)
        {
            return (checkOut - checkIn).Days;
        }

        public static decimal CalculateSubtotal(
            decimal pricePerNight,
            int numberOfNights)
        {
            return pricePerNight * numberOfNights;
        }

        public static decimal CalculateDiscount(
            decimal subtotal,
            decimal percentage)
        {
            return decimal.Round(
                subtotal * percentage / 100m,
                2);
        }

        public static decimal CalculateTotal(
            decimal subtotal,
            decimal discountAmount)
        {
            return subtotal - discountAmount;
        }
    }
}
