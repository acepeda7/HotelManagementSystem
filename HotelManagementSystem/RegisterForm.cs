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
using HotelManagementSystem.UI;

namespace HotelManagementSystem
{
    public partial class RegisterForm : Form
    {
        public string RegisteredEmail { get; set; } = "";
        public RegisterForm()
        {
            InitializeComponent();

            AppTheme.Apply(this);
            ImproveRegisterLayout();
        }

        private void ImproveRegisterLayout()
        {
            SuspendLayout();

            Text = "Create Account";
            ClientSize = new Size(484, 570);
            BackColor = AppTheme.Background;

            const int formWidth = 484;
            const int controlWidth = 300;
            const int left = (formWidth - controlWidth) / 2;

            // Título
            lblTitle.Text = "Create your account";
            lblTitle.Font = new Font(
                "Segoe UI Semibold",
                20F,
                FontStyle.Regular);

            lblTitle.AutoSize = true;
            lblTitle.Top = 38;
            lblTitle.Left =
                (formWidth - lblTitle.Width) / 2;

            // Nombre completo
            lblFullName.Text = "Full name";
            lblFullName.Left = left;
            lblFullName.Top = 100;

            txtFullName.Left = left;
            txtFullName.Top = 124;
            txtFullName.Width = controlWidth;
            txtFullName.AutoSize = true;

            // Email
            lblEmail.Text = "Email address";
            lblEmail.Left = left;
            lblEmail.Top = 172;

            txtEmail.Left = left;
            txtEmail.Top = 196;
            txtEmail.Width = controlWidth;
            txtEmail.AutoSize = true;

            // Contraseña
            lblPassword.Text = "Password";
            lblPassword.Left = left;
            lblPassword.Top = 244;

            txtPassword.Left = left;
            txtPassword.Top = 268;
            txtPassword.Width = controlWidth;
            txtPassword.AutoSize = true;
            txtPassword.UseSystemPasswordChar = true;

            // Confirmar contraseña
            lblConfirmPassword.Text = "Confirm password";
            lblConfirmPassword.Left = left;
            lblConfirmPassword.Top = 316;

            txtConfirmPassword.Left = left;
            txtConfirmPassword.Top = 340;
            txtConfirmPassword.Width = controlWidth;
            txtConfirmPassword.AutoSize = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            // Mostrar ambas contraseñas
            CheckBox chkShowPasswords = new()
            {
                Name = "chkShowPasswords",
                Text = "Show passwords",
                AutoSize = true,
                Left = left,
                Top = 380,
                Font = new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Regular),
                ForeColor = AppTheme.MutedText,
                BackColor = AppTheme.Background,
                Cursor = Cursors.Hand
            };

            chkShowPasswords.CheckedChanged += (_, _) =>
            {
                bool hidePasswords = !chkShowPasswords.Checked;

                txtPassword.UseSystemPasswordChar =
                    hidePasswords;

                txtConfirmPassword.UseSystemPasswordChar =
                    hidePasswords;
            };

            Controls.Add(chkShowPasswords);

            // Mensaje de validación
            lblMessage.AutoSize = false;
            lblMessage.Left = left;
            lblMessage.Top = 410;
            lblMessage.Width = controlWidth;
            lblMessage.Height = 24;
            lblMessage.ForeColor = Color.IndianRed;
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            // Botón principal
            btnCreateAccount.Text = "Create account";
            btnCreateAccount.Left = left;
            btnCreateAccount.Top = 445;
            btnCreateAccount.Width = controlWidth;
            btnCreateAccount.Height = 40;
            btnCreateAccount.BackColor = AppTheme.Primary;
            btnCreateAccount.ForeColor = Color.White;
            btnCreateAccount.FlatStyle = FlatStyle.Flat;
            btnCreateAccount.FlatAppearance.BorderSize = 0;

            // Botón secundario
            btnCancel.Text = "Back to sign in";
            btnCancel.Left = left;
            btnCancel.Top = 502;
            btnCancel.Width = controlWidth;
            btnCancel.Height = 40;
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = AppTheme.Primary;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor =
                AppTheme.Primary;
            btnCancel.FlatAppearance.BorderSize = 1;

            // Atajos del teclado
            AcceptButton = btnCreateAccount;
            CancelButton = btnCancel;

            ResumeLayout(false);
            PerformLayout();
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
