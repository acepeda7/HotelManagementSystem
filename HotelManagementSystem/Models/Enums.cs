using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public enum RoomStatus
    {
        Available, Maintenance, OutOfService
    }

    public enum BookingStatus
    {
        Pending, Approved, Rejected, Cancelled, Completed
    }

    public enum PaymentStatus
    {
        Paid, Refunded, Failed
    }
}
