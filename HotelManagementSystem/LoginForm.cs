using System.Drawing;
using HotelManagementSystem.Models;
using HotelManagementSystem.Data;
using HotelManagementSystem.Services;
using HotelManagementSystem.UI;

namespace HotelManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            AppTheme.Apply(this);
            ImproveLoginLayout();

        }

        private void ImproveLoginLayout()
        {
            SuspendLayout();

            Text = "Hotel Management";
            ClientSize = new Size(484, 490);
            BackColor = AppTheme.Background;

            const int formWidth = 484;
            const int controlWidth = 300;
            const int left = (formWidth - controlWidth) / 2;

            // Título
            lblTitle.Text = "Hotel Management";
            lblTitle.Font = new Font(
                "Segoe UI Semibold",
                20F,
                FontStyle.Regular);

            lblTitle.AutoSize = true;
            lblTitle.Top = 42;
            lblTitle.Left = (formWidth - lblTitle.Width) / 2;

            // Subtítulo
            lblSubtitle.Text = "Welcome back. Sign in to continue.";
            lblSubtitle.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular);

            lblSubtitle.ForeColor = AppTheme.MutedText;
            lblSubtitle.AutoSize = true;
            lblSubtitle.Top = 86;
            lblSubtitle.Left =
                (formWidth - lblSubtitle.Width) / 2;

            // Email
            lblEmail.Text = "Email address";
            lblEmail.Left = left;
            lblEmail.Top = 135;

            txtEmail.Left = left;
            txtEmail.Top = 159;
            txtEmail.Width = controlWidth;
            txtEmail.AutoSize = true;

            // Contraseña
            lblPassword.Text = "Password";
            lblPassword.Left = left;
            lblPassword.Top = 211;

            txtPassword.Left = left;
            txtPassword.Top = 235;
            txtPassword.Width = controlWidth;
            txtPassword.AutoSize = true;
            txtPassword.UseSystemPasswordChar = true;

            // Mostrar contraseña
            CheckBox chkShowPassword = new()
            {
                Name = "chkShowPassword",
                Text = "Show password",
                AutoSize = true,
                Left = left,
                Top = 275,
                Font = new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Regular),
                ForeColor = AppTheme.MutedText,
                BackColor = AppTheme.Background,
                Cursor = Cursors.Hand
            };

            chkShowPassword.CheckedChanged += (_, _) =>
            {
                txtPassword.UseSystemPasswordChar =
                    !chkShowPassword.Checked;

                txtPassword.Focus();
                txtPassword.SelectionStart =
                    txtPassword.Text.Length;
            };

            Controls.Add(chkShowPassword);

            // Mensaje de validación
            lblMessage.Left = left;
            lblMessage.Top = 307;
            lblMessage.Width = controlWidth;
            lblMessage.Height = 24;
            lblMessage.ForeColor = Color.IndianRed;

            // Iniciar sesión
            btnLogin.Text = "Sign in";
            btnLogin.Left = left;
            btnLogin.Top = 340;
            btnLogin.Width = controlWidth;
            btnLogin.Height = 40;

            // Crear una cuenta
            btnRegister.Text = "Create an account";
            btnRegister.Left = left;
            btnRegister.Top = 397;
            btnRegister.Width = controlWidth;
            btnRegister.Height = 40;

            // Permite iniciar sesión pulsando Enter
            AcceptButton = btnLogin;

            ResumeLayout(false);
            PerformLayout();
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