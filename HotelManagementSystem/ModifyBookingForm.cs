using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using HotelManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagementSystem.UI;

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
            AppTheme.Apply(this);
            ImproveModifyBookingLayout();
        }

        private void ImproveModifyBookingLayout()
        {
            SuspendLayout();

            Text = "Modify Booking";
            ClientSize = new Size(560, 610);
            BackColor = AppTheme.Background;

            const int labelLeft = 65;
            const int valueLeft = 220;
            const int valueWidth = 275;

            // Título nuevo
            Label lblPageTitle = new()
            {
                Name = "lblPageTitle",
                Text = "Modify your booking",
                AutoSize = true,
                Font = new Font(
                    "Segoe UI Semibold",
                    20F,
                    FontStyle.Regular),
                ForeColor = AppTheme.Text,
                BackColor = AppTheme.Background,
                Top = 30
            };

            lblPageTitle.Left =
                (ClientSize.Width - lblPageTitle.Width) / 2;

            Controls.Add(lblPageTitle);

            // Información actual
            PositionModifyRow(
                label1,
                lblHotelValue,
                "Hotel",
                labelLeft,
                valueLeft,
                100,
                valueWidth);

            PositionModifyRow(
                label2,
                lblRoomValue,
                "Room",
                labelLeft,
                valueLeft,
                140,
                valueWidth);

            PositionModifyRow(
                label3,
                lblCurrentDatesValue,
                "Current dates",
                labelLeft,
                valueLeft,
                180,
                valueWidth);

            // Nueva fecha de entrada
            label4.Text = "New check-in";
            label4.Left = labelLeft;
            label4.Top = 235;
            label4.ForeColor = AppTheme.MutedText;

            dtpNewCheckIn.Left = valueLeft;
            dtpNewCheckIn.Top = 230;
            dtpNewCheckIn.Width = valueWidth;
            dtpNewCheckIn.Format = DateTimePickerFormat.Short;

            // Nueva fecha de salida
            label5.Text = "New check-out";
            label5.Left = labelLeft;
            label5.Top = 285;
            label5.ForeColor = AppTheme.MutedText;

            dtpNewCheckOut.Left = valueLeft;
            dtpNewCheckOut.Top = 280;
            dtpNewCheckOut.Width = valueWidth;
            dtpNewCheckOut.Format = DateTimePickerFormat.Short;

            // Nuevo cálculo
            lblNewNightsValue.AutoSize = false;
            lblNewNightsValue.Left = valueLeft;
            lblNewNightsValue.Top = 335;
            lblNewNightsValue.Width = valueWidth;
            lblNewNightsValue.Height = 24;
            lblNewNightsValue.ForeColor = AppTheme.Text;

            lblNewSubtotalValue.AutoSize = false;
            lblNewSubtotalValue.Left = valueLeft;
            lblNewSubtotalValue.Top = 370;
            lblNewSubtotalValue.Width = valueWidth;
            lblNewSubtotalValue.Height = 24;
            lblNewSubtotalValue.ForeColor = AppTheme.Text;

            lblNewDiscountValue.AutoSize = false;
            lblNewDiscountValue.Left = valueLeft;
            lblNewDiscountValue.Top = 405;
            lblNewDiscountValue.Width = valueWidth;
            lblNewDiscountValue.Height = 24;
            lblNewDiscountValue.ForeColor = AppTheme.MutedText;

            lblNewTotalValue.AutoSize = false;
            lblNewTotalValue.Left = valueLeft;
            lblNewTotalValue.Top = 442;
            lblNewTotalValue.Width = valueWidth;
            lblNewTotalValue.Height = 30;
            lblNewTotalValue.Font = new Font(
                "Segoe UI Semibold",
                13F,
                FontStyle.Regular);

            lblNewTotalValue.ForeColor = AppTheme.PrimaryDark;

            // Mensaje de validación
            lblMessage.AutoSize = false;
            lblMessage.Left = labelLeft;
            lblMessage.Top = 480;
            lblMessage.Width = 430;
            lblMessage.Height = 24;
            lblMessage.ForeColor = Color.IndianRed;
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            // Calcular nuevo precio
            btnCalculate.Text = "Calculate price";
            btnCalculate.Left = 30;
            btnCalculate.Top = 525;
            btnCalculate.Width = 155;
            btnCalculate.Height = 40;
            btnCalculate.BackColor = Color.White;
            btnCalculate.ForeColor = AppTheme.Primary;
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.FlatAppearance.BorderColor =
                AppTheme.Primary;
            btnCalculate.FlatAppearance.BorderSize = 1;

            // Guardar cambios
            btnSaveChanges.Text = "Save changes";
            btnSaveChanges.Left = 202;
            btnSaveChanges.Top = 525;
            btnSaveChanges.Width = 155;
            btnSaveChanges.Height = 40;
            btnSaveChanges.BackColor = AppTheme.Primary;
            btnSaveChanges.ForeColor = Color.White;
            btnSaveChanges.FlatStyle = FlatStyle.Flat;
            btnSaveChanges.FlatAppearance.BorderSize = 0;

            // Cancelar
            btnCancel.Text = "Cancel";
            btnCancel.Left = 374;
            btnCancel.Top = 525;
            btnCancel.Width = 155;
            btnCancel.Height = 40;
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = AppTheme.Primary;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor =
                AppTheme.Primary;
            btnCancel.FlatAppearance.BorderSize = 1;

            AcceptButton = btnSaveChanges;
            CancelButton = btnCancel;

            ResumeLayout(false);
            PerformLayout();
        }

        private static void PositionModifyRow(
            Label description,
            Label value,
            string descriptionText,
            int labelLeft,
            int valueLeft,
            int top,
            int valueWidth)
        {
            description.Text = descriptionText;
            description.Left = labelLeft;
            description.Top = top;
            description.ForeColor = AppTheme.MutedText;

            value.AutoSize = false;
            value.Left = valueLeft;
            value.Top = top;
            value.Width = valueWidth;
            value.Height = 24;
            value.AutoEllipsis = true;
            value.ForeColor = AppTheme.Text;
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

            newSubtotal = BookingCalculator.CalculateSubtotal(roomPricePerNight,nights);

            newDiscountAmount = BookingCalculator.CalculateDiscount(newSubtotal,originalDiscountRate * 100m);

            newTotal = BookingCalculator.CalculateTotal(newSubtotal,newDiscountAmount);

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

            bool conflict = db.Bookings.Any(BookingValidator.ConflictsWith(
                booking.RoomId, newCheckIn, newCheckOut, booking.Id));

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
