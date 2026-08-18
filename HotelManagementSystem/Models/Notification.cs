using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";

        public string Message { get; set; } = "";

        public bool IsRead { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //Every notificatioin belongs to one user
        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
