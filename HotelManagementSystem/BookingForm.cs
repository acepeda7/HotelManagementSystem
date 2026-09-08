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
using HotelManagementSystem.Services;
using HotelManagementSystem.UI;

namespace HotelManagementSystem
{
    public partial class BookingForm : Form
    {
        private int guestId;
        private int roomId;
        private DateTime checkIn;
        private DateTime checkOut;

        private decimal subtotal;
        private decimal discountAmount;
        private decimal totalAmount;

        private int? selectedDiscountId;
        public BookingForm()
        {
            InitializeComponent();

            AppTheme.Apply(this);
            ImproveBookingLayout();
        }

        private void ImproveBookingLayout()
        {
            SuspendLayout();

            Text = "Confirm Booking";
            ClientSize = new Size(584, 660);
            BackColor = AppTheme.Background;

            const int formWidth = 584;
            const int labelLeft = 75;
            const int valueLeft = 220;
            const int fieldWidth = 290;

            // Título
            lblTitle.Text = "Confirm your booking";
            lblTitle.Font = new Font(
                "Segoe UI Semibold",
                20F,
                FontStyle.Regular);

            lblTitle.AutoSize = true;
            lblTitle.Top = 32;
            lblTitle.Left =
                (formWidth - lblTitle.Width) / 2;

            // Resumen de la reserva
            PositionSummaryRow(
                label1,
                lblHotelValue,
                "Hotel",
                labelLeft,
                valueLeft,
                95,
                fieldWidth);

            PositionSummaryRow(
                label2,
                lblRoomValue,
                "Room",
                labelLeft,
                valueLeft,
                135,
                fieldWidth);

            PositionSummaryRow(
                label3,
                lblDatesValue,
                "Dates",
                labelLeft,
                valueLeft,
                175,
                fieldWidth);

            PositionSummaryRow(
                label4,
                lblNightsValue,
                "Nights",
                labelLeft,
                valueLeft,
                215,
                fieldWidth);

            PositionSummaryRow(
                label5,
                lblSubtotalValue,
                "Subtotal",
                labelLeft,
                valueLeft,
                255,
                fieldWidth);

            // Código de descuento
            label6.Text = "Discount code";
            label6.Left = labelLeft;
            label6.Top = 305;
            label6.ForeColor = AppTheme.MutedText;

            txtDiscountCode.Left = valueLeft;
            txtDiscountCode.Top = 300;
            txtDiscountCode.Width = 165;
            txtDiscountCode.AutoSize = true;

            btnApplyDiscount.Text = "Apply";
            btnApplyDiscount.Left = 395;
            btnApplyDiscount.Top = 297;
            btnApplyDiscount.Width = 115;
            btnApplyDiscount.Height = 32;

            // Descuento aplicado
            lblDiscountValue.AutoSize = false;
            lblDiscountValue.Left = valueLeft;
            lblDiscountValue.Top = 350;
            lblDiscountValue.Width = fieldWidth;
            lblDiscountValue.Height = 24;
            lblDiscountValue.ForeColor = AppTheme.MutedText;

            // Total
            lblTotalValue.AutoSize = false;
            lblTotalValue.Left = valueLeft;
            lblTotalValue.Top = 388;
            lblTotalValue.Width = fieldWidth;
            lblTotalValue.Height = 30;
            lblTotalValue.Font = new Font(
                "Segoe UI Semibold",
                13F,
                FontStyle.Regular);

            lblTotalValue.ForeColor = AppTheme.PrimaryDark;

            // Nombre del titular
            label7.Text = "Cardholder name";
            label7.Left = labelLeft;
            label7.Top = 444;
            label7.ForeColor = AppTheme.MutedText;

            txtCardholderName.Left = valueLeft;
            txtCardholderName.Top = 440;
            txtCardholderName.Width = fieldWidth;
            txtCardholderName.AutoSize = true;

            // Número de tarjeta legible
            label8.Text = "Card number";
            label8.Left = labelLeft;
            label8.Top = 496;
            label8.ForeColor = AppTheme.MutedText;

            txtCardNumber.Left = valueLeft;
            txtCardNumber.Top = 492;
            txtCardNumber.Width = fieldWidth;
            txtCardNumber.AutoSize = true;
            txtCardNumber.UseSystemPasswordChar = false;
            txtCardNumber.PasswordChar = '\0';

            // Mensaje de validación
            lblMessage.AutoSize = false;
            lblMessage.Left = labelLeft;
            lblMessage.Top = 535;
            lblMessage.Width = 435;
            lblMessage.Height = 24;
            lblMessage.ForeColor = Color.IndianRed;
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            // Confirmar reserva
            btnConfirmBooking.Text = "Pay and book";
            btnConfirmBooking.Left = 92;
            btnConfirmBooking.Top = 575;
            btnConfirmBooking.Width = 190;
            btnConfirmBooking.Height = 40;
            btnConfirmBooking.BackColor = AppTheme.Primary;
            btnConfirmBooking.ForeColor = Color.White;
            btnConfirmBooking.FlatStyle = FlatStyle.Flat;
            btnConfirmBooking.FlatAppearance.BorderSize = 0;

            // Cancelar
            btnCancel.Text = "Cancel";
            btnCancel.Left = 302;
            btnCancel.Top = 575;
            btnCancel.Width = 190;
            btnCancel.Height = 40;
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = AppTheme.Primary;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor =
                AppTheme.Primary;
            btnCancel.FlatAppearance.BorderSize = 1;

            AcceptButton = btnConfirmBooking;
            CancelButton = btnCancel;

            ResumeLayout(false);
            PerformLayout();
        }

        private static void PositionSummaryRow(
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

            value.Left = valueLeft;
            value.Top = top;
            value.Width = valueWidth;
            value.Height = 24;
            value.AutoSize = false;
            value.AutoEllipsis = true;
        }

        public BookingForm(int guestId,
            int roomId,
            DateTime checkIn,
            DateTime checkOut) : this()
        {
            this.guestId = guestId;
            this.roomId = roomId;
            this.checkIn = checkIn;
            this.checkOut = checkOut;

            LoadBookingSumary();
        }

        private void LoadBookingSumary()
        {
            using AppDbContext db = new AppDbContext();

            Room? room = db.Rooms.Include(item => item.Hotel)
                .FirstOrDefault(ItemActivation => ItemActivation.Id == roomId);

            if (room == null || room.Hotel == null)
            {
                MessageBox.Show("The selected room could not be found.");

                Close();
                return;
            }

            int numberOfNights = BookingCalculator.CalculateNights(checkIn,checkOut);

            subtotal = BookingCalculator.CalculateSubtotal(room.PricePerNight,numberOfNights);

            discountAmount = 0m;

            totalAmount = BookingCalculator.CalculateTotal(subtotal,discountAmount);

            lblHotelValue.Text = $"{room.Hotel.Name} ({room.Hotel.StarRating} stars)";

            lblRoomValue.Text = $"{room.Number} - {room.Type}";

            lblDatesValue.Text = $"{checkIn:d} to {checkOut:d}";

            lblNightsValue.Text = numberOfNights.ToString();

            UpdatePriceLabels();

        }

        private void btnApplyDiscount_Click(object sender, EventArgs e)
        {
            string code = txtDiscountCode.Text.Trim().ToUpper();

            if(string.IsNullOrEmpty(code))
            {
                selectedDiscountId = null;
                discountAmount = 0;
                totalAmount = subtotal;

                UpdatePriceLabels();
                ShowError("Enter a discount code.");
                return;
            }

            using AppDbContext db = new AppDbContext();

            Discount? discount = db.Discounts.FirstOrDefault(item => item.Code == code && item.IsActive);

            if (discount == null || !discount.IsValid())
            {
                selectedDiscountId = null;
                discountAmount = 0;
                totalAmount = subtotal;

                UpdatePriceLabels();
                ShowError("The discount code is invalid or expired.");
                return;
            }

            selectedDiscountId = discount.Id;

            discountAmount = BookingCalculator.CalculateDiscount(subtotal,discount.Percentage);

            totalAmount = BookingCalculator.CalculateTotal(subtotal,discountAmount);

            UpdatePriceLabels();

            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = $"{discount.Percentage}% discount applied.";

        }

        private void UpdatePriceLabels()
        {
            lblSubtotalValue.Text =
                $"Subtotal: {subtotal:C}";

            lblDiscountValue.Text =
                $"Discount: -{discountAmount:C}";

            lblTotalValue.Text =
                $"Total: {totalAmount:C}";
        }
        private void btnConfirmBooking_Click(object sender, EventArgs e)
        {

            string cardholderName = txtCardholderName.Text.Trim();

            string cardNumber = new string(txtCardNumber.Text.Where(char.IsDigit).ToArray());

            if (string.IsNullOrWhiteSpace(cardholderName))
            {
                ShowError("Enter the cardholder name.");
                txtCardholderName.Focus();
                return;
            }

            if (!CardValidator.IsValid(cardNumber))
            {
                ShowError("Enter a valid card number.");
                txtCardNumber.Focus();
                return;
            }

            try
            {
                CreateBookingAndPayment(cardNumber);

                MessageBox.Show(
                    "Your payment was successful and the booking " +
                    "is awaiting manager approval.",
                    "Booking created",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exception)
            {
                ShowError(exception.Message);
            }

        }

        private void CreateBookingAndPayment(string cardNumber)
        {
            using AppDbContext db = new AppDbContext();
            using var transaction = db.Database.BeginTransaction();

            Room? room = db.Rooms.Include(item => item.Hotel).FirstOrDefault(item => item.Id == roomId);

            if (room == null || room.Hotel == null)
            {
                throw new InvalidOperationException("The selected room no longer exists.");
            }

            bool bookingConflict = db.Bookings.Any(BookingValidator.ConflictsWith(roomId,checkIn,checkOut));

            if (room.Status != RoomStatus.Available || bookingConflict)
            {
                throw new InvalidOperationException("This room is no longer available for those dates.");
            }

            //Validate the discount again before saving.
            Discount? discount = null;

            if (selectedDiscountId.HasValue)
            {
                discount = db.Discounts.FirstOrDefault(item => item.Id == selectedDiscountId.Value);

                if (discount == null || !discount.IsValid())
                {
                    throw new InvalidOperationException("The selected discount is no longer valid.");
                }

                discountAmount = BookingCalculator.CalculateDiscount(subtotal,discount.Percentage);

                totalAmount = BookingCalculator.CalculateTotal(subtotal,discountAmount);
            }

            Booking booking = new Booking
            {
                GuestId = guestId,
                RoomId = roomId,
                CheckInDate = checkIn,
                CheckOutDate = checkOut,
                CreatedAt = DateTime.Now,
                Status = BookingStatus.Pending,
                Subtotal = subtotal,
                DiscountAmount = discountAmount,
                TotalAmount = totalAmount,
                DiscountId = discount?.Id
            };

            db.Bookings.Add(booking);
            db.SaveChanges();

            Payment payment = new Payment
            {
                BookingId = booking.Id,
                Amount = totalAmount,
                PaymentMethod = "Card",
                CardLastFourDigits = cardNumber[^4..],
                TransactionReference = $"SIM-{Guid.NewGuid():N}",
                Status = PaymentStatus.Paid,
                PaidAt = DateTime.Now
            };

            Notification notification = new Notification
            {
                UserId = guestId,
                Title = "Booking received",
                Message = $"Booking #{booking.Id} for room " + $"{room.Number} at {room.Hotel.Name} " +
                    "is awaiting manager approval.",
                IsRead = false,
                CreatedAt = DateTime.Now
            };

            db.Payments.Add(payment);
            db.Notifications.Add(notification);
            db.SaveChanges();

            transaction.Commit();
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
