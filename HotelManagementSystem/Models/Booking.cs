using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        public decimal Subtotal { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal TotalAmount { get; set; }

        //Every booking belong to one guest
        public int GuestId { get; set; }

        public Guest? Guest { get; set; }

        //Every booking reserves one room
        public int RoomId {  get; set; }

        public Room? Room { get; set; }

        //A booking can have zero or one discount
        public int? DiscountId { get; set; }

        public Discount? Discount { get; set; }

        //A booking can have zero or more payment
        public Payment? Payment { get; set; }

        public int NumberOfNights
        {
            get
            {
                return (CheckOutDate.Date - CheckInDate.Date).Days;
            }
        }

    }
}
