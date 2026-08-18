using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Address { get; set; } = "";

        public string Description { get; set; } = "";

        public int StarRating { get; set; }

        //The manager responsible for this hotel
        public int ManagerId { get; set; }

        public Manager? Manager { get; set; }

        //One hotel can contain many rooms..
        public List<Room> Rooms { get; set; } = new();

    }
}
