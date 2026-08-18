using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class Guest : User
    {
        public Guest ()
        {
            Role = "Guest";
        }

        public List<Booking> Bookings { get; set; } = new();
    }
}
