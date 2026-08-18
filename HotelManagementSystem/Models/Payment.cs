using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = "Card";

        public string CardLastFourDigits { get; set; } = "";

        public string TransactionReference { get; set; } = "";

        public PaymentStatus Status { get; set; } = PaymentStatus.Paid;

        public DateTime PaidAt { get; set; } = DateTime.Now;

        public DateTime? RefundedAt { get; set; }

        //Every payment belongs to one booking
        public int BookingId { get; set; }

        public Booking? Booking { get; set; }

    }
}
