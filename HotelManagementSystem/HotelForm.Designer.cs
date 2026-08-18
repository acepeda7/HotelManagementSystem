namespace HotelManagementSystem
{
    partial class HotelForm
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
            txtHotelName = new TextBox();
            txtHotelAddress = new TextBox();
            nudStarRating = new NumericUpDown();
            txtHotelDescription = new TextBox();
            btnSaveHotel = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblMessage = new Label();
            ((System.ComponentModel.ISupportInitialize)nudStarRating).BeginInit();
            SuspendLayout();
            // 
            // txtHotelName
            // 
            txtHotelName.Location = new Point(206, 122);
            txtHotelName.Name = "txtHotelName";
            txtHotelName.Size = new Size(240, 23);
            txtHotelName.TabIndex = 0;
            // 
            // txtHotelAddress
            // 
            txtHotelAddress.Location = new Point(206, 184);
            txtHotelAddress.Name = "txtHotelAddress";
            txtHotelAddress.Size = new Size(240, 23);
            txtHotelAddress.TabIndex = 1;
            // 
            // nudStarRating
            // 
            nudStarRating.Location = new Point(206, 246);
            nudStarRating.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            nudStarRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudStarRating.Name = "nudStarRating";
            nudStarRating.Size = new Size(240, 23);
            nudStarRating.TabIndex = 2;
            nudStarRating.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // txtHotelDescription
            // 
            txtHotelDescription.Location = new Point(206, 312);
            txtHotelDescription.Multiline = true;
            txtHotelDescription.Name = "txtHotelDescription";
            txtHotelDescription.ScrollBars = ScrollBars.Vertical;
            txtHotelDescription.Size = new Size(240, 23);
            txtHotelDescription.TabIndex = 3;
            // 
            // btnSaveHotel
            // 
            btnSaveHotel.Location = new Point(97, 436);
            btnSaveHotel.Name = "btnSaveHotel";
            btnSaveHotel.Size = new Size(145, 23);
            btnSaveHotel.TabIndex = 4;
            btnSaveHotel.Text = "Save Hotel";
            btnSaveHotel.UseVisualStyleBackColor = true;
            btnSaveHotel.Click += btnSaveHotel_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(301, 436);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(145, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(97, 125);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 6;
            label1.Text = "Hotel name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(117, 187);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 7;
            label2.Text = "Address:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(105, 248);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 8;
            label3.Text = "Star rating:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(99, 315);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 9;
            label4.Text = "Description:";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(97, 383);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 15);
            lblMessage.TabIndex = 10;
            // 
            // HotelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(534, 511);
            Controls.Add(lblMessage);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveHotel);
            Controls.Add(txtHotelDescription);
            Controls.Add(nudStarRating);
            Controls.Add(txtHotelAddress);
            Controls.Add(txtHotelName);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HotelForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Hotel Profile";
            ((System.ComponentModel.ISupportInitialize)nudStarRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtHotelName;
        private TextBox txtHotelAddress;
        private NumericUpDown nudStarRating;
        private TextBox txtHotelDescription;
        private Button btnSaveHotel;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblMessage;
    }
}