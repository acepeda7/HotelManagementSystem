using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem
{
    public partial class ModifyBookingForm : Form
    {
        private int guestId;
        private int bookingId;

        private decimal roomPricePerNight;
        private decimal originalDiscountRate;

        private decimal newSubtotal;
        private decimal newDiscountAmount;
        private decimal newTotal;
        public ModifyBookingForm()
        {
            InitializeComponent();
        }

        public ModifyBookingForm(int guestId, int bookingId) : this()
        {
            this.guestId = guestId;
            this.bookingId = bookingId;

            LoadBooking();
        }

        private void LoadBooking()
        {
            using AppDbContext db = new AppDbContext();

            Booking? booking = db.Bookings
                .Include(item => item.Room)
                .ThenInclude(room => room.Hotel)
                .FirstOrDefault(item =>
                    item.Id == bookingId &&
                    item.GuestId == guestId);

            if (booking == null || booking.Room == null || booking.Room.Hotel == null)
            {
                MessageBox.Show("The booking could not be found.");

                Close();
                return;
            }

            if (!CanModify(booking))
            {
                MessageBox.Show(
                    "This booking cannot be modified.",
                    "Modification unavailable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            roomPricePerNight = booking.Room.PricePerNight;

            if (booking.Subtotal > 0)
            {
                originalDiscountRate = booking.DiscountAmount / booking.Subtotal;
            }
            else
            {
                originalDiscountRate = 0;
            }

            lblHotelValue.Text = booking.Room.Hotel.Name;

            lblRoomValue.Text = $"{booking.Room.Number} - " + booking.Room.Type;

            lblCurrentDatesValue.Text = $"{booking.CheckInDate:d} to " + $"{booking.CheckOutDate:d}";

            dtpNewCheckIn.MinDate = DateTime.Today;

            dtpNewCheckOut.MinDate = DateTime.Today.AddDays(1);

            dtpNewCheckIn.Value = booking.CheckInDate.Date < DateTime.Today
                    ? DateTime.Today
                    : booking.CheckInDate.Date;

            dtpNewCheckOut.Value =
                booking.CheckOutDate.Date <=
                dtpNewCheckIn.Value.Date
                    ? dtpNewCheckIn.Value.Date.AddDays(1)
                    : booking.CheckOutDate.Date;

            CalculateNewPrice();
        }

        private static bool CanModify(Booking booking)
        {
            return booking.Status ==
                       BookingStatus.Pending ||
                   booking.Status ==
                       BookingStatus.Approved;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateNewPrice();
        }

        private bool CalculateNewPrice()
        {
            DateTime newCheckIn = dtpNewCheckIn.Value.Date;

            DateTime newCheckOut = dtpNewCheckOut.Value.Date;

            if (newCheckIn < DateTime.Today)
            {
                ShowError("Check-in cannot be in the past.");

                return false;
            }

            if (newCheckOut <= newCheckIn)
            {
                ShowError("Check-out must be after check-in.");

                return false;
            }

            int nights = (newCheckOut - newCheckIn).Days;

            newSubtotal = roomPricePerNight * nights;

            newDiscountAmount = decimal.Round( newSubtotal * originalDiscountRate, 2);

            newTotal = newSubtotal - newDiscountAmount;

            lblNewNightsValue.Text = $"Nights: {nights}";

            lblNewSubtotalValue.Text = $"Subtotal: {newSubtotal:C}";

            lblNewDiscountValue.Text = $"Discount: -{newDiscountAmount:C}";

            lblNewTotalValue.Text = $"Total: {newTotal:C}";

            lblMessage.Text = "";

            return true;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (!CalculateNewPrice())
            {
                return;
            }

            DateTime newCheckIn = dtpNewCheckIn.Value.Date;

            DateTime newCheckOut = dtpNewCheckOut.Value.Date;

            using AppDbContext db = new AppDbContext();
            using var transaction = db.Database.BeginTransaction();

            Booking? booking = db.Bookings
                .Include(item => item.Room)
                .ThenInclude(room => room.Hotel)
                .Include(item => item.Payment)
                .FirstOrDefault(item =>
                    item.Id == bookingId &&
                    item.GuestId == guestId);

            if (booking == null ||
                booking.Room == null ||
                booking.Room.Hotel == null)
            {
                ShowError("The booking could not be found.");

                return;
            }

            if (!CanModify(booking))
            {
                ShowError("This booking can no longer be modified.");

                return;
            }

            bool conflict = db.Bookings.Any(
            otherBooking =>
                otherBooking.Id != booking.Id &&
                otherBooking.RoomId == booking.RoomId &&
                otherBooking.Status !=
                    BookingStatus.Cancelled &&
                otherBooking.Status !=
                    BookingStatus.Rejected &&
                newCheckIn <
                    otherBooking.CheckOutDate &&
                newCheckOut >
                    otherBooking.CheckInDate);

            if (conflict)
            {
                ShowError("The room is unavailable for the new dates.");

                return;
            }

            decimal oldTotal = booking.TotalAmount;

            DialogResult answer = MessageBox.Show(
                $"Old total: {oldTotal:C}\n" +
                $"New total: {newTotal:C}\n\n" +
                "Save these changes?",
                "Confirm modification",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            booking.CheckInDate = newCheckIn;
            booking.CheckOutDate = newCheckOut;
            booking.Subtotal = newSubtotal;
            booking.DiscountAmount = newDiscountAmount;
            booking.TotalAmount = newTotal;

            // The manager must approve the changed dates again.
            booking.Status = BookingStatus.Pending;

            /*
             * This project uses a simulated payment system.
             * A real application would charge or refund the
             * difference through its payment provider.
             */
            if (booking.Payment != null && booking.Payment.Status ==  PaymentStatus.Paid)
            {
                booking.Payment.Amount = newTotal;
            }

            Notification notification =
                new Notification
                {
                    UserId = guestId,
                    Title = "Booking modified",
                    Message =
                        $"Booking #{booking.Id} at " +
                        $"{booking.Room.Hotel.Name} was " +
                        "modified and is awaiting approval.",
                    IsRead = false,
                    CreatedAt = DateTime.Now
                };

            db.Notifications.Add(notification);
            db.SaveChanges();

            transaction.Commit();

            MessageBox.Show(
                "The booking was modified successfully.",
                "Booking updated",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();

        }

        private void ShowError(string message)
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = message;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
