namespace HotelManagementSystem
{
    partial class ModifyBookingForm
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
            lblHotelValue = new Label();
            lblRoomValue = new Label();
            lblCurrentDatesValue = new Label();
            dtpNewCheckIn = new DateTimePicker();
            dtpNewCheckOut = new DateTimePicker();
            lblNewNightsValue = new Label();
            lblNewSubtotalValue = new Label();
            lblNewDiscountValue = new Label();
            lblNewTotalValue = new Label();
            btnSaveChanges = new Button();
            btnCancel = new Button();
            btnCalculate = new Button();
            lblMessage = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // lblHotelValue
            // 
            lblHotelValue.AutoSize = true;
            lblHotelValue.Location = new Point(163, 18);
            lblHotelValue.Name = "lblHotelValue";
            lblHotelValue.Size = new Size(36, 15);
            lblHotelValue.TabIndex = 0;
            lblHotelValue.Text = "Hotel";
            // 
            // lblRoomValue
            // 
            lblRoomValue.AutoSize = true;
            lblRoomValue.Location = new Point(163, 56);
            lblRoomValue.Name = "lblRoomValue";
            lblRoomValue.Size = new Size(39, 15);
            lblRoomValue.TabIndex = 1;
            lblRoomValue.Text = "Room";
            // 
            // lblCurrentDatesValue
            // 
            lblCurrentDatesValue.AutoSize = true;
            lblCurrentDatesValue.Location = new Point(163, 97);
            lblCurrentDatesValue.Name = "lblCurrentDatesValue";
            lblCurrentDatesValue.Size = new Size(79, 15);
            lblCurrentDatesValue.TabIndex = 2;
            lblCurrentDatesValue.Text = "Current Dates";
            // 
            // dtpNewCheckIn
            // 
            dtpNewCheckIn.Format = DateTimePickerFormat.Short;
            dtpNewCheckIn.Location = new Point(163, 141);
            dtpNewCheckIn.Name = "dtpNewCheckIn";
            dtpNewCheckIn.Size = new Size(200, 23);
            dtpNewCheckIn.TabIndex = 3;
            // 
            // dtpNewCheckOut
            // 
            dtpNewCheckOut.Format = DateTimePickerFormat.Short;
            dtpNewCheckOut.Location = new Point(163, 189);
            dtpNewCheckOut.Name = "dtpNewCheckOut";
            dtpNewCheckOut.Size = new Size(200, 23);
            dtpNewCheckOut.TabIndex = 4;
            // 
            // lblNewNightsValue
            // 
            lblNewNightsValue.AutoSize = true;
            lblNewNightsValue.Location = new Point(163, 242);
            lblNewNightsValue.Name = "lblNewNightsValue";
            lblNewNightsValue.Size = new Size(54, 15);
            lblNewNightsValue.TabIndex = 5;
            lblNewNightsValue.Text = "Nights: 0";
            // 
            // lblNewSubtotalValue
            // 
            lblNewSubtotalValue.AutoSize = true;
            lblNewSubtotalValue.Location = new Point(163, 279);
            lblNewSubtotalValue.Name = "lblNewSubtotalValue";
            lblNewSubtotalValue.Size = new Size(84, 15);
            lblNewSubtotalValue.TabIndex = 6;
            lblNewSubtotalValue.Text = "Subtotal: £0.00";
            // 
            // lblNewDiscountValue
            // 
            lblNewDiscountValue.AutoSize = true;
            lblNewDiscountValue.Location = new Point(163, 316);
            lblNewDiscountValue.Name = "lblNewDiscountValue";
            lblNewDiscountValue.Size = new Size(87, 15);
            lblNewDiscountValue.TabIndex = 7;
            lblNewDiscountValue.Text = "Discount: £0.00";
            // 
            // lblNewTotalValue
            // 
            lblNewTotalValue.AutoSize = true;
            lblNewTotalValue.Location = new Point(163, 354);
            lblNewTotalValue.Name = "lblNewTotalValue";
            lblNewTotalValue.Size = new Size(66, 15);
            lblNewTotalValue.TabIndex = 8;
            lblNewTotalValue.Text = "Total: £0.00";
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(183, 426);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(140, 23);
            btnSaveChanges.TabIndex = 9;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(334, 426);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 23);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(32, 426);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(140, 23);
            btnCalculate.TabIndex = 11;
            btnCalculate.Text = "Calculate New Price";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(122, 389);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 15);
            lblMessage.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 18);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 13;
            label1.Text = "Hotel:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 56);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 14;
            label2.Text = "Room:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 97);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 15;
            label3.Text = "Current dates:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 141);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 16;
            label4.Text = "New check-in:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 195);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 17;
            label5.Text = "New check-out:";
            // 
            // ModifyBookingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(504, 461);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblMessage);
            Controls.Add(btnCalculate);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveChanges);
            Controls.Add(lblNewTotalValue);
            Controls.Add(lblNewDiscountValue);
            Controls.Add(lblNewSubtotalValue);
            Controls.Add(lblNewNightsValue);
            Controls.Add(dtpNewCheckOut);
            Controls.Add(dtpNewCheckIn);
            Controls.Add(lblCurrentDatesValue);
            Controls.Add(lblRoomValue);
            Controls.Add(lblHotelValue);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ModifyBookingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Modify Booking";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHotelValue;
        private Label lblRoomValue;
        private Label lblCurrentDatesValue;
        private DateTimePicker dtpNewCheckIn;
        private DateTimePicker dtpNewCheckOut;
        private Label lblNewNightsValue;
        private Label lblNewSubtotalValue;
        private Label lblNewDiscountValue;
        private Label lblNewTotalValue;
        private Button btnSaveChanges;
        private Button btnCancel;
        private Button btnCalculate;
        private Label lblMessage;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}