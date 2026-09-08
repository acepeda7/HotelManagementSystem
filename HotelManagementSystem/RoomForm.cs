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
using HotelManagementSystem.UI;

namespace HotelManagementSystem
{
    public partial class RoomForm : Form
    {
        private int managerId;
        private int? roomId;
        public RoomForm()
        {
            InitializeComponent();

            AppTheme.Apply(this);
            ImproveRoomLayout();
        }

        private void ImproveRoomLayout()
        {
            SuspendLayout();

            Text = "Room Details";
            ClientSize = new Size(580, 680);
            BackColor = AppTheme.Background;

            const int labelLeft = 65;
            const int fieldLeft = 220;
            const int fieldWidth = 295;

            // Título
            Label lblPageTitle = new()
            {
                Name = "lblPageTitle",
                Text = "Room details",
                AutoSize = true,
                Font = new Font(
                    "Segoe UI Semibold",
                    20F,
                    FontStyle.Regular),
                ForeColor = AppTheme.Text,
                BackColor = AppTheme.Background,
                Top = 32
            };

            lblPageTitle.Left =
                (ClientSize.Width - lblPageTitle.Width) / 2;

            Controls.Add(lblPageTitle);

            // Hotel
            PositionRoomLabel(
                label1,
                "Hotel",
                labelLeft,
                100);

            cmbHotel.Left = fieldLeft;
            cmbHotel.Top = 95;
            cmbHotel.Width = fieldWidth;
            cmbHotel.DropDownStyle =
                ComboBoxStyle.DropDownList;

            // Número de habitación
            PositionRoomLabel(
                label2,
                "Room number",
                labelLeft,
                155);

            txtRoomNumber.Left = fieldLeft;
            txtRoomNumber.Top = 150;
            txtRoomNumber.Width = fieldWidth;
            txtRoomNumber.AutoSize = true;

            // Tipo
            PositionRoomLabel(
                label3,
                "Room type",
                labelLeft,
                210);

            txtRoomType.Left = fieldLeft;
            txtRoomType.Top = 205;
            txtRoomType.Width = fieldWidth;
            txtRoomType.AutoSize = true;

            // Capacidad
            PositionRoomLabel(
                label4,
                "Capacity",
                labelLeft,
                265);

            nudCapacity.Left = fieldLeft;
            nudCapacity.Top = 260;
            nudCapacity.Width = fieldWidth;

            // Precio
            PositionRoomLabel(
                label5,
                "Price per night",
                labelLeft,
                320);

            nudPricePerNight.Left = fieldLeft;
            nudPricePerNight.Top = 315;
            nudPricePerNight.Width = fieldWidth;
            nudPricePerNight.DecimalPlaces = 2;
            nudPricePerNight.ThousandsSeparator = true;

            // Estado
            PositionRoomLabel(
                label6,
                "Status",
                labelLeft,
                375);

            cmbRoomStatus.Left = fieldLeft;
            cmbRoomStatus.Top = 370;
            cmbRoomStatus.Width = fieldWidth;
            cmbRoomStatus.DropDownStyle =
                ComboBoxStyle.DropDownList;

            // Descripción
            PositionRoomLabel(
                label7,
                "Description",
                labelLeft,
                430);

            txtRoomDescription.Left = fieldLeft;
            txtRoomDescription.Top = 425;
            txtRoomDescription.Width = fieldWidth;
            txtRoomDescription.Height = 90;
            txtRoomDescription.Multiline = true;
            txtRoomDescription.ScrollBars =
                ScrollBars.Vertical;

            // Mensaje
            lblMessage.AutoSize = false;
            lblMessage.Left = labelLeft;
            lblMessage.Top = 530;
            lblMessage.Width = 450;
            lblMessage.Height = 28;
            lblMessage.ForeColor = Color.IndianRed;
            lblMessage.TextAlign =
                ContentAlignment.MiddleLeft;

            // Guardar
            btnSaveRoom.Text = "Save room";
            btnSaveRoom.Left = 90;
            btnSaveRoom.Top = 585;
            btnSaveRoom.Width = 190;
            btnSaveRoom.Height = 40;
            btnSaveRoom.BackColor = AppTheme.Primary;
            btnSaveRoom.ForeColor = Color.White;
            btnSaveRoom.FlatStyle = FlatStyle.Flat;
            btnSaveRoom.FlatAppearance.BorderSize = 0;

            // Cancelar
            btnCancel.Text = "Cancel";
            btnCancel.Left = 300;
            btnCancel.Top = 585;
            btnCancel.Width = 190;
            btnCancel.Height = 40;
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = AppTheme.Primary;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor =
                AppTheme.Primary;
            btnCancel.FlatAppearance.BorderSize = 1;

            AcceptButton = btnSaveRoom;
            CancelButton = btnCancel;

            ResumeLayout(false);
            PerformLayout();
        }

        private static void PositionRoomLabel(
            Label label,
            string text,
            int left,
            int top)
        {
            label.Text = text;
            label.Left = left;
            label.Top = top;
            label.ForeColor = AppTheme.MutedText;
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
