using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class Discount
    {
        public int Id { get; set; }

        public string Code { get; set; } = "";

        public decimal Percentage { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }

        public bool IsActive { get; set; } = true;

        //one discount can be aplied to many bookings...
        public List<Booking> Bookings { get; set; } = new();

        public bool IsValid()
        {
            DateTime today = DateTime.Today;

            return IsActive &&
                today >= ValidFrom.Date &&
                today <= ValidUntil.Date;
        }
    }
}
