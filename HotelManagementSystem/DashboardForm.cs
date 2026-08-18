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
    public partial class DashboardForm : Form
    {
        private User? currentUser;

        //Constructor
        public DashboardForm()
        {
            InitializeComponent();
        }

        //Login form constructor
        public DashboardForm(User user) : this()
        {
            currentUser = user;

            ShowUserInformation();
            ConfigureDashboard();

            if (currentUser is Guest)
            {
                dtpCheckIn.Value = DateTime.Today.AddDays(1);
                dtpCheckOut.Value = DateTime.Today.AddDays(2);

                LoadAvailableRooms();
                LoadMyBookings();
            }
            else if (currentUser is Manager)
            {
                LoadManagerHotels();
                LoadManagerRooms();
                LoadPendingBookings();
            }
            else if (currentUser is Admin)
            {
                dtpReportFrom.Value = DateTime.Today.AddMonths(-1);

                dtpReportTo.Value = DateTime.Today;

                LoadAdminUsers();
                LoadPendingRefunds();
                GenerateAdminReports();

            }
            LoadNotifications();
        }

        private void ShowUserInformation()
        {
            if (currentUser == null)
            {
                return;
            }
            lblWelcome.Text = $"Welcome, {currentUser.FullName}";
            lblRole.Text = $"Role: {currentUser.Role}";
        }

        private void ConfigureDashboard()
        {
            if (currentUser == null)
            {
                return;
            }
            if (currentUser is Guest)
            {
                tabDashboard.TabPages.Remove(tabManager);
                tabDashboard.TabPages.Remove(tabAdmin);
            }
            else if (currentUser is Manager)
            {
                tabDashboard.TabPages.Remove(tabGuest);
                tabDashboard.TabPages.Remove(tabAdmin);
                tabDashboard.TabPages.Remove(tabMyBookings);
            }
            else if (currentUser is Admin)
            {
                tabDashboard.TabPages.Remove(tabManager);
                tabDashboard.TabPages.Remove(tabGuest);
                tabDashboard.TabPages.Remove(tabMyBookings);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearchRooms_Click(object sender, EventArgs e)
        {
            LoadAvailableRooms();
        }

        private void LoadAvailableRooms()
        {
            DateTime checkIn = dtpCheckIn.Value.Date;
            DateTime checkOut = dtpCheckOut.Value.Date;
            string search = txtHotelSearch.Text.Trim().ToLower();

            if (checkIn < DateTime.Today)
            {
                MessageBox.Show("The check-in date cannot be in the past.", "Invalid dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (checkOut <= checkIn)
            {
                MessageBox.Show("The check-out date must be after check-in.", "Invalid dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            using AppDbContext db = new AppDbContext();
            // the sql query to check available rooms
            var availableRooms = db.Rooms
                .Include(room => room.Hotel)
                .Where(room => room.Status == RoomStatus.Available &&
                (search == "" ||
                 room.Hotel!.Name.ToLower().Contains(search) ||
                 room.Hotel.Address.ToLower().Contains(search)) &&

                !room.Bookings.Any(booking =>
                booking.Status != BookingStatus.Cancelled &&
                booking.Status != BookingStatus.Rejected &&
                checkIn < booking.CheckOutDate &&
                checkOut > booking.CheckInDate))
                .OrderBy(room => room.Hotel!.Name)
                .ThenBy(room => room.Number)
                .Select(room => new
                {
                    Id = room.Id,
                    Hotel = room.Hotel!.Name,
                    Location = room.Hotel.Address,
                    Room = room.Number,
                    Type = room.Type,
                    Capacity = room.Capacity,
                    PricePerNight = room.PricePerNight,
                    Stars = room.Hotel.StarRating
                })
                .ToList();

            dgvRooms.DataSource = availableRooms;

            if (dgvRooms.Columns["Id"] != null)
            {
                dgvRooms.Columns["Id"].Visible = false;
            }

            if (availableRooms.Count == 0)
            {
                MessageBox.Show(
                "No rooms are available for the selected dates.",
                "No rooms found",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }

        }
        //room details
        private void btnViewRoomDetails_Click(object sender, EventArgs e)
        {
            if (dgvRooms.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a room first.",
                    "No room selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            object? idValue =
                dgvRooms.CurrentRow.Cells["Id"].Value;

            if (idValue == null)
            {
                return;
            }

            int roomId = Convert.ToInt32(idValue);

            using AppDbContext db = new AppDbContext();

            Room? room = db.Rooms
                .Include(selectedRoom => selectedRoom.Hotel)
                .FirstOrDefault(
                    selectedRoom => selectedRoom.Id == roomId);

            if (room == null || room.Hotel == null)
            {
                MessageBox.Show("The room could not be found.");
                return;
            }

            string details =
                $"Hotel: {room.Hotel.Name}\n" +
                $"Address: {room.Hotel.Address}\n" +
                $"Star rating: {room.Hotel.StarRating}/5\n\n" +
                $"Room: {room.Number}\n" +
                $"Type: {room.Type}\n" +
                $"Capacity: {room.Capacity} guest(s)\n" +
                $"Price: {room.PricePerNight:C} per night\n\n" +
                $"{room.Description}\n\n" +
                $"Hotel information:\n{room.Hotel.Description}";

            MessageBox.Show(
                details,
                "Room Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            if (currentUser is not Guest guest)
            {
                MessageBox.Show("Only guests can book rooms.");
                return;
            }
            if (dgvRooms.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a room first.",
                    "No room selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            int roomId = Convert.ToInt32(
                dgvRooms.CurrentRow.Cells["Id"].Value);

            DateTime checkIn = dtpCheckIn.Value.Date;
            DateTime checkOut = dtpCheckOut.Value.Date;

            using BookingForm bookingForm = new BookingForm(
                guest.Id,
                roomId,
                checkIn,
                checkOut);

            if (bookingForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadAvailableRooms();
            }
        }

        //my bookings dashboard:
        private void LoadMyBookings()
        {
            if (currentUser is not Guest guest)
            {
                return;
            }

            using AppDbContext db = new AppDbContext();

            var bookings = db.Bookings
                .Include(booking => booking.Room)
                .ThenInclude(room => room.Hotel)
                .Include(booking => booking.Payment)
                .Where(booking => booking.GuestId == guest.Id)
                .OrderByDescending(booking => booking.CreatedAt)
                .Select(booking => new
                {
                    Id = booking.Id,
                    Hotel = booking.Room!.Hotel!.Name,
                    Room = booking.Room.Number,
                    CheckIn = booking.CheckInDate,
                    CheckOut = booking.CheckOutDate,
                    Nights = booking.NumberOfNights,
                    Total = booking.TotalAmount,
                    BookingStatus = booking.Status,
                    PaymentStatus = booking.Payment == null
                        ? "Not paid"
                        : booking.Payment.Status.ToString()
                })
                .ToList();

            dgvMyBookings.DataSource = bookings;

            if (dgvMyBookings.Columns["Id"] != null)
            {
                dgvMyBookings.Columns["Id"].Visible = false;
            }
        }

        private void btnRefreshBookings_Click(object sender, EventArgs e)
        {
            LoadMyBookings();
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (currentUser is not Guest guest)
            {
                return;
            }

            if (dgvMyBookings.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a booking first.",
                    "No booking selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            int bookingId = Convert.ToInt32(dgvMyBookings.CurrentRow.Cells["Id"].Value);

            DialogResult answer = MessageBox.Show(
                "Are you sure you want to cancel this booking?",
                "Confirm cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            using AppDbContext db = new AppDbContext();

            Booking? booking = db.Bookings
                .Include(item => item.Room)
                .ThenInclude(room => room.Hotel)
                .FirstOrDefault(item =>
                    item.Id == bookingId && item.GuestId == guest.Id);

            if (booking == null)
            {
                MessageBox.Show("The booking could not be found.");
                return;
            }

            if (booking.Status == BookingStatus.Cancelled)
            {
                MessageBox.Show("This booking has already been cancelled.");
                return;
            }

            if (booking.Status == BookingStatus.Rejected)
            {
                MessageBox.Show("A rejected booking cannot be cancelled.");
                return;
            }

            if (booking.Status == BookingStatus.Completed)
            {
                MessageBox.Show("A completed booking cannot be cancelled.");
                return;
            }

            if (booking.CheckInDate.Date <= DateTime.Today)
            {
                MessageBox.Show(
                    "Bookings cannot be cancelled on or after check-in.",
                    "Cancellation unavailable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            booking.Status = BookingStatus.Cancelled;

            Notification notification = new Notification
            {
                UserId = guest.Id,
                Title = "Booking cancelled",
                Message =
                    $"Booking #{booking.Id} at " +
                    $"{booking.Room!.Hotel!.Name} was cancelled. " +
                    "An administrator can now process the refund.",
                IsRead = false,
                CreatedAt = DateTime.Now
            };

            db.Notifications.Add(notification);
            db.SaveChanges();

            MessageBox.Show(
                "The booking was cancelled successfully.",
                "Booking cancelled",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadMyBookings();
            LoadAvailableRooms();
            LoadNotifications();
        }

        private void LoadNotifications()
        {
            if (currentUser == null)
            {
                return;
            }

            using AppDbContext db = new AppDbContext();

            var notifications = db.Notifications
                .Where(notification =>
                    notification.UserId == currentUser.Id)
                .OrderByDescending(notification =>
                    notification.CreatedAt)
                .Select(notification => new
                {
                    Id = notification.Id,
                    Title = notification.Title,
                    Message = notification.Message,
                    Read = notification.IsRead,
                    Received = notification.CreatedAt
                })
                .ToList();

            dgvNotifications.DataSource = notifications;

            if (dgvNotifications.Columns["Id"] != null)
            {
                dgvNotifications.Columns["Id"].Visible = false;
            }
        }

        private void btnMarkNotificationRead_Click(object sender, EventArgs e)
        {
            if (currentUser == null || dgvNotifications.CurrentRow == null)
            {
                MessageBox.Show("Please select a notification first.");
                return;
            }

            int notificationId = Convert.ToInt32(dgvNotifications.CurrentRow.Cells["Id"].Value);

            using AppDbContext db = new AppDbContext();

            Notification? notification =
                db.Notifications.FirstOrDefault(item =>
                    item.Id == notificationId &&
                    item.UserId == currentUser.Id);

            if (notification == null)
            {
                MessageBox.Show("The notification could not be found.");
                return;
            }

            notification.IsRead = true;
            db.SaveChanges();

            LoadNotifications();
        }

        private void btnRefreshNotifications_Click(object sender, EventArgs e)
        {
            LoadNotifications();
        }

        private void btnModifyBooking_Click(object sender, EventArgs e)
        {
            if (currentUser is not Guest guest)
            {
                return;
            }

            if (dgvMyBookings.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a booking first.",
                    "No booking selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            int bookingId = Convert.ToInt32(dgvMyBookings.CurrentRow.Cells["Id"].Value);

            using ModifyBookingForm modifyForm = new ModifyBookingForm(guest.Id, bookingId);

            if (modifyForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadMyBookings();
                LoadAvailableRooms();
                LoadNotifications();
            }
        }

        //Add hotel Manager Funtion
        private void btnAddHotel_Click(object sender, EventArgs e)
        {
            if (currentUser is not Manager manager)
            {
                return;
            }

            using HotelForm hotelForm = new HotelForm(manager.Id);

            if (hotelForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadManagerHotels();
            }
        }

        private void btnEditHotel_Click(object sender, EventArgs e)
        {
            if (currentUser is not Manager manager)
            {
                return;
            }

            if (dgvManagerHotels.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a hotel first.",
                    "No hotel selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            int hotelId = Convert.ToInt32(dgvManagerHotels.CurrentRow.Cells["Id"].Value);

            using HotelForm hotelForm = new HotelForm(manager.Id, hotelId);

            if (hotelForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadManagerHotels();
            }
        }

        private void LoadManagerHotels()
        {
            if (currentUser is not Manager manager)
            {
                return;
            }

            using AppDbContext db = new AppDbContext();

            var hotels = db.Hotels
                .Where(hotel =>
                    hotel.ManagerId == manager.Id)
                .OrderBy(hotel => hotel.Name)
                .Select(hotel => new
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    Address = hotel.Address,
                    Stars = hotel.StarRating,
                    Rooms = hotel.Rooms.Count,
                    Description = hotel.Description
                })
                .ToList();

            dgvManagerHotels.DataSource = hotels;

            if (dgvManagerHotels.Columns["Id"] != null)
            {
                dgvManagerHotels.Columns["Id"].Visible = false;
            }
        }

        private void btnRefreshHotels_Click(object sender, EventArgs e)
        {
            LoadManagerHotels();
        }

        //step 13 add room manager methods
        private void LoadManagerRooms()
        {
            if (currentUser is not Manager manager)
            {
                return;
            }

            using AppDbContext db = new AppDbContext();

            var rooms = db.Rooms
                .Include(room => room.Hotel)
                .Where(room =>
                    room.Hotel!.ManagerId == manager.Id)
                .OrderBy(room => room.Hotel!.Name)
                .ThenBy(room => room.Number)
                .Select(room => new
                {
                    Id = room.Id,
                    Hotel = room.Hotel!.Name,
                    Number = room.Number,
                    Type = room.Type,
                    Capacity = room.Capacity,
                    PricePerNight = room.PricePerNight,
                    Status = room.Status,
                    Description = room.Description
                })
                .ToList();

            dgvManagerRooms.DataSource = rooms;

            if (dgvManagerRooms.Columns["Id"] != null)
            {
                dgvManagerRooms.Columns["Id"].Visible = false;
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (currentUser is not Manager manager)
            {
                return;
            }

            using AppDbContext db = new AppDbContext();

            if (!db.Hotels.Any(
                    hotel =>
                        hotel.ManagerId == manager.Id))
            {
                MessageBox.Show("Create a hotel before adding rooms.");

                return;
            }

            using RoomForm roomForm = new RoomForm(manager.Id);

            if (roomForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadManagerRooms();
                LoadManagerHotels();
            }
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            if (currentUser is not Manager manager)
            {
                return;
            }

            if (dgvManagerRooms.CurrentRow == null)
            {
                MessageBox.Show("Please select a room first.");

                return;
            }

            int roomId = Convert.ToInt32(dgvManagerRooms.CurrentRow.Cells["Id"].Value);

            using RoomForm roomForm = new RoomForm(manager.Id, roomId);

            if (roomForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadManagerRooms();
            }
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            if (currentUser is not Manager manager)
            {
                return;
            }

            if (dgvManagerRooms.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a room first.");

                return;
            }

            int roomId = Convert.ToInt32(
                dgvManagerRooms.CurrentRow
                    .Cells["Id"].Value);

            using AppDbContext db = new AppDbContext();

            Room? room = db.Rooms
                .Include(item => item.Hotel)
                .FirstOrDefault(item =>
                    item.Id == roomId &&
                    item.Hotel!.ManagerId == manager.Id);

            if (room == null)
            {
                MessageBox.Show(
                    "The room could not be found.");

                return;
            }

            bool hasBookingHistory =
                db.Bookings.Any(booking =>
                    booking.RoomId == room.Id);

            if (hasBookingHistory)
            {
                MessageBox.Show(
                    "This room cannot be removed because it " +
                    "has booking history.\n\nSet its status to " +
                    "OutOfService instead.",
                    "Room cannot be removed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int hotelRoomCount = db.Rooms.Count(
                item => item.HotelId == room.HotelId);

            if (hotelRoomCount <= 1)
            {
                MessageBox.Show(
                    "A hotel must contain at least one room. " +
                    "Add another room before removing this one.",
                    "Room cannot be removed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult answer = MessageBox.Show(
                $"Remove room {room.Number} from " +
                $"{room.Hotel!.Name}?",
                "Confirm removal",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            db.Rooms.Remove(room);
            db.SaveChanges();

            MessageBox.Show("The room was removed.");

            LoadManagerRooms();
            LoadManagerHotels();
        }

        private void btnRefreshRooms_Click(object sender, EventArgs e)
        {
            LoadManagerRooms();
        }

        //step 14 booking approvals
        private void LoadPendingBookings()
        {
            if (currentUser is not Manager manager)
            {
                return;
            }

            using AppDbContext db = new AppDbContext();

            var pendingBookings = db.Bookings
                .Include(booking => booking.Guest)
                .Include(booking => booking.Room)
                .ThenInclude(room => room.Hotel)
                .Include(booking => booking.Payment)
                .Where(booking =>
                    booking.Status == BookingStatus.Pending &&
                    booking.Room!.Hotel!.ManagerId == manager.Id)
                .OrderBy(booking => booking.CheckInDate)
                .Select(booking => new
                {
                    Id = booking.Id,
                    Guest = booking.Guest!.FullName,
                    Email = booking.Guest.Email,
                    Hotel = booking.Room!.Hotel!.Name,
                    Room = booking.Room.Number,
                    CheckIn = booking.CheckInDate,
                    CheckOut = booking.CheckOutDate,
                    Nights = booking.NumberOfNights,
                    Total = booking.TotalAmount,
                    Payment = booking.Payment == null
                        ? "Not paid"
                        : booking.Payment.Status.ToString(),
                    Requested = booking.CreatedAt
                })
                .ToList();

            dgvPendingBookings.DataSource =
                pendingBookings;

            if (dgvPendingBookings.Columns["Id"] != null)
            {
                dgvPendingBookings.Columns["Id"].Visible =
                    false;
            }
        }


        private void ProcessBookingDecision(BookingStatus newStatus)
        {
            if (currentUser is not Manager manager)
            {
                return;
            }

            if (dgvPendingBookings.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a booking first.",
                    "No booking selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            int bookingId = Convert.ToInt32(
                dgvPendingBookings.CurrentRow
                    .Cells["Id"].Value);

            string action = newStatus ==
                BookingStatus.Approved
                    ? "approve"
                    : "reject";

            DialogResult answer = MessageBox.Show(
                $"Are you sure you want to {action} " +
                $"booking #{bookingId}?",
                "Confirm decision",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            using AppDbContext db = new AppDbContext();
            using var transaction =
                db.Database.BeginTransaction();

            Booking? booking = db.Bookings
                .Include(item => item.Guest)
                .Include(item => item.Room)
                .ThenInclude(room => room.Hotel)
                .Include(item => item.Payment)
                .FirstOrDefault(item =>
                    item.Id == bookingId &&
                    item.Room!.Hotel!.ManagerId ==
                        manager.Id);

            if (booking == null ||
                booking.Guest == null ||
                booking.Room == null ||
                booking.Room.Hotel == null)
            {
                MessageBox.Show(
                    "The booking could not be found.");

                return;
            }

            if (booking.Status != BookingStatus.Pending)
            {
                MessageBox.Show(
                    "This booking has already been processed.");

                LoadPendingBookings();
                return;
            }

            if (newStatus == BookingStatus.Approved)
            {
                bool conflictingApprovedBooking =
                    db.Bookings.Any(other =>
                        other.Id != booking.Id &&
                        other.RoomId == booking.RoomId &&
                        other.Status ==
                            BookingStatus.Approved &&
                        booking.CheckInDate <
                            other.CheckOutDate &&
                        booking.CheckOutDate >
                            other.CheckInDate);

                if (conflictingApprovedBooking)
                {
                    MessageBox.Show(
                        "This booking cannot be approved because " +
                        "another approved booking overlaps its dates.",
                        "Booking conflict",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            booking.Status = newStatus;

            string notificationTitle;
            string notificationMessage;

            if (newStatus == BookingStatus.Approved)
            {
                notificationTitle =
                    "Booking approved";

                notificationMessage =
                    $"Booking #{booking.Id} at " +
                    $"{booking.Room.Hotel.Name} has been " +
                    $"approved for {booking.CheckInDate:d} " +
                    $"to {booking.CheckOutDate:d}.";
            }
            else
            {
                notificationTitle =
                    "Booking rejected";

                notificationMessage =
                    $"Booking #{booking.Id} at " +
                    $"{booking.Room.Hotel.Name} was rejected. " +
                    "An administrator can now process your refund.";
            }

            Notification notification =
                new Notification
                {
                    UserId = booking.GuestId,
                    Title = notificationTitle,
                    Message = notificationMessage,
                    IsRead = false,
                    CreatedAt = DateTime.Now
                };

            db.Notifications.Add(notification);
            db.SaveChanges();

            transaction.Commit();

            MessageBox.Show(
                newStatus == BookingStatus.Approved
                    ? "The booking was approved."
                    : "The booking was rejected.",
                "Decision saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadPendingBookings();
        }


        private void btnApproveBooking_Click(object sender, EventArgs e)
        {
            ProcessBookingDecision(BookingStatus.Approved);
        }

        private void btnRejectBooking_Click(object sender, EventArgs e)
        {
            ProcessBookingDecision(BookingStatus.Rejected);
        }

        private void btnRefreshPendingBookings_Click(object sender, EventArgs e)
        {
            LoadPendingBookings();
        }

        //14th step

        private void LoadAdminUsers()
        {
            if (currentUser is not Admin)
            {
                return;
            }

            string search = txtUserSearch.Text.Trim().ToLower();

            using AppDbContext db = new AppDbContext();

            var users = db.Users
                .Where(user =>
                    search == "" ||
                    user.FullName.ToLower().Contains(search) ||
                    user.Email.ToLower().Contains(search))
                .OrderBy(user => user.Role)
                .ThenBy(user => user.FullName)
                .Select(user => new
                {
                    Id = user.Id,
                    Name = user.FullName,
                    Email = user.Email,
                    Role = user.Role,
                    Active = user.IsActive,
                    Created = user.CreatedAt,
                    Notifications =
                        user.Notifications.Count
                })
                .ToList();

            dgvUsers.DataSource = users;

            if (dgvUsers.Columns["Id"] != null)
            {
                dgvUsers.Columns["Id"].Visible = false;
            }
        }
        private void btnSearchUsers_Click(object sender, EventArgs e)
        {
            LoadAdminUsers();
        }

        private void btnToggleAccountStatus_Click(object sender, EventArgs e)
        {
            if (currentUser is not Admin admin)
            {
                return;
            }

            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select an account first.",
                    "No account selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["Id"].Value);

            if (userId == admin.Id)
            {
                MessageBox.Show(
                    "You cannot disable your own account.",
                    "Action unavailable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using AppDbContext db = new AppDbContext();

            User? selectedUser =
                db.Users.FirstOrDefault(
                    user => user.Id == userId);

            if (selectedUser == null)
            {
                MessageBox.Show(
                    "The selected account could not be found.");

                return;
            }

            string action = selectedUser.IsActive
                ? "disable"
                : "enable";

            DialogResult answer = MessageBox.Show(
                $"Are you sure you want to {action} " +
                $"{selectedUser.FullName}'s account?",
                "Confirm account change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            selectedUser.IsActive = !selectedUser.IsActive;

            Notification notification = new Notification
            {
                UserId = selectedUser.Id,
                Title = selectedUser.IsActive
                        ? "Account enabled"
                        : "Account disabled",
                Message = selectedUser.IsActive
                        ? "Your account has been enabled by an administrator."
                        : "Your account has been disabled by an administrator.",
                IsRead = false,
                CreatedAt = DateTime.Now
            };

            db.Notifications.Add(notification); db.SaveChanges();

            MessageBox.Show(
                selectedUser.IsActive
                    ? "The account was enabled."
                    : "The account was disabled.",
                "Account updated",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadAdminUsers();
        }

        private void btnRefreshUsers_Click(object sender, EventArgs e)
        {
            txtUserSearch.Clear();
            LoadAdminUsers();
        }

        //16 load refunds

        private void LoadPendingRefunds()
        {
            if (currentUser is not Admin)
            {
                return;
            }

            using AppDbContext db = new AppDbContext();

            var refunds = db.Payments
                .Include(payment => payment.Booking)
                .ThenInclude(booking => booking.Guest)
                .Include(payment => payment.Booking)
                .ThenInclude(booking => booking.Room)
                .ThenInclude(room => room.Hotel)
                .Where(payment =>
                    payment.Status == PaymentStatus.Paid &&
                    (payment.Booking.Status ==
                         BookingStatus.Cancelled ||
                     payment.Booking.Status ==
                         BookingStatus.Rejected))
                .OrderBy(payment =>
                    payment.Booking.CreatedAt)
                .Select(payment => new
                {
                    PaymentId = payment.Id,
                    BookingId = payment.BookingId,
                    Guest =
                        payment.Booking.Guest!.FullName,
                    Email =
                        payment.Booking.Guest.Email,
                    Hotel =
                        payment.Booking.Room!.Hotel!.Name,
                    Room =
                        payment.Booking.Room.Number,
                    BookingStatus =
                        payment.Booking.Status,
                    Amount =
                        payment.Amount,
                    PaidAt =
                        payment.PaidAt,
                    Reference =
                        payment.TransactionReference,
                    Card =
                        "**** " +
                        payment.CardLastFourDigits
                })
                .ToList();

            dgvRefunds.DataSource = refunds;

            if (dgvRefunds.Columns["PaymentId"] != null)
            {
                dgvRefunds.Columns["PaymentId"].Visible = false;
            }
        }
        private void btnProcessRefund_Click(object sender, EventArgs e)
        {
            if (currentUser is not Admin)
            {
                return;
            }

            if (dgvRefunds.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a payment first.",
                    "No payment selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            int paymentId = Convert.ToInt32(
                dgvRefunds.CurrentRow
                    .Cells["PaymentId"].Value);

            using AppDbContext db = new AppDbContext();

            using var transaction = db.Database.BeginTransaction();

            Payment? payment = db.Payments
                .Include(item => item.Booking)
                .ThenInclude(booking => booking.Guest)
                .Include(item => item.Booking)
                .ThenInclude(booking => booking.Room)
                .ThenInclude(room => room.Hotel)
                .FirstOrDefault(item =>
                    item.Id == paymentId);

            if (payment == null ||
                payment.Booking == null ||
                payment.Booking.Guest == null)
            {
                MessageBox.Show(
                    "The payment could not be found.");

                return;
            }

            if (payment.Status != PaymentStatus.Paid)
            {
                MessageBox.Show(
                    "This payment has already been processed.");

                LoadPendingRefunds();
                return;
            }

            bool bookingAllowsRefund =
                payment.Booking.Status ==
                    BookingStatus.Cancelled ||
                payment.Booking.Status ==
                    BookingStatus.Rejected;

            if (!bookingAllowsRefund)
            {
                MessageBox.Show(
                    "Only cancelled or rejected bookings " +
                    "can be refunded.",
                    "Refund unavailable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult answer = MessageBox.Show(
                $"Booking: #{payment.BookingId}\n" +
                $"Guest: {payment.Booking.Guest.FullName}\n" +
                $"Amount: {payment.Amount:C}\n\n" +
                "Process this refund?",
                "Confirm refund",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            payment.Status = PaymentStatus.Refunded;
            payment.RefundedAt = DateTime.Now;

            Notification notification =
                new Notification
                {
                    UserId =
                        payment.Booking.GuestId,
                    Title =
                        "Refund processed",
                    Message =
                        $"A refund of {payment.Amount:C} " +
                        $"for booking #{payment.BookingId} " +
                        "has been processed.",
                    IsRead = false,
                    CreatedAt = DateTime.Now
                };

            db.Notifications.Add(notification);
            db.SaveChanges();

            transaction.Commit();

            MessageBox.Show(
                "The refund was processed successfully.",
                "Refund complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadPendingRefunds();
        }

        private void btnRefreshRefunds_Click(object sender, EventArgs e)
        {
            LoadPendingRefunds();
        }

        //17 and last, the dashboard reports sseries

        private void GenerateAdminReports()
        {
            if (currentUser is not Admin)
            {
                return;
            }

            DateTime from =
                dtpReportFrom.Value.Date;

            DateTime to =
                dtpReportTo.Value.Date;

            if (to < from)
            {
                MessageBox.Show(
                    "The end date must be on or after the start date.",
                    "Invalid report dates",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Using an exclusive upper boundary includes
            // every time during the selected final date.
            DateTime toExclusive =
                to.AddDays(1);

            using AppDbContext db = new AppDbContext();

            int totalUsers =
                db.Users.Count();

            int totalHotels =
                db.Hotels.Count();

            int totalRooms =
                db.Rooms.Count();

            int totalBookings = db.Bookings.Count(
                booking =>
                    booking.CreatedAt >= from &&
                    booking.CreatedAt < toExclusive);

            /*
             * SQLite has some limitations when calculating
             * decimal values directly. We load the relevant
             * payments first and calculate the totals in C#.
             */
            List<Payment> payments = db.Payments
                .Where(payment =>
                    payment.PaidAt >= from &&
                    payment.PaidAt < toExclusive)
                .ToList();

            decimal grossPayments =
                payments.Sum(payment => payment.Amount);

            decimal refundedAmount = payments
                .Where(payment =>
                    payment.Status ==
                        PaymentStatus.Refunded)
                .Sum(payment => payment.Amount);

            decimal netRevenue =
                grossPayments - refundedAmount;

            lblTotalUsersReport.Text =
                $"Users: {totalUsers}";

            lblTotalHotelsReport.Text =
                $"Hotels: {totalHotels}";

            lblTotalRoomsReport.Text =
                $"Rooms: {totalRooms}";

            lblTotalBookingsReport.Text =
                $"Bookings created: {totalBookings}";

            lblGrossRevenueReport.Text =
                $"Gross payments: {grossPayments:C}";

            lblRefundedReport.Text =
                $"Refunded: {refundedAmount:C}";

            lblNetRevenueReport.Text =
                $"Net revenue: {netRevenue:C}";

            lblReportGeneratedAt.Text =
                $"Generated: {DateTime.Now:g}";

            LoadBookingStatusReport(
                db,
                from,
                toExclusive);

            LoadHotelPerformanceReport(
                db,
                from,
                toExclusive);
        }

        private void LoadBookingStatusReport(AppDbContext db, DateTime from, DateTime toExclusive)
        {
            List<Booking> bookings = db.Bookings
                .Where(booking =>
                    booking.CreatedAt >= from &&
                    booking.CreatedAt < toExclusive)
                .ToList();

            var report = Enum
                .GetValues<BookingStatus>()
                .Select(status => new
                {
                    Status = status.ToString(),
                    Count = bookings.Count(
                        booking =>
                            booking.Status == status),
                    TotalValue = bookings
                        .Where(booking =>
                            booking.Status == status)
                        .Sum(booking =>
                            booking.TotalAmount)
                })
                .ToList();

            dgvBookingStatusReport.DataSource =
                report;
        }

        private void LoadHotelPerformanceReport(AppDbContext db, DateTime from, DateTime toExclusive)
        {
            List<Hotel> hotels = db.Hotels
                .Include(hotel => hotel.Rooms)
                .ThenInclude(room => room.Bookings)
                .ThenInclude(booking => booking.Payment)
                .ToList();

            var report = hotels
                .Select(hotel =>
                {
                    List<Booking> bookings =
                        hotel.Rooms
                            .SelectMany(room =>
                                room.Bookings)
                            .Where(booking =>
                                booking.CreatedAt >= from &&
                                booking.CreatedAt <
                                    toExclusive)
                            .ToList();

                    int approvedBookings =
                        bookings.Count(booking =>
                            booking.Status ==
                                BookingStatus.Approved ||
                            booking.Status ==
                                BookingStatus.Completed);

                    decimal paidRevenue = bookings
                        .Where(booking =>
                            booking.Payment != null &&
                            booking.Payment.Status ==
                                PaymentStatus.Paid)
                        .Sum(booking =>
                            booking.Payment!.Amount);

                    decimal refunds = bookings
                        .Where(booking =>
                            booking.Payment != null &&
                            booking.Payment.Status ==
                                PaymentStatus.Refunded)
                        .Sum(booking =>
                            booking.Payment!.Amount);

                    return new
                    {
                        Hotel = hotel.Name,
                        Rooms = hotel.Rooms.Count,
                        Bookings = bookings.Count,
                        Approved = approvedBookings,
                        Cancelled = bookings.Count(
                            booking =>
                                booking.Status ==
                                    BookingStatus.Cancelled),
                        Rejected = bookings.Count(
                            booking =>
                                booking.Status ==
                                    BookingStatus.Rejected),
                        NetRevenue =
                            paidRevenue - refunds
                    };
                })
                .OrderByDescending(item =>
                    item.NetRevenue)
                .ToList();

            dgvHotelReport.DataSource = report;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            GenerateAdminReports();
        }
    }
}
