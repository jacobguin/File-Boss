namespace File_Boss
{
	partial class EmailLogin
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
            label4 = new Label();
            PasswordtextBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            FromtextBox1 = new TextBox();
            label1 = new Label();
            DisplayNametextBox = new TextBox();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(12, 54);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 15;
            label4.Text = "Password: ";
            // 
            // PasswordtextBox1
            // 
            PasswordtextBox1.BackColor = Color.FromArgb(64, 64, 64);
            PasswordtextBox1.BorderStyle = BorderStyle.None;
            PasswordtextBox1.ForeColor = Color.White;
            PasswordtextBox1.Location = new Point(10, 72);
            PasswordtextBox1.Margin = new Padding(3, 2, 3, 2);
            PasswordtextBox1.Name = "PasswordtextBox1";
            PasswordtextBox1.PasswordChar = '*';
            PasswordtextBox1.Size = new Size(275, 16);
            PasswordtextBox1.TabIndex = 10;
            PasswordtextBox1.WordWrap = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(46, 204, 113);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(10, 181);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(273, 38);
            button1.TabIndex = 14;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 10);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 13;
            label2.Text = "Email: ";
            // 
            // FromtextBox1
            // 
            FromtextBox1.BackColor = Color.FromArgb(64, 64, 64);
            FromtextBox1.BorderStyle = BorderStyle.None;
            FromtextBox1.ForeColor = Color.White;
            FromtextBox1.Location = new Point(10, 28);
            FromtextBox1.Margin = new Padding(3, 2, 3, 2);
            FromtextBox1.Name = "FromtextBox1";
            FromtextBox1.Size = new Size(275, 16);
            FromtextBox1.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 101);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 11;
            label1.Text = "Display Name: ";
            // 
            // DisplayNametextBox
            // 
            DisplayNametextBox.BackColor = Color.FromArgb(64, 64, 64);
            DisplayNametextBox.BorderStyle = BorderStyle.None;
            DisplayNametextBox.ForeColor = Color.White;
            DisplayNametextBox.Location = new Point(10, 119);
            DisplayNametextBox.Margin = new Padding(3, 2, 3, 2);
            DisplayNametextBox.Name = "DisplayNametextBox";
            DisplayNametextBox.Size = new Size(275, 16);
            DisplayNametextBox.TabIndex = 12;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.FromArgb(46, 204, 113);
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.FromArgb(46, 204, 113);
            linkLabel1.Location = new Point(14, 143);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(86, 15);
            linkLabel1.TabIndex = 16;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Add Gmail app";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // EmailLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(296, 227);
            Controls.Add(linkLabel1);
            Controls.Add(label4);
            Controls.Add(PasswordtextBox1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(FromtextBox1);
            Controls.Add(label1);
            Controls.Add(DisplayNametextBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 2, 3, 2);
            Name = "EmailLogin";
            Text = "Email Info";
            Load += EmailLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
		private TextBox PasswordtextBox1;
		private Button button1;
		private Label label2;
		private TextBox FromtextBox1;
		private Label label1;
		private TextBox DisplayNametextBox;
		private LinkLabel linkLabel1;
	}
}