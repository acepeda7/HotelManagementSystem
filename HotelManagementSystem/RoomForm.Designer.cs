namespace HotelManagementSystem
{
    partial class RoomForm
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
            cmbHotel = new ComboBox();
            txtRoomNumber = new TextBox();
            txtRoomType = new TextBox();
            nudCapacity = new NumericUpDown();
            nudPricePerNight = new NumericUpDown();
            cmbRoomStatus = new ComboBox();
            txtRoomDescription = new TextBox();
            lblMessage = new Label();
            btnCancel = new Button();
            btnSaveRoom = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudCapacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPricePerNight).BeginInit();
            SuspendLayout();
            // 
            // cmbHotel
            // 
            cmbHotel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHotel.FormattingEnabled = true;
            cmbHotel.Location = new Point(211, 45);
            cmbHotel.Name = "cmbHotel";
            cmbHotel.Size = new Size(240, 23);
            cmbHotel.TabIndex = 0;
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Location = new Point(211, 108);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(240, 23);
            txtRoomNumber.TabIndex = 1;
            // 
            // txtRoomType
            // 
            txtRoomType.Location = new Point(211, 181);
            txtRoomType.Name = "txtRoomType";
            txtRoomType.Size = new Size(240, 23);
            txtRoomType.TabIndex = 2;
            // 
            // nudCapacity
            // 
            nudCapacity.Location = new Point(211, 250);
            nudCapacity.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCapacity.Name = "nudCapacity";
            nudCapacity.Size = new Size(240, 23);
            nudCapacity.TabIndex = 3;
            nudCapacity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudPricePerNight
            // 
            nudPricePerNight.DecimalPlaces = 2;
            nudPricePerNight.Location = new Point(211, 314);
            nudPricePerNight.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPricePerNight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPricePerNight.Name = "nudPricePerNight";
            nudPricePerNight.Size = new Size(240, 23);
            nudPricePerNight.TabIndex = 4;
            nudPricePerNight.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbRoomStatus
            // 
            cmbRoomStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomStatus.FormattingEnabled = true;
            cmbRoomStatus.Location = new Point(211, 387);
            cmbRoomStatus.Name = "cmbRoomStatus";
            cmbRoomStatus.Size = new Size(240, 23);
            cmbRoomStatus.TabIndex = 5;
            // 
            // txtRoomDescription
            // 
            txtRoomDescription.Location = new Point(211, 455);
            txtRoomDescription.Multiline = true;
            txtRoomDescription.Name = "txtRoomDescription";
            txtRoomDescription.ScrollBars = ScrollBars.Vertical;
            txtRoomDescription.Size = new Size(240, 23);
            txtRoomDescription.TabIndex = 6;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(95, 516);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 15);
            lblMessage.TabIndex = 13;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(299, 554);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(145, 23);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSaveRoom
            // 
            btnSaveRoom.Location = new Point(95, 554);
            btnSaveRoom.Name = "btnSaveRoom";
            btnSaveRoom.Size = new Size(145, 23);
            btnSaveRoom.TabIndex = 11;
            btnSaveRoom.Text = "Save Room";
            btnSaveRoom.UseVisualStyleBackColor = true;
            btnSaveRoom.Click += btnSaveRoom_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(113, 48);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 14;
            label1.Text = "Hotel:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 111);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 15;
            label2.Text = "Room number:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(84, 184);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 16;
            label3.Text = "Room type:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(96, 252);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 17;
            label4.Text = "Capacity:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(65, 316);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 18;
            label5.Text = "Price per night:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(110, 390);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 19;
            label6.Text = "Status:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(82, 458);
            label7.Name = "label7";
            label7.Size = new Size(70, 15);
            label7.TabIndex = 20;
            label7.Text = "Description:";
            // 
            // RoomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(534, 611);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblMessage);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveRoom);
            Controls.Add(txtRoomDescription);
            Controls.Add(cmbRoomStatus);
            Controls.Add(nudPricePerNight);
            Controls.Add(nudCapacity);
            Controls.Add(txtRoomType);
            Controls.Add(txtRoomNumber);
            Controls.Add(cmbHotel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RoomForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "RoomForm";
            ((System.ComponentModel.ISupportInitialize)nudCapacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPricePerNight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbHotel;
        private TextBox txtRoomNumber;
        private TextBox txtRoomType;
        private NumericUpDown nudCapacity;
        private NumericUpDown nudPricePerNight;
        private ComboBox cmbRoomStatus;
        private TextBox txtRoomDescription;
        private Label lblMessage;
        private Button btnCancel;
        private Button btnSaveRoom;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}