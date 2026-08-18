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

            int numberOfNights = (checkOut - checkIn).Days;

            subtotal = room.PricePerNight * numberOfNights;

            discountAmount = 0;
            totalAmount = subtotal;

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

            discountAmount = decimal.Round(
                subtotal * discount.Percentage / 100m,
                2);

            totalAmount = subtotal - discountAmount;

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

            if (!IsValidCardNumber(cardNumber))
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

            bool bookingConflict = db.Bookings.Any(
                booking => booking.RoomId == roomId &&
                booking.Status != BookingStatus.Cancelled &&
                booking.Status != BookingStatus.Rejected &&
                checkIn < booking.CheckOutDate &&
                checkOut > booking.CheckInDate);

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

                discountAmount = decimal.Round(subtotal * discount.Percentage / 100m,2);

                totalAmount = subtotal - discountAmount;
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

        private static bool IsValidCardNumber(string cardNumber)
        {
            if (cardNumber.Length < 13 ||
                cardNumber.Length > 19)
            {
                return false;
            }

            int sum = 0;
            bool doubleDigit = false;

            for (int index = cardNumber.Length - 1;
                 index >= 0;
                 index--)
            {
                int digit = cardNumber[index] - '0';

                if (doubleDigit)
                {
                    digit *= 2;

                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                sum += digit;
                doubleDigit = !doubleDigit;
            }

            return sum % 10 == 0;
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
