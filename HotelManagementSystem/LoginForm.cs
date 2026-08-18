using System.Drawing;
using HotelManagementSystem.Models;
using HotelManagementSystem.Data;
using HotelManagementSystem.Services;

namespace HotelManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim().ToLower();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Please enter your email and password.";
                return;
            }

            using AppDbContext db = new AppDbContext();

            User? loggedInUser = db.Users.SingleOrDefault(user => user.Email == email && user.IsActive);

            if (loggedInUser == null)
            {
                ShowLoginError();
                return;
            }

            bool passwordIsCorrect = PasswordHasher.VerifyPassword(password, loggedInUser.PasswordHash);

            if (!passwordIsCorrect)
            {
                ShowLoginError();
                return;
            }

            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "Login successful!";

            DashboardForm dashboard = new DashboardForm(loggedInUser);

            Hide();
            dashboard.ShowDialog();
            Show();

            txtPassword.Clear();
            lblMessage.Text = "";

        }

        private void ShowLoginError()
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = "Incorrect email or password";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using RegisterForm registerForm = new RegisterForm();

            DialogResult result = registerForm.ShowDialog(this);

            if(result == DialogResult.OK)
            {
                txtEmail.Text = registerForm.RegisteredEmail;

                txtPassword.Clear();
                txtPassword.Focus();

                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Account created. Enter your password to log in.";

            }

        }
    }

}