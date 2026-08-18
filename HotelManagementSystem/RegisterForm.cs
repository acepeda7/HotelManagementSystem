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
using HotelManagementSystem.Services;

namespace HotelManagementSystem
{
    public partial class RegisterForm : Form
    {
        public string RegisteredEmail { get; set; } = "";
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            ClearMessage();

            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim().ToLower();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (!ValidateRegistration(
                    fullName,
                    email,
                    password,
                    confirmPassword))
            {
                return;
            }

            using AppDbContext db = new AppDbContext();

            bool emailAlreadyExists = db.Users.Any(user => user.Email == email);

            if (emailAlreadyExists)
            {
                ShowError("An account with this email already exists.");

                return;
            }

            Guest guest = new Guest
            {
                FullName = fullName,
                Email = email,
                PasswordHash = PasswordHasher.HashPassword(password),
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            try
            {
                db.Guests.Add(guest);
                db.SaveChanges();

                RegisteredEmail = guest.Email;

                MessageBox.Show(
                    "Your guest account was created successfully.",
                    "Registration successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch ( Exception exception)
            {
                ShowError($"The account could no be created: " + exception.Message);
            }

        }

        private bool ValidateRegistration(string fullName, string email, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                ShowError("Please enter your full name.");
                txtFullName.Focus();
                return false;
            }
            if (fullName.Length < 2)
            {
                ShowError("The full name must contain at least 2 characters.");
                txtFullName.Focus();
                return false;
            }
            if (!IsValidEmail(email))
            {
                ShowError("Please enter a valid email address.");
                txtEmail.Focus();
                return false;
            }

            if (password.Length < 8)
            {
                ShowError(
                    "The password must contain at least 8 characters.");

                txtPassword.Focus();
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                ShowError(
                    "The password must contain an uppercase letter.");

                txtPassword.Focus();
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                ShowError(
                    "The password must contain a lowercase letter.");

                txtPassword.Focus();
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                ShowError(
                    "The password must contain a number.");

                txtPassword.Focus();
                return false;
            }

            if (password != confirmPassword)
            {
                ShowError("The passwords do not match.");
                txtConfirmPassword.Focus();
                return false;
            }

            return true;

        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                System.Net.Mail.MailAddress address = new System.Net.Mail.MailAddress(email);

                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ShowError (string message)
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = message;
        }

        private void ClearMessage()
        {
            lblMessage.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
