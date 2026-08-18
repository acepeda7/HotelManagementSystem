namespace HotelManagementSystem
{
    partial class BookingForm
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
            lblTitle = new Label();
            lblHotelValue = new Label();
            lblRoomValue = new Label();
            lblDatesValue = new Label();
            lblNightsValue = new Label();
            lblSubtotalValue = new Label();
            txtDiscountCode = new TextBox();
            btnApplyDiscount = new Button();
            lblDiscountValue = new Label();
            lblTotalValue = new Label();
            txtCardholderName = new TextBox();
            txtCardNumber = new TextBox();
            btnConfirmBooking = new Button();
            btnCancel = new Button();
            lblMessage = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(210, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(193, 22);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Confirm Your Booking";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblHotelValue
            // 
            lblHotelValue.AutoSize = true;
            lblHotelValue.Location = new Point(186, 67);
            lblHotelValue.Name = "lblHotelValue";
            lblHotelValue.Size = new Size(36, 15);
            lblHotelValue.TabIndex = 2;
            lblHotelValue.Text = "Hotel";
            // 
            // lblRoomValue
            // 
            lblRoomValue.AutoSize = true;
            lblRoomValue.Location = new Point(186, 111);
            lblRoomValue.Name = "lblRoomValue";
            lblRoomValue.Size = new Size(39, 15);
            lblRoomValue.TabIndex = 3;
            lblRoomValue.Text = "Room";
            // 
            // lblDatesValue
            // 
            lblDatesValue.AutoSize = true;
            lblDatesValue.Location = new Point(187, 156);
            lblDatesValue.Name = "lblDatesValue";
            lblDatesValue.Size = new Size(36, 15);
            lblDatesValue.TabIndex = 4;
            lblDatesValue.Text = "Dates";
            // 
            // lblNightsValue
            // 
            lblNightsValue.AutoSize = true;
            lblNightsValue.Location = new Point(187, 206);
            lblNightsValue.Name = "lblNightsValue";
            lblNightsValue.Size = new Size(42, 15);
            lblNightsValue.TabIndex = 5;
            lblNightsValue.Text = "Nights";
            // 
            // lblSubtotalValue
            // 
            lblSubtotalValue.AutoSize = true;
            lblSubtotalValue.Location = new Point(187, 259);
            lblSubtotalValue.Name = "lblSubtotalValue";
            lblSubtotalValue.Size = new Size(51, 15);
            lblSubtotalValue.TabIndex = 6;
            lblSubtotalValue.Text = "Subtotal";
            // 
            // txtDiscountCode
            // 
            txtDiscountCode.Location = new Point(187, 310);
            txtDiscountCode.Name = "txtDiscountCode";
            txtDiscountCode.Size = new Size(100, 23);
            txtDiscountCode.TabIndex = 7;
            // 
            // btnApplyDiscount
            // 
            btnApplyDiscount.Location = new Point(325, 310);
            btnApplyDiscount.Name = "btnApplyDiscount";
            btnApplyDiscount.Size = new Size(100, 23);
            btnApplyDiscount.TabIndex = 8;
            btnApplyDiscount.Text = "Apply Discount";
            btnApplyDiscount.UseVisualStyleBackColor = true;
            btnApplyDiscount.Click += btnApplyDiscount_Click;
            // 
            // lblDiscountValue
            // 
            lblDiscountValue.AutoSize = true;
            lblDiscountValue.Location = new Point(187, 363);
            lblDiscountValue.Name = "lblDiscountValue";
            lblDiscountValue.Size = new Size(87, 15);
            lblDiscountValue.TabIndex = 9;
            lblDiscountValue.Text = "Discount: £0.00";
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Location = new Point(190, 407);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(66, 15);
            lblTotalValue.TabIndex = 10;
            lblTotalValue.Text = "Total: £0.00";
            // 
            // txtCardholderName
            // 
            txtCardholderName.Location = new Point(191, 455);
            txtCardholderName.Name = "txtCardholderName";
            txtCardholderName.Size = new Size(100, 23);
            txtCardholderName.TabIndex = 11;
            // 
            // txtCardNumber
            // 
            txtCardNumber.Location = new Point(190, 516);
            txtCardNumber.MaxLength = 23;
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(100, 23);
            txtCardNumber.TabIndex = 12;
            txtCardNumber.UseSystemPasswordChar = true;
            // 
            // btnConfirmBooking
            // 
            btnConfirmBooking.BackColor = Color.FromArgb(30, 100, 180);
            btnConfirmBooking.FlatStyle = FlatStyle.Flat;
            btnConfirmBooking.ForeColor = Color.White;
            btnConfirmBooking.Location = new Point(185, 604);
            btnConfirmBooking.Name = "btnConfirmBooking";
            btnConfirmBooking.Size = new Size(100, 23);
            btnConfirmBooking.TabIndex = 13;
            btnConfirmBooking.Text = "Pay and Book";
            btnConfirmBooking.UseVisualStyleBackColor = false;
            btnConfirmBooking.Click += btnConfirmBooking_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(319, 604);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 23);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblMessage
            // 
            lblMessage.ForeColor = Color.IndianRed;
            lblMessage.Location = new Point(191, 564);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(234, 23);
            lblMessage.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(125, 67);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 16;
            label1.Text = "Hotel:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(125, 111);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 17;
            label2.Text = "Room:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(125, 156);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 18;
            label3.Text = "Dates:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(60, 206);
            label4.Name = "label4";
            label4.Size = new Size(104, 15);
            label4.TabIndex = 19;
            label4.Text = "Number of nights:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(110, 259);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 20;
            label5.Text = "Subtotal:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(78, 313);
            label6.Name = "label6";
            label6.Size = new Size(86, 15);
            label6.TabIndex = 21;
            label6.Text = "Discount code:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(62, 458);
            label7.Name = "label7";
            label7.Size = new Size(102, 15);
            label7.TabIndex = 22;
            label7.Text = "Cardholder name:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(84, 519);
            label8.Name = "label8";
            label8.Size = new Size(80, 15);
            label8.TabIndex = 23;
            label8.Text = "Card number:";
            // 
            // BookingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(584, 661);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblMessage);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirmBooking);
            Controls.Add(txtCardNumber);
            Controls.Add(txtCardholderName);
            Controls.Add(lblTotalValue);
            Controls.Add(lblDiscountValue);
            Controls.Add(btnApplyDiscount);
            Controls.Add(txtDiscountCode);
            Controls.Add(lblSubtotalValue);
            Controls.Add(lblNightsValue);
            Controls.Add(lblDatesValue);
            Controls.Add(lblRoomValue);
            Controls.Add(lblHotelValue);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirm Booking";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblHotelValue;
        private Label lblRoomValue;
        private Label lblDatesValue;
        private Label lblNightsValue;
        private Label lblSubtotalValue;
        private TextBox txtDiscountCode;
        private Button btnApplyDiscount;
        private Label lblDiscountValue;
        private Label lblTotalValue;
        private TextBox txtCardholderName;
        private TextBox txtCardNumber;
        private Button btnConfirmBooking;
        private Button btnCancel;
        private Label lblMessage;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}