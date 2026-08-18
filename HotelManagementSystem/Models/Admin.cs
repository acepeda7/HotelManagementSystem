using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class Admin : User
    {
        public Admin()
        {
            Role = "Admin";
        }
    }

}
