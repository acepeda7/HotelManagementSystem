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
    public partial class HotelForm : Form
    {
        private int managerId;
        private int? hotelId;
        public HotelForm()
        {
            InitializeComponent();
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
