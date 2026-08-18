using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string Number { get; set; } = "";

        public string Type { get; set; } = "";

        public int Capacity { get; set; }

        public decimal PricePerNight { get; set; }

        public string Description { get; set; } = "";

        public RoomStatus Status { get; set; } = RoomStatus.Available;

        // Every room belongs to one hotel
        public int HotelId { get; set; }

        public Hotel? Hotel { get; set; }

        //A room can appear in several booking over time
        public List<Booking> Bookings { get; set; } = new();
    }
}
