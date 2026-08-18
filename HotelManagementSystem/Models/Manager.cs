using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{

    public class Manager : User
    {
        public Manager()
        {
            Role = "Manager";
        }

        public List<Hotel> Hotels { get; set; } = new();

    }

}
