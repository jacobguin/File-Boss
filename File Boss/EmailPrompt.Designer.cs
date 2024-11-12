namespace File_Boss
{
	partial class EmailPrompt
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
            SendTotextBox = new TextBox();
            label1 = new Label();
            label3 = new Label();
            SubjecttextBox2 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // SendTotextBox
            // 
            SendTotextBox.BackColor = Color.FromArgb(64, 64, 64);
            SendTotextBox.BorderStyle = BorderStyle.None;
            SendTotextBox.ForeColor = Color.White;
            SendTotextBox.Location = new Point(10, 26);
            SendTotextBox.Margin = new Padding(3, 2, 3, 2);
            SendTotextBox.Name = "SendTotextBox";
            SendTotextBox.Size = new Size(275, 16);
            SendTotextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 1;
            label1.Text = "Send To: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 52);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 5;
            label3.Text = "Subject: ";
            // 
            // SubjecttextBox2
            // 
            SubjecttextBox2.BackColor = Color.FromArgb(64, 64, 64);
            SubjecttextBox2.BorderStyle = BorderStyle.None;
            SubjecttextBox2.Location = new Point(10, 70);
            SubjecttextBox2.Margin = new Padding(3, 2, 3, 2);
            SubjecttextBox2.Name = "SubjecttextBox2";
            SubjecttextBox2.Size = new Size(275, 16);
            SubjecttextBox2.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(46, 204, 113);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Black;
            button1.ImageAlign = ContentAlignment.TopLeft;
            button1.Location = new Point(12, 103);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(273, 38);
            button1.TabIndex = 6;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // EmailPrompt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(296, 153);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(SubjecttextBox2);
            Controls.Add(label1);
            Controls.Add(SendTotextBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "EmailPrompt";
            Text = "Email Infomation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SendTotextBox;
		private Label label1;
		private Label label3;
		private TextBox SubjecttextBox2;
		private Button button1;
	}
}