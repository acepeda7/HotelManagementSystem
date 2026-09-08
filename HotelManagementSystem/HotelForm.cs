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
    public partial class HotelForm : Form
    {
        private int managerId;
        private int? hotelId;
        public HotelForm()
        {
            InitializeComponent();

            AppTheme.Apply(this);
            ImproveHotelLayout();
        }

        private void ImproveHotelLayout()
        {
            SuspendLayout();

            Text = "Hotel Profile";
            ClientSize = new Size(560, 560);
            BackColor = AppTheme.Background;

            const int labelLeft = 65;
            const int fieldLeft = 205;
            const int fieldWidth = 290;

            // Título
            Label lblPageTitle = new()
            {
                Name = "lblPageTitle",
                Text = "Hotel details",
                AutoSize = true,
                Font = new Font(
                    "Segoe UI Semibold",
                    20F,
                    FontStyle.Regular),
                ForeColor = AppTheme.Text,
                BackColor = AppTheme.Background,
                Top = 35
            };

            lblPageTitle.Left =
                (ClientSize.Width - lblPageTitle.Width) / 2;

            Controls.Add(lblPageTitle);

            // Nombre
            label1.Text = "Hotel name";
            label1.Left = labelLeft;
            label1.Top = 115;
            label1.ForeColor = AppTheme.MutedText;

            txtHotelName.Left = fieldLeft;
            txtHotelName.Top = 110;
            txtHotelName.Width = fieldWidth;
            txtHotelName.AutoSize = true;

            // Dirección
            label2.Text = "Address";
            label2.Left = labelLeft;
            label2.Top = 175;
            label2.ForeColor = AppTheme.MutedText;

            txtHotelAddress.Left = fieldLeft;
            txtHotelAddress.Top = 170;
            txtHotelAddress.Width = fieldWidth;
            txtHotelAddress.AutoSize = true;

            // Clasificación
            label3.Text = "Star rating";
            label3.Left = labelLeft;
            label3.Top = 235;
            label3.ForeColor = AppTheme.MutedText;

            nudStarRating.Left = fieldLeft;
            nudStarRating.Top = 230;
            nudStarRating.Width = fieldWidth;

            // Descripción
            label4.Text = "Description";
            label4.Left = labelLeft;
            label4.Top = 295;
            label4.ForeColor = AppTheme.MutedText;

            txtHotelDescription.Left = fieldLeft;
            txtHotelDescription.Top = 290;
            txtHotelDescription.Width = fieldWidth;
            txtHotelDescription.Height = 85;
            txtHotelDescription.Multiline = true;
            txtHotelDescription.ScrollBars =
                ScrollBars.Vertical;

            // Mensaje
            lblMessage.AutoSize = false;
            lblMessage.Left = labelLeft;
            lblMessage.Top = 392;
            lblMessage.Width = 430;
            lblMessage.Height = 28;
            lblMessage.ForeColor = Color.IndianRed;
            lblMessage.TextAlign =
                ContentAlignment.MiddleLeft;

            // Guardar
            btnSaveHotel.Text = "Save hotel";
            btnSaveHotel.Left = 80;
            btnSaveHotel.Top = 450;
            btnSaveHotel.Width = 190;
            btnSaveHotel.Height = 40;
            btnSaveHotel.BackColor = AppTheme.Primary;
            btnSaveHotel.ForeColor = Color.White;
            btnSaveHotel.FlatStyle = FlatStyle.Flat;
            btnSaveHotel.FlatAppearance.BorderSize = 0;

            // Cancelar
            btnCancel.Text = "Cancel";
            btnCancel.Left = 290;
            btnCancel.Top = 450;
            btnCancel.Width = 190;
            btnCancel.Height = 40;
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = AppTheme.Primary;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor =
                AppTheme.Primary;
            btnCancel.FlatAppearance.BorderSize = 1;

            AcceptButton = btnSaveHotel;
            CancelButton = btnCancel;

            ResumeLayout(false);
            PerformLayout();
        }
        public HotelForm(int managerId, int? hotelId = null) : this()
        {
            this.managerId = managerId;
            this.hotelId = hotelId;

            if (hotelId.HasValue)
            {
                Text = "Edit Hotel";
                LoadHotel();
            }
            else
            {
                Text = "Add Hotel";
            }
        }
        private void LoadHotel()
        {
            using AppDbContext db = new AppDbContext();

            Hotel? hotel = db.Hotels.FirstOrDefault(item => item.Id == hotelId && item.ManagerId == managerId);

            if (hotel == null)
            {
                MessageBox.Show("The hotel could not be found.");

                Close();
                return;
            }

            txtHotelName.Text = hotel.Name;
            txtHotelAddress.Text = hotel.Address;
            txtHotelDescription.Text = hotel.Description;

            nudStarRating.Value = hotel.StarRating;
        }

        private void btnSaveHotel_Click(object sender, EventArgs e)
        {
            string name = txtHotelName.Text.Trim();

            string address = txtHotelAddress.Text.Trim();

            string description = txtHotelDescription.Text.Trim();

            int starRating = Convert.ToInt32(nudStarRating.Value);

            if (string.IsNullOrWhiteSpace(name))
            {
                ShowError("Enter the hotel name.");
                txtHotelName.Focus();
                return;
            }

            if (name.Length < 2)
            {
                ShowError("The hotel name must contain at least 2 characters.");

                txtHotelName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                ShowError("Enter the hotel address.");
                txtHotelAddress.Focus();
                return;
            }

            using AppDbContext db = new AppDbContext();

            bool duplicateName = db.Hotels.Any(
                hotel =>
                    hotel.Name.ToLower() ==
                        name.ToLower() &&
                    hotel.Id != hotelId);

            if (duplicateName)
            {
                ShowError("A hotel with this name already exists.");

                return;
            }

            if (hotelId.HasValue)
            {
                Hotel? hotel = db.Hotels.FirstOrDefault(item => item.Id == hotelId.Value && item.ManagerId == managerId);

                if (hotel == null)
                {
                    ShowError("The hotel could not be found.");

                    return;
                }

                hotel.Name = name;
                hotel.Address = address;
                hotel.Description = description;
                hotel.StarRating = starRating;
            }
            else
            {
                Hotel hotel = new Hotel
                {
                    Name = name,
                    Address = address,
                    Description = description,
                    StarRating = starRating,
                    ManagerId = managerId
                };

                db.Hotels.Add(hotel);
            }

            try
            {
                db.SaveChanges();

                MessageBox.Show(
                    hotelId.HasValue
                        ? "The hotel was updated."
                        : "The hotel was created. Add its first room next.",
                    "Hotel saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exception)
            {
                ShowError("The hotel could not be saved: " +exception.Message);
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
