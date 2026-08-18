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

namespace HotelManagementSystem
{
    public partial class RoomForm : Form
    {
        private int managerId;
        private int? roomId;
        public RoomForm()
        {
            InitializeComponent();
        }
        public RoomForm(
        int managerId,
        int? roomId = null) : this()
        {
            this.managerId = managerId;
            this.roomId = roomId;

            LoadHotels();
            LoadRoomStatuses();

            if (roomId.HasValue)
            {
                Text = "Edit Room";
                
                LoadRoom();

                // A room with booking history should not
                // be transferred to another hotel.
                cmbHotel.Enabled = false;
            }
            else
            {
                Text = "Add Room";
            }
        }

        private void LoadHotels()
        {
            using AppDbContext db = new AppDbContext();

            var hotels = db.Hotels
                .Where(hotel =>
                    hotel.ManagerId == managerId)
                .OrderBy(hotel => hotel.Name)
                .Select(hotel => new
                {
                    hotel.Id,
                    hotel.Name
                })
                .ToList();

            cmbHotel.DataSource = hotels;
            cmbHotel.DisplayMember = "Name";
            cmbHotel.ValueMember = "Id";
        }

        private void LoadRoomStatuses()
        {
            cmbRoomStatus.DataSource = Enum.GetValues(typeof(RoomStatus));
        }

        private void LoadRoom()
        {
            using AppDbContext db = new AppDbContext();

            Room? room = db.Rooms
                .FirstOrDefault(item =>
                    item.Id == roomId &&
                    item.Hotel != null &&
                    item.Hotel.ManagerId == managerId);

            if (room == null)
            {
                MessageBox.Show(
                    "The room could not be found.");

                Close();
                return;
            }

            cmbHotel.SelectedValue = room.HotelId;
            txtRoomNumber.Text = room.Number;
            txtRoomType.Text = room.Type;
            nudCapacity.Value = room.Capacity;
            nudPricePerNight.Value = room.PricePerNight;
            cmbRoomStatus.SelectedItem =  room.Status;
            txtRoomDescription.Text = room.Description;
        }
        private void btnSaveRoom_Click(object sender, EventArgs e)
        {
            if (cmbHotel.SelectedValue == null)
            {
                ShowError("Create or select a hotel first.");

                return;
            }

            int hotelId = Convert.ToInt32(cmbHotel.SelectedValue);

            string roomNumber = txtRoomNumber.Text.Trim();

            string roomType = txtRoomType.Text.Trim();

            int capacity = Convert.ToInt32(nudCapacity.Value);

            decimal price = nudPricePerNight.Value;

            RoomStatus status = (RoomStatus)cmbRoomStatus.SelectedItem!;

            string description = txtRoomDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(roomNumber))
            {
                ShowError("Enter the room number.");
                txtRoomNumber.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(roomType))
            {
                ShowError("Enter the room type.");
                txtRoomType.Focus();
                return;
            }

            using AppDbContext db = new AppDbContext();

            bool ownsHotel = db.Hotels.Any(hotel => hotel.Id == hotelId && hotel.ManagerId == managerId);

            if (!ownsHotel)
            {
                ShowError("The selected hotel is invalid.");

                return;
            }

            bool duplicateNumber = db.Rooms.Any(
                room =>
                    room.HotelId == hotelId &&
                    room.Number.ToLower() ==
                        roomNumber.ToLower() &&
                    room.Id != roomId);

            if (duplicateNumber)
            {
                ShowError(
                    "This hotel already has a room " +
                    "with that number.");

                return;
            }

            if (roomId.HasValue)
            {
                Room? room = db.Rooms.FirstOrDefault(
                    item =>
                        item.Id == roomId.Value &&
                        item.Hotel != null &&
                        item.Hotel.ManagerId ==
                            managerId);

                if (room == null)
                {
                    ShowError("The room could not be found.");

                    return;
                }

                room.Number = roomNumber;
                room.Type = roomType;
                room.Capacity = capacity;
                room.PricePerNight = price;
                room.Status = status;
                room.Description = description;
            }
            else
            {
                Room room = new Room
                {
                    HotelId = hotelId,
                    Number = roomNumber,
                    Type = roomType,
                    Capacity = capacity,
                    PricePerNight = price,
                    Status = status,
                    Description = description
                };

                db.Rooms.Add(room);
            }

            try
            {
                db.SaveChanges();

                MessageBox.Show(
                    roomId.HasValue
                        ? "The room was updated."
                        : "The room was added.",
                    "Room saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exception)
            {
                ShowError("The room could not be saved: " + exception.Message);
            }
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
