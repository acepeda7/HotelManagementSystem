namespace HotelManagementSystem
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            btnLogout = new Button();
            lblRole = new Label();
            lblWelcome = new Label();
            tabDashboard = new TabControl();
            tabGuest = new TabPage();
            btnBookRoom = new Button();
            btnViewRoomDetails = new Button();
            dgvRooms = new DataGridView();
            btnSearchRooms = new Button();
            dtpCheckOut = new DateTimePicker();
            dtpCheckIn = new DateTimePicker();
            lblCheckOut = new Label();
            lblCheckIn = new Label();
            txtHotelSearch = new TextBox();
            lblHotelSearch = new Label();
            label1 = new Label();
            tabManager = new TabPage();
            tabManagerTools = new TabControl();
            tabManageHotels = new TabPage();
            btnRefreshHotels = new Button();
            btnEditHotel = new Button();
            btnAddHotel = new Button();
            dgvManagerHotels = new DataGridView();
            tabManageRooms = new TabPage();
            btnAddRoom = new Button();
            btnRefreshRooms = new Button();
            btnRemoveRoom = new Button();
            btnEditRoom = new Button();
            dgvManagerRooms = new DataGridView();
            tabBookingApprovals = new TabPage();
            btnRefreshPendingBookings = new Button();
            btnRejectBooking = new Button();
            btnApproveBooking = new Button();
            dgvPendingBookings = new DataGridView();
            label2 = new Label();
            tabAdmin = new TabPage();
            tabAdminTools = new TabControl();
            tabManageAccounts = new TabPage();
            btnRefreshUsers = new Button();
            btnToggleAccountStatus = new Button();
            btnSearchUsers = new Button();
            txtUserSearch = new TextBox();
            lblUserSearch = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            dgvUsers = new DataGridView();
            tabManageRefunds = new TabPage();
            btnRefreshRefunds = new Button();
            btnProcessRefund = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            dgvRefunds = new DataGridView();
            tabReports = new TabPage();
            label7 = new Label();
            label6 = new Label();
            dgvHotelReport = new DataGridView();
            lblReportGeneratedAt = new Label();
            lblNetRevenueReport = new Label();
            lblRefundedReport = new Label();
            lblGrossRevenueReport = new Label();
            lblTotalBookingsReport = new Label();
            lblTotalRoomsReport = new Label();
            lblTotalHotelsReport = new Label();
            lblTotalUsersReport = new Label();
            btnGenerateReport = new Button();
            dtpReportTo = new DateTimePicker();
            lblReportTo = new Label();
            dtpReportFrom = new DateTimePicker();
            lblReportFrom = new Label();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            dgvBookingStatusReport = new DataGridView();
            label3 = new Label();
            tabMyBookings = new TabPage();
            btnModifyBooking = new Button();
            btnCancelBooking = new Button();
            btnRefreshBookings = new Button();
            label4 = new Label();
            dgvMyBookings = new DataGridView();
            tabNotifications = new TabPage();
            btnMarkNotificationRead = new Button();
            btnRefreshNotifications = new Button();
            label5 = new Label();
            dgvNotifications = new DataGridView();
            pnlHeader.SuspendLayout();
            tabDashboard.SuspendLayout();
            tabGuest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            tabManager.SuspendLayout();
            tabManagerTools.SuspendLayout();
            tabManageHotels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManagerHotels).BeginInit();
            tabManageRooms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManagerRooms).BeginInit();
            tabBookingApprovals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPendingBookings).BeginInit();
            tabAdmin.SuspendLayout();
            tabAdminTools.SuspendLayout();
            tabManageAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            tabManageRefunds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRefunds).BeginInit();
            tabReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHotelReport).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBookingStatusReport).BeginInit();
            tabMyBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMyBookings).BeginInit();
            tabNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotifications).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.SteelBlue;
            pnlHeader.Controls.Add(btnLogout);
            pnlHeader.Controls.Add(lblRole);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1084, 60);
            pnlHeader.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.Location = new Point(973, 22);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(542, 26);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(30, 15);
            lblRole.TabIndex = 1;
            lblRole.Text = "Role";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(12, 26);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(57, 15);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            // 
            // tabDashboard
            // 
            tabDashboard.Controls.Add(tabGuest);
            tabDashboard.Controls.Add(tabManager);
            tabDashboard.Controls.Add(tabAdmin);
            tabDashboard.Controls.Add(tabMyBookings);
            tabDashboard.Controls.Add(tabNotifications);
            tabDashboard.Dock = DockStyle.Fill;
            tabDashboard.Location = new Point(0, 60);
            tabDashboard.Name = "tabDashboard";
            tabDashboard.SelectedIndex = 0;
            tabDashboard.Size = new Size(1084, 601);
            tabDashboard.TabIndex = 1;
            // 
            // tabGuest
            // 
            tabGuest.Controls.Add(btnBookRoom);
            tabGuest.Controls.Add(btnViewRoomDetails);
            tabGuest.Controls.Add(dgvRooms);
            tabGuest.Controls.Add(btnSearchRooms);
            tabGuest.Controls.Add(dtpCheckOut);
            tabGuest.Controls.Add(dtpCheckIn);
            tabGuest.Controls.Add(lblCheckOut);
            tabGuest.Controls.Add(lblCheckIn);
            tabGuest.Controls.Add(txtHotelSearch);
            tabGuest.Controls.Add(lblHotelSearch);
            tabGuest.Controls.Add(label1);
            tabGuest.Location = new Point(4, 24);
            tabGuest.Name = "tabGuest";
            tabGuest.Padding = new Padding(3);
            tabGuest.Size = new Size(1076, 573);
            tabGuest.TabIndex = 0;
            tabGuest.Text = "Find a Room";
            tabGuest.UseVisualStyleBackColor = true;
            // 
            // btnBookRoom
            // 
            btnBookRoom.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBookRoom.Location = new Point(556, 520);
            btnBookRoom.Name = "btnBookRoom";
            btnBookRoom.Size = new Size(197, 23);
            btnBookRoom.TabIndex = 14;
            btnBookRoom.Text = "Book Selected Room";
            btnBookRoom.UseVisualStyleBackColor = true;
            btnBookRoom.Click += btnBookRoom_Click;
            // 
            // btnViewRoomDetails
            // 
            btnViewRoomDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnViewRoomDetails.Location = new Point(339, 520);
            btnViewRoomDetails.Name = "btnViewRoomDetails";
            btnViewRoomDetails.Size = new Size(197, 23);
            btnViewRoomDetails.TabIndex = 13;
            btnViewRoomDetails.Text = "View Details";
            btnViewRoomDetails.UseVisualStyleBackColor = true;
            btnViewRoomDetails.Click += btnViewRoomDetails_Click;
            // 
            // dgvRooms
            // 
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRooms.BackgroundColor = SystemColors.ControlLight;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRooms.Location = new Point(50, 150);
            dgvRooms.MultiSelect = false;
            dgvRooms.Name = "dgvRooms";
            dgvRooms.ReadOnly = true;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.Size = new Size(974, 346);
            dgvRooms.TabIndex = 12;
            // 
            // btnSearchRooms
            // 
            btnSearchRooms.Location = new Point(827, 88);
            btnSearchRooms.Name = "btnSearchRooms";
            btnSearchRooms.Size = new Size(197, 23);
            btnSearchRooms.TabIndex = 11;
            btnSearchRooms.Text = "Check Availability";
            btnSearchRooms.UseVisualStyleBackColor = true;
            btnSearchRooms.Click += btnSearchRooms_Click;
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Format = DateTimePickerFormat.Short;
            dtpCheckOut.Location = new Point(562, 88);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(200, 23);
            dtpCheckOut.TabIndex = 10;
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Format = DateTimePickerFormat.Short;
            dtpCheckIn.Location = new Point(305, 88);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(200, 23);
            dtpCheckIn.TabIndex = 9;
            // 
            // lblCheckOut
            // 
            lblCheckOut.AutoSize = true;
            lblCheckOut.Location = new Point(562, 70);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Size = new Size(63, 15);
            lblCheckOut.TabIndex = 5;
            lblCheckOut.Text = "Check-out";
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.Location = new Point(305, 70);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(55, 15);
            lblCheckIn.TabIndex = 3;
            lblCheckIn.Text = "Check-in";
            // 
            // txtHotelSearch
            // 
            txtHotelSearch.Location = new Point(50, 88);
            txtHotelSearch.Name = "txtHotelSearch";
            txtHotelSearch.Size = new Size(200, 23);
            txtHotelSearch.TabIndex = 2;
            // 
            // lblHotelSearch
            // 
            lblHotelSearch.AutoSize = true;
            lblHotelSearch.Location = new Point(50, 70);
            lblHotelSearch.Name = "lblHotelSearch";
            lblHotelSearch.Size = new Size(134, 15);
            lblHotelSearch.TabIndex = 1;
            lblHotelSearch.Text = "Search Hotel or location";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(386, 3);
            label1.Name = "label1";
            label1.Size = new Size(407, 54);
            label1.TabIndex = 0;
            label1.Text = "Find your perfect stay";
            // 
            // tabManager
            // 
            tabManager.Controls.Add(tabManagerTools);
            tabManager.Controls.Add(label2);
            tabManager.Location = new Point(4, 24);
            tabManager.Name = "tabManager";
            tabManager.Padding = new Padding(3);
            tabManager.Size = new Size(1076, 573);
            tabManager.TabIndex = 1;
            tabManager.Text = "Management";
            tabManager.UseVisualStyleBackColor = true;
            // 
            // tabManagerTools
            // 
            tabManagerTools.Controls.Add(tabManageHotels);
            tabManagerTools.Controls.Add(tabManageRooms);
            tabManagerTools.Controls.Add(tabBookingApprovals);
            tabManagerTools.Dock = DockStyle.Fill;
            tabManagerTools.Location = new Point(3, 3);
            tabManagerTools.Name = "tabManagerTools";
            tabManagerTools.SelectedIndex = 0;
            tabManagerTools.Size = new Size(1070, 567);
            tabManagerTools.TabIndex = 2;
            // 
            // tabManageHotels
            // 
            tabManageHotels.Controls.Add(btnRefreshHotels);
            tabManageHotels.Controls.Add(btnEditHotel);
            tabManageHotels.Controls.Add(btnAddHotel);
            tabManageHotels.Controls.Add(dgvManagerHotels);
            tabManageHotels.Location = new Point(4, 24);
            tabManageHotels.Name = "tabManageHotels";
            tabManageHotels.Padding = new Padding(3);
            tabManageHotels.Size = new Size(1062, 539);
            tabManageHotels.TabIndex = 0;
            tabManageHotels.Text = "Hotels";
            tabManageHotels.UseVisualStyleBackColor = true;
            // 
            // btnRefreshHotels
            // 
            btnRefreshHotels.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefreshHotels.Location = new Point(671, 465);
            btnRefreshHotels.Name = "btnRefreshHotels";
            btnRefreshHotels.Size = new Size(197, 23);
            btnRefreshHotels.TabIndex = 20;
            btnRefreshHotels.Text = "Refresh";
            btnRefreshHotels.UseVisualStyleBackColor = true;
            btnRefreshHotels.Click += btnRefreshHotels_Click;
            // 
            // btnEditHotel
            // 
            btnEditHotel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditHotel.Location = new Point(449, 465);
            btnEditHotel.Name = "btnEditHotel";
            btnEditHotel.Size = new Size(197, 23);
            btnEditHotel.TabIndex = 19;
            btnEditHotel.Text = "Edit Hotel";
            btnEditHotel.UseVisualStyleBackColor = true;
            btnEditHotel.Click += btnEditHotel_Click;
            // 
            // btnAddHotel
            // 
            btnAddHotel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddHotel.Location = new Point(229, 465);
            btnAddHotel.Name = "btnAddHotel";
            btnAddHotel.Size = new Size(197, 23);
            btnAddHotel.TabIndex = 18;
            btnAddHotel.Text = "Add Hotel";
            btnAddHotel.UseVisualStyleBackColor = true;
            btnAddHotel.Click += btnAddHotel_Click;
            // 
            // dgvManagerHotels
            // 
            dgvManagerHotels.AllowUserToAddRows = false;
            dgvManagerHotels.AllowUserToDeleteRows = false;
            dgvManagerHotels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvManagerHotels.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvManagerHotels.BackgroundColor = SystemColors.ControlLight;
            dgvManagerHotels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvManagerHotels.Location = new Point(45, 80);
            dgvManagerHotels.MultiSelect = false;
            dgvManagerHotels.Name = "dgvManagerHotels";
            dgvManagerHotels.ReadOnly = true;
            dgvManagerHotels.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvManagerHotels.Size = new Size(974, 346);
            dgvManagerHotels.TabIndex = 13;
            // 
            // tabManageRooms
            // 
            tabManageRooms.Controls.Add(btnAddRoom);
            tabManageRooms.Controls.Add(btnRefreshRooms);
            tabManageRooms.Controls.Add(btnRemoveRoom);
            tabManageRooms.Controls.Add(btnEditRoom);
            tabManageRooms.Controls.Add(dgvManagerRooms);
            tabManageRooms.Location = new Point(4, 24);
            tabManageRooms.Name = "tabManageRooms";
            tabManageRooms.Padding = new Padding(3);
            tabManageRooms.Size = new Size(1062, 539);
            tabManageRooms.TabIndex = 1;
            tabManageRooms.Text = "Rooms";
            tabManageRooms.UseVisualStyleBackColor = true;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddRoom.Location = new Point(106, 461);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(197, 23);
            btnAddRoom.TabIndex = 25;
            btnAddRoom.Text = "Add Room";
            btnAddRoom.UseVisualStyleBackColor = true;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // btnRefreshRooms
            // 
            btnRefreshRooms.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefreshRooms.Location = new Point(769, 461);
            btnRefreshRooms.Name = "btnRefreshRooms";
            btnRefreshRooms.Size = new Size(197, 23);
            btnRefreshRooms.TabIndex = 24;
            btnRefreshRooms.Text = "Refresh";
            btnRefreshRooms.UseVisualStyleBackColor = true;
            btnRefreshRooms.Click += btnRefreshRooms_Click;
            // 
            // btnRemoveRoom
            // 
            btnRemoveRoom.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRemoveRoom.Location = new Point(547, 461);
            btnRemoveRoom.Name = "btnRemoveRoom";
            btnRemoveRoom.Size = new Size(197, 23);
            btnRemoveRoom.TabIndex = 23;
            btnRemoveRoom.Text = "Remove Room";
            btnRemoveRoom.UseVisualStyleBackColor = true;
            btnRemoveRoom.Click += btnRemoveRoom_Click;
            // 
            // btnEditRoom
            // 
            btnEditRoom.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditRoom.Location = new Point(327, 461);
            btnEditRoom.Name = "btnEditRoom";
            btnEditRoom.Size = new Size(197, 23);
            btnEditRoom.TabIndex = 22;
            btnEditRoom.Text = "Edit Room";
            btnEditRoom.UseVisualStyleBackColor = true;
            btnEditRoom.Click += btnEditRoom_Click;
            // 
            // dgvManagerRooms
            // 
            dgvManagerRooms.AllowUserToAddRows = false;
            dgvManagerRooms.AllowUserToDeleteRows = false;
            dgvManagerRooms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvManagerRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvManagerRooms.BackgroundColor = SystemColors.ControlLight;
            dgvManagerRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvManagerRooms.Location = new Point(45, 80);
            dgvManagerRooms.MultiSelect = false;
            dgvManagerRooms.Name = "dgvManagerRooms";
            dgvManagerRooms.ReadOnly = true;
            dgvManagerRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvManagerRooms.Size = new Size(974, 346);
            dgvManagerRooms.TabIndex = 21;
            // 
            // tabBookingApprovals
            // 
            tabBookingApprovals.Controls.Add(btnRefreshPendingBookings);
            tabBookingApprovals.Controls.Add(btnRejectBooking);
            tabBookingApprovals.Controls.Add(btnApproveBooking);
            tabBookingApprovals.Controls.Add(dgvPendingBookings);
            tabBookingApprovals.Location = new Point(4, 24);
            tabBookingApprovals.Name = "tabBookingApprovals";
            tabBookingApprovals.Padding = new Padding(3);
            tabBookingApprovals.Size = new Size(1062, 539);
            tabBookingApprovals.TabIndex = 2;
            tabBookingApprovals.Text = "Booking Approvals";
            tabBookingApprovals.UseVisualStyleBackColor = true;
            // 
            // btnRefreshPendingBookings
            // 
            btnRefreshPendingBookings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefreshPendingBookings.Location = new Point(682, 474);
            btnRefreshPendingBookings.Name = "btnRefreshPendingBookings";
            btnRefreshPendingBookings.Size = new Size(197, 23);
            btnRefreshPendingBookings.TabIndex = 25;
            btnRefreshPendingBookings.Text = "Refresh";
            btnRefreshPendingBookings.UseVisualStyleBackColor = true;
            btnRefreshPendingBookings.Click += btnRefreshPendingBookings_Click;
            // 
            // btnRejectBooking
            // 
            btnRejectBooking.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRejectBooking.Location = new Point(460, 474);
            btnRejectBooking.Name = "btnRejectBooking";
            btnRejectBooking.Size = new Size(197, 23);
            btnRejectBooking.TabIndex = 24;
            btnRejectBooking.Text = "Reject";
            btnRejectBooking.UseVisualStyleBackColor = true;
            btnRejectBooking.Click += btnRejectBooking_Click;
            // 
            // btnApproveBooking
            // 
            btnApproveBooking.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnApproveBooking.Location = new Point(240, 474);
            btnApproveBooking.Name = "btnApproveBooking";
            btnApproveBooking.Size = new Size(197, 23);
            btnApproveBooking.TabIndex = 23;
            btnApproveBooking.Text = "Approve";
            btnApproveBooking.UseVisualStyleBackColor = true;
            btnApproveBooking.Click += btnApproveBooking_Click;
            // 
            // dgvPendingBookings
            // 
            dgvPendingBookings.AllowUserToAddRows = false;
            dgvPendingBookings.AllowUserToDeleteRows = false;
            dgvPendingBookings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPendingBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPendingBookings.BackgroundColor = SystemColors.ControlLight;
            dgvPendingBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPendingBookings.Location = new Point(45, 80);
            dgvPendingBookings.MultiSelect = false;
            dgvPendingBookings.Name = "dgvPendingBookings";
            dgvPendingBookings.ReadOnly = true;
            dgvPendingBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPendingBookings.Size = new Size(974, 346);
            dgvPendingBookings.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 30F);
            label2.Location = new Point(383, 3);
            label2.Name = "label2";
            label2.Size = new Size(0, 54);
            label2.TabIndex = 1;
            // 
            // tabAdmin
            // 
            tabAdmin.Controls.Add(tabAdminTools);
            tabAdmin.Controls.Add(label3);
            tabAdmin.Location = new Point(4, 24);
            tabAdmin.Name = "tabAdmin";
            tabAdmin.Padding = new Padding(3);
            tabAdmin.Size = new Size(1076, 573);
            tabAdmin.TabIndex = 2;
            tabAdmin.Text = "Administration";
            tabAdmin.UseVisualStyleBackColor = true;
            // 
            // tabAdminTools
            // 
            tabAdminTools.Controls.Add(tabManageAccounts);
            tabAdminTools.Controls.Add(tabManageRefunds);
            tabAdminTools.Controls.Add(tabReports);
            tabAdminTools.Dock = DockStyle.Fill;
            tabAdminTools.Location = new Point(3, 3);
            tabAdminTools.Name = "tabAdminTools";
            tabAdminTools.SelectedIndex = 0;
            tabAdminTools.Size = new Size(1070, 567);
            tabAdminTools.TabIndex = 3;
            // 
            // tabManageAccounts
            // 
            tabManageAccounts.Controls.Add(btnRefreshUsers);
            tabManageAccounts.Controls.Add(btnToggleAccountStatus);
            tabManageAccounts.Controls.Add(btnSearchUsers);
            tabManageAccounts.Controls.Add(txtUserSearch);
            tabManageAccounts.Controls.Add(lblUserSearch);
            tabManageAccounts.Controls.Add(button1);
            tabManageAccounts.Controls.Add(button2);
            tabManageAccounts.Controls.Add(button3);
            tabManageAccounts.Controls.Add(dgvUsers);
            tabManageAccounts.Location = new Point(4, 24);
            tabManageAccounts.Name = "tabManageAccounts";
            tabManageAccounts.Padding = new Padding(3);
            tabManageAccounts.Size = new Size(1062, 539);
            tabManageAccounts.TabIndex = 0;
            tabManageAccounts.Text = "Accounts";
            tabManageAccounts.UseVisualStyleBackColor = true;
            // 
            // btnRefreshUsers
            // 
            btnRefreshUsers.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefreshUsers.Location = new Point(789, 471);
            btnRefreshUsers.Name = "btnRefreshUsers";
            btnRefreshUsers.Size = new Size(197, 23);
            btnRefreshUsers.TabIndex = 28;
            btnRefreshUsers.Text = "Refresh";
            btnRefreshUsers.UseVisualStyleBackColor = true;
            btnRefreshUsers.Click += btnRefreshUsers_Click;
            // 
            // btnToggleAccountStatus
            // 
            btnToggleAccountStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnToggleAccountStatus.Location = new Point(567, 471);
            btnToggleAccountStatus.Name = "btnToggleAccountStatus";
            btnToggleAccountStatus.Size = new Size(197, 23);
            btnToggleAccountStatus.TabIndex = 27;
            btnToggleAccountStatus.Text = "Enable / Disable";
            btnToggleAccountStatus.UseVisualStyleBackColor = true;
            btnToggleAccountStatus.Click += btnToggleAccountStatus_Click;
            // 
            // btnSearchUsers
            // 
            btnSearchUsers.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSearchUsers.Location = new Point(347, 471);
            btnSearchUsers.Name = "btnSearchUsers";
            btnSearchUsers.Size = new Size(197, 23);
            btnSearchUsers.TabIndex = 26;
            btnSearchUsers.Text = "Search";
            btnSearchUsers.UseVisualStyleBackColor = true;
            btnSearchUsers.Click += btnSearchUsers_Click;
            // 
            // txtUserSearch
            // 
            txtUserSearch.Location = new Point(169, 471);
            txtUserSearch.Name = "txtUserSearch";
            txtUserSearch.Size = new Size(142, 23);
            txtUserSearch.TabIndex = 22;
            // 
            // lblUserSearch
            // 
            lblUserSearch.AutoSize = true;
            lblUserSearch.Location = new Point(78, 474);
            lblUserSearch.Name = "lblUserSearch";
            lblUserSearch.Size = new Size(85, 15);
            lblUserSearch.TabIndex = 21;
            lblUserSearch.Text = "Name or email";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(1530, 901);
            button1.Name = "button1";
            button1.Size = new Size(197, 23);
            button1.TabIndex = 20;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(1308, 901);
            button2.Name = "button2";
            button2.Size = new Size(197, 23);
            button2.TabIndex = 19;
            button2.Text = "Edit Hotel";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.Location = new Point(1088, 901);
            button3.Name = "button3";
            button3.Size = new Size(197, 23);
            button3.TabIndex = 18;
            button3.Text = "Add Hotel";
            button3.UseVisualStyleBackColor = true;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = SystemColors.ControlLight;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(45, 80);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(974, 346);
            dgvUsers.TabIndex = 13;
            // 
            // tabManageRefunds
            // 
            tabManageRefunds.Controls.Add(btnRefreshRefunds);
            tabManageRefunds.Controls.Add(btnProcessRefund);
            tabManageRefunds.Controls.Add(button4);
            tabManageRefunds.Controls.Add(button5);
            tabManageRefunds.Controls.Add(button6);
            tabManageRefunds.Controls.Add(button7);
            tabManageRefunds.Controls.Add(dgvRefunds);
            tabManageRefunds.Location = new Point(4, 24);
            tabManageRefunds.Name = "tabManageRefunds";
            tabManageRefunds.Padding = new Padding(3);
            tabManageRefunds.Size = new Size(1062, 539);
            tabManageRefunds.TabIndex = 1;
            tabManageRefunds.Text = "Refunds";
            tabManageRefunds.UseVisualStyleBackColor = true;
            // 
            // btnRefreshRefunds
            // 
            btnRefreshRefunds.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefreshRefunds.Location = new Point(574, 473);
            btnRefreshRefunds.Name = "btnRefreshRefunds";
            btnRefreshRefunds.Size = new Size(197, 23);
            btnRefreshRefunds.TabIndex = 30;
            btnRefreshRefunds.Text = "Refresh";
            btnRefreshRefunds.UseVisualStyleBackColor = true;
            btnRefreshRefunds.Click += btnRefreshRefunds_Click;
            // 
            // btnProcessRefund
            // 
            btnProcessRefund.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnProcessRefund.Location = new Point(352, 473);
            btnProcessRefund.Name = "btnProcessRefund";
            btnProcessRefund.Size = new Size(197, 23);
            btnProcessRefund.TabIndex = 29;
            btnProcessRefund.Text = "Process Refund";
            btnProcessRefund.UseVisualStyleBackColor = true;
            btnProcessRefund.Click += btnProcessRefund_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.Location = new Point(965, 897);
            button4.Name = "button4";
            button4.Size = new Size(197, 23);
            button4.TabIndex = 25;
            button4.Text = "Add Room";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button5.Location = new Point(1628, 897);
            button5.Name = "button5";
            button5.Size = new Size(197, 23);
            button5.TabIndex = 24;
            button5.Text = "Refresh";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button6.Location = new Point(1406, 897);
            button6.Name = "button6";
            button6.Size = new Size(197, 23);
            button6.TabIndex = 23;
            button6.Text = "Remove Room";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button7.Location = new Point(1186, 897);
            button7.Name = "button7";
            button7.Size = new Size(197, 23);
            button7.TabIndex = 22;
            button7.Text = "Edit Room";
            button7.UseVisualStyleBackColor = true;
            // 
            // dgvRefunds
            // 
            dgvRefunds.AllowUserToAddRows = false;
            dgvRefunds.AllowUserToDeleteRows = false;
            dgvRefunds.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRefunds.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRefunds.BackgroundColor = SystemColors.ControlLight;
            dgvRefunds.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRefunds.Location = new Point(45, 80);
            dgvRefunds.MultiSelect = false;
            dgvRefunds.Name = "dgvRefunds";
            dgvRefunds.ReadOnly = true;
            dgvRefunds.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRefunds.Size = new Size(974, 346);
            dgvRefunds.TabIndex = 21;
            // 
            // tabReports
            // 
            tabReports.Controls.Add(label7);
            tabReports.Controls.Add(label6);
            tabReports.Controls.Add(dgvHotelReport);
            tabReports.Controls.Add(lblReportGeneratedAt);
            tabReports.Controls.Add(lblNetRevenueReport);
            tabReports.Controls.Add(lblRefundedReport);
            tabReports.Controls.Add(lblGrossRevenueReport);
            tabReports.Controls.Add(lblTotalBookingsReport);
            tabReports.Controls.Add(lblTotalRoomsReport);
            tabReports.Controls.Add(lblTotalHotelsReport);
            tabReports.Controls.Add(lblTotalUsersReport);
            tabReports.Controls.Add(btnGenerateReport);
            tabReports.Controls.Add(dtpReportTo);
            tabReports.Controls.Add(lblReportTo);
            tabReports.Controls.Add(dtpReportFrom);
            tabReports.Controls.Add(lblReportFrom);
            tabReports.Controls.Add(button8);
            tabReports.Controls.Add(button9);
            tabReports.Controls.Add(button10);
            tabReports.Controls.Add(dgvBookingStatusReport);
            tabReports.Location = new Point(4, 24);
            tabReports.Name = "tabReports";
            tabReports.Padding = new Padding(3);
            tabReports.Size = new Size(1062, 539);
            tabReports.TabIndex = 2;
            tabReports.Text = "Reports";
            tabReports.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(252, 259);
            label7.Name = "label7";
            label7.Size = new Size(107, 15);
            label7.TabIndex = 41;
            label7.Text = "Bookings by Status";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(695, 259);
            label6.Name = "label6";
            label6.Size = new Size(107, 15);
            label6.TabIndex = 40;
            label6.Text = "Hotel Performance";
            // 
            // dgvHotelReport
            // 
            dgvHotelReport.AllowUserToAddRows = false;
            dgvHotelReport.AllowUserToDeleteRows = false;
            dgvHotelReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHotelReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHotelReport.BackgroundColor = SystemColors.ControlLight;
            dgvHotelReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHotelReport.Location = new Point(548, 292);
            dgvHotelReport.MultiSelect = false;
            dgvHotelReport.Name = "dgvHotelReport";
            dgvHotelReport.ReadOnly = true;
            dgvHotelReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHotelReport.Size = new Size(390, 196);
            dgvHotelReport.TabIndex = 39;
            // 
            // lblReportGeneratedAt
            // 
            lblReportGeneratedAt.AutoSize = true;
            lblReportGeneratedAt.Location = new Point(100, 193);
            lblReportGeneratedAt.Name = "lblReportGeneratedAt";
            lblReportGeneratedAt.Size = new Size(0, 15);
            lblReportGeneratedAt.TabIndex = 38;
            // 
            // lblNetRevenueReport
            // 
            lblNetRevenueReport.AutoSize = true;
            lblNetRevenueReport.Location = new Point(738, 193);
            lblNetRevenueReport.Name = "lblNetRevenueReport";
            lblNetRevenueReport.Size = new Size(104, 15);
            lblNetRevenueReport.TabIndex = 37;
            lblNetRevenueReport.Text = "Net revenue: £0.00";
            // 
            // lblRefundedReport
            // 
            lblRefundedReport.AutoSize = true;
            lblRefundedReport.Location = new Point(738, 142);
            lblRefundedReport.Name = "lblRefundedReport";
            lblRefundedReport.Size = new Size(91, 15);
            lblRefundedReport.TabIndex = 36;
            lblRefundedReport.Text = "Refunded: £0.00";
            // 
            // lblGrossRevenueReport
            // 
            lblGrossRevenueReport.AutoSize = true;
            lblGrossRevenueReport.Location = new Point(738, 92);
            lblGrossRevenueReport.Name = "lblGrossRevenueReport";
            lblGrossRevenueReport.Size = new Size(124, 15);
            lblGrossRevenueReport.TabIndex = 35;
            lblGrossRevenueReport.Text = "Gross payments: £0.00";
            // 
            // lblTotalBookingsReport
            // 
            lblTotalBookingsReport.AutoSize = true;
            lblTotalBookingsReport.Location = new Point(99, 142);
            lblTotalBookingsReport.Name = "lblTotalBookingsReport";
            lblTotalBookingsReport.Size = new Size(68, 15);
            lblTotalBookingsReport.TabIndex = 34;
            lblTotalBookingsReport.Text = "Bookings: 0";
            // 
            // lblTotalRoomsReport
            // 
            lblTotalRoomsReport.AutoSize = true;
            lblTotalRoomsReport.Location = new Point(409, 142);
            lblTotalRoomsReport.Name = "lblTotalRoomsReport";
            lblTotalRoomsReport.Size = new Size(56, 15);
            lblTotalRoomsReport.TabIndex = 33;
            lblTotalRoomsReport.Text = "Rooms: 0";
            // 
            // lblTotalHotelsReport
            // 
            lblTotalHotelsReport.AutoSize = true;
            lblTotalHotelsReport.Location = new Point(409, 92);
            lblTotalHotelsReport.Name = "lblTotalHotelsReport";
            lblTotalHotelsReport.Size = new Size(53, 15);
            lblTotalHotelsReport.TabIndex = 32;
            lblTotalHotelsReport.Text = "Hotels: 0";
            // 
            // lblTotalUsersReport
            // 
            lblTotalUsersReport.AutoSize = true;
            lblTotalUsersReport.Location = new Point(99, 92);
            lblTotalUsersReport.Name = "lblTotalUsersReport";
            lblTotalUsersReport.Size = new Size(47, 15);
            lblTotalUsersReport.TabIndex = 31;
            lblTotalUsersReport.Text = "Users: 0";
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(738, 33);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(200, 23);
            btnGenerateReport.TabIndex = 30;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // dtpReportTo
            // 
            dtpReportTo.Format = DateTimePickerFormat.Short;
            dtpReportTo.Location = new Point(462, 33);
            dtpReportTo.Name = "dtpReportTo";
            dtpReportTo.Size = new Size(200, 23);
            dtpReportTo.TabIndex = 29;
            // 
            // lblReportTo
            // 
            lblReportTo.AutoSize = true;
            lblReportTo.Location = new Point(409, 39);
            lblReportTo.Name = "lblReportTo";
            lblReportTo.Size = new Size(20, 15);
            lblReportTo.TabIndex = 28;
            lblReportTo.Text = "To";
            // 
            // dtpReportFrom
            // 
            dtpReportFrom.Format = DateTimePickerFormat.Short;
            dtpReportFrom.Location = new Point(159, 33);
            dtpReportFrom.Name = "dtpReportFrom";
            dtpReportFrom.Size = new Size(200, 23);
            dtpReportFrom.TabIndex = 27;
            // 
            // lblReportFrom
            // 
            lblReportFrom.AutoSize = true;
            lblReportFrom.Location = new Point(100, 39);
            lblReportFrom.Name = "lblReportFrom";
            lblReportFrom.Size = new Size(35, 15);
            lblReportFrom.TabIndex = 26;
            lblReportFrom.Text = "From";
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button8.Location = new Point(1541, 910);
            button8.Name = "button8";
            button8.Size = new Size(197, 23);
            button8.TabIndex = 25;
            button8.Text = "Refresh";
            button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button9.Location = new Point(1319, 910);
            button9.Name = "button9";
            button9.Size = new Size(197, 23);
            button9.TabIndex = 24;
            button9.Text = "Reject";
            button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button10.Location = new Point(1099, 910);
            button10.Name = "button10";
            button10.Size = new Size(197, 23);
            button10.TabIndex = 23;
            button10.Text = "Approve";
            button10.UseVisualStyleBackColor = true;
            // 
            // dgvBookingStatusReport
            // 
            dgvBookingStatusReport.AllowUserToAddRows = false;
            dgvBookingStatusReport.AllowUserToDeleteRows = false;
            dgvBookingStatusReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBookingStatusReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookingStatusReport.BackgroundColor = SystemColors.ControlLight;
            dgvBookingStatusReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookingStatusReport.Location = new Point(100, 292);
            dgvBookingStatusReport.MultiSelect = false;
            dgvBookingStatusReport.Name = "dgvBookingStatusReport";
            dgvBookingStatusReport.ReadOnly = true;
            dgvBookingStatusReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookingStatusReport.Size = new Size(390, 196);
            dgvBookingStatusReport.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 30F);
            label3.Location = new Point(374, 3);
            label3.Name = "label3";
            label3.Size = new Size(0, 54);
            label3.TabIndex = 2;
            // 
            // tabMyBookings
            // 
            tabMyBookings.Controls.Add(btnModifyBooking);
            tabMyBookings.Controls.Add(btnCancelBooking);
            tabMyBookings.Controls.Add(btnRefreshBookings);
            tabMyBookings.Controls.Add(label4);
            tabMyBookings.Controls.Add(dgvMyBookings);
            tabMyBookings.Location = new Point(4, 24);
            tabMyBookings.Name = "tabMyBookings";
            tabMyBookings.Padding = new Padding(3);
            tabMyBookings.Size = new Size(1076, 573);
            tabMyBookings.TabIndex = 3;
            tabMyBookings.Text = "Bookings";
            tabMyBookings.UseVisualStyleBackColor = true;
            // 
            // btnModifyBooking
            // 
            btnModifyBooking.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnModifyBooking.Location = new Point(668, 508);
            btnModifyBooking.Name = "btnModifyBooking";
            btnModifyBooking.Size = new Size(197, 23);
            btnModifyBooking.TabIndex = 17;
            btnModifyBooking.Text = "Modify Booking";
            btnModifyBooking.UseVisualStyleBackColor = true;
            btnModifyBooking.Click += btnModifyBooking_Click;
            // 
            // btnCancelBooking
            // 
            btnCancelBooking.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelBooking.Location = new Point(443, 508);
            btnCancelBooking.Name = "btnCancelBooking";
            btnCancelBooking.Size = new Size(197, 23);
            btnCancelBooking.TabIndex = 16;
            btnCancelBooking.Text = "Cancel Booking";
            btnCancelBooking.UseVisualStyleBackColor = true;
            btnCancelBooking.Click += btnCancelBooking_Click;
            // 
            // btnRefreshBookings
            // 
            btnRefreshBookings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefreshBookings.Location = new Point(226, 508);
            btnRefreshBookings.Name = "btnRefreshBookings";
            btnRefreshBookings.Size = new Size(197, 23);
            btnRefreshBookings.TabIndex = 15;
            btnRefreshBookings.Text = "Refresh";
            btnRefreshBookings.UseVisualStyleBackColor = true;
            btnRefreshBookings.Click += btnRefreshBookings_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 30F);
            label4.Location = new Point(421, 33);
            label4.Name = "label4";
            label4.Size = new Size(276, 54);
            label4.TabIndex = 14;
            label4.Text = "Your bookings";
            // 
            // dgvMyBookings
            // 
            dgvMyBookings.AllowUserToAddRows = false;
            dgvMyBookings.AllowUserToDeleteRows = false;
            dgvMyBookings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMyBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMyBookings.BackgroundColor = SystemColors.ControlLight;
            dgvMyBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyBookings.Location = new Point(56, 116);
            dgvMyBookings.MultiSelect = false;
            dgvMyBookings.Name = "dgvMyBookings";
            dgvMyBookings.ReadOnly = true;
            dgvMyBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyBookings.Size = new Size(974, 346);
            dgvMyBookings.TabIndex = 13;
            // 
            // tabNotifications
            // 
            tabNotifications.Controls.Add(btnMarkNotificationRead);
            tabNotifications.Controls.Add(btnRefreshNotifications);
            tabNotifications.Controls.Add(label5);
            tabNotifications.Controls.Add(dgvNotifications);
            tabNotifications.Location = new Point(4, 24);
            tabNotifications.Name = "tabNotifications";
            tabNotifications.Size = new Size(1076, 573);
            tabNotifications.TabIndex = 0;
            tabNotifications.Text = "Notifications";
            tabNotifications.UseVisualStyleBackColor = true;
            // 
            // btnMarkNotificationRead
            // 
            btnMarkNotificationRead.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnMarkNotificationRead.Location = new Point(583, 516);
            btnMarkNotificationRead.Name = "btnMarkNotificationRead";
            btnMarkNotificationRead.Size = new Size(197, 23);
            btnMarkNotificationRead.TabIndex = 20;
            btnMarkNotificationRead.Text = "Mark as Read";
            btnMarkNotificationRead.UseVisualStyleBackColor = true;
            btnMarkNotificationRead.Click += btnMarkNotificationRead_Click;
            // 
            // btnRefreshNotifications
            // 
            btnRefreshNotifications.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefreshNotifications.Location = new Point(366, 516);
            btnRefreshNotifications.Name = "btnRefreshNotifications";
            btnRefreshNotifications.Size = new Size(197, 23);
            btnRefreshNotifications.TabIndex = 19;
            btnRefreshNotifications.Text = "Refresh";
            btnRefreshNotifications.UseVisualStyleBackColor = true;
            btnRefreshNotifications.Click += btnRefreshNotifications_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 30F);
            label5.Location = new Point(403, 37);
            label5.Name = "label5";
            label5.Size = new Size(337, 54);
            label5.TabIndex = 18;
            label5.Text = "Your Notifications";
            // 
            // dgvNotifications
            // 
            dgvNotifications.AllowUserToAddRows = false;
            dgvNotifications.AllowUserToDeleteRows = false;
            dgvNotifications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNotifications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNotifications.BackgroundColor = SystemColors.ControlLight;
            dgvNotifications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotifications.Location = new Point(51, 119);
            dgvNotifications.MultiSelect = false;
            dgvNotifications.Name = "dgvNotifications";
            dgvNotifications.ReadOnly = true;
            dgvNotifications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNotifications.Size = new Size(974, 346);
            dgvNotifications.TabIndex = 17;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1084, 661);
            Controls.Add(tabDashboard);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(900, 600);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hotel Management System";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tabDashboard.ResumeLayout(false);
            tabGuest.ResumeLayout(false);
            tabGuest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            tabManager.ResumeLayout(false);
            tabManager.PerformLayout();
            tabManagerTools.ResumeLayout(false);
            tabManageHotels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvManagerHotels).EndInit();
            tabManageRooms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvManagerRooms).EndInit();
            tabBookingApprovals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPendingBookings).EndInit();
            tabAdmin.ResumeLayout(false);
            tabAdmin.PerformLayout();
            tabAdminTools.ResumeLayout(false);
            tabManageAccounts.ResumeLayout(false);
            tabManageAccounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            tabManageRefunds.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRefunds).EndInit();
            tabReports.ResumeLayout(false);
            tabReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHotelReport).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBookingStatusReport).EndInit();
            tabMyBookings.ResumeLayout(false);
            tabMyBookings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMyBookings).EndInit();
            tabNotifications.ResumeLayout(false);
            tabNotifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotifications).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Button btnLogout;
        private Label lblRole;
        private Label lblWelcome;
        private TabControl tabDashboard;
        private TabPage tabGuest;
        private Label label1;
        private TabPage tabManager;
        private TabPage tabAdmin;
        private Label label2;
        private Label label3;
        private TextBox txtHotelSearch;
        private Label lblHotelSearch;
        private DateTimePicker dtpCheckIn;
        private Label lblCheckOut;
        private Label lblCheckIn;
        private DateTimePicker dtpCheckOut;
        private DataGridView dgvRooms;
        private Button btnSearchRooms;
        private Button btnViewRoomDetails;
        private Button btnBookRoom;
        private TabPage tabMyBookings;
        private TabPage tabNotifications;
        private Button btnCancelBooking;
        private Button btnRefreshBookings;
        private Label label4;
        private DataGridView dgvMyBookings;
        private Button btnMarkNotificationRead;
        private Button btnRefreshNotifications;
        private Label label5;
        private DataGridView dgvNotifications;
        private Button btnModifyBooking;
        private TabControl tabManagerTools;
        private TabPage tabManageHotels;
        private TabPage tabManageRooms;
        private DataGridView dgvManagerHotels;
        private TabPage tabBookingApprovals;
        private Button btnRefreshHotels;
        private Button btnEditHotel;
        private Button btnAddHotel;
        private Button btnAddRoom;
        private Button btnRefreshRooms;
        private Button btnRemoveRoom;
        private Button btnEditRoom;
        private DataGridView dgvManagerRooms;
        private Button btnRefreshPendingBookings;
        private Button btnRejectBooking;
        private Button btnApproveBooking;
        private DataGridView dgvPendingBookings;
        private TabControl tabAdminTools;
        private TabPage tabManageAccounts;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dgvUsers;
        private TabPage tabManageRefunds;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private DataGridView dgvRefunds;
        private TabPage tabReports;
        private Button button8;
        private Button button9;
        private Button button10;
        private DataGridView dgvBookingStatusReport;
        private TextBox txtUserSearch;
        private Label lblUserSearch;
        private Button btnRefreshUsers;
        private Button btnToggleAccountStatus;
        private Button btnSearchUsers;
        private Button btnRefreshRefunds;
        private Button btnProcessRefund;
        private DateTimePicker dtpReportTo;
        private Label lblReportTo;
        private DateTimePicker dtpReportFrom;
        private Label lblReportFrom;
        private Label lblTotalBookingsReport;
        private Label lblTotalRoomsReport;
        private Label lblTotalHotelsReport;
        private Label lblTotalUsersReport;
        private Button btnGenerateReport;
        private Label lblNetRevenueReport;
        private Label lblRefundedReport;
        private Label lblGrossRevenueReport;
        private DataGridView dgvHotelReport;
        private Label lblReportGeneratedAt;
        private Label label7;
        private Label label6;
    }
}