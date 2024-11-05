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
			label4.Location = new Point(14, 72);
			label4.Name = "label4";
			label4.Size = new Size(77, 20);
			label4.TabIndex = 15;
			label4.Text = "Password: ";
			// 
			// PasswordtextBox1
			// 
			PasswordtextBox1.Location = new Point(12, 96);
			PasswordtextBox1.Name = "PasswordtextBox1";
			PasswordtextBox1.PasswordChar = '*';
			PasswordtextBox1.Size = new Size(314, 27);
			PasswordtextBox1.TabIndex = 10;
			PasswordtextBox1.WordWrap = false;
			// 
			// button1
			// 
			button1.Location = new Point(12, 241);
			button1.Name = "button1";
			button1.Size = new Size(312, 50);
			button1.TabIndex = 14;
			button1.Text = "Save";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(14, 14);
			label2.Name = "label2";
			label2.Size = new Size(53, 20);
			label2.TabIndex = 13;
			label2.Text = "Email: ";
			// 
			// FromtextBox1
			// 
			FromtextBox1.Location = new Point(12, 38);
			FromtextBox1.Name = "FromtextBox1";
			FromtextBox1.Size = new Size(314, 27);
			FromtextBox1.TabIndex = 9;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(14, 135);
			label1.Name = "label1";
			label1.Size = new Size(109, 20);
			label1.TabIndex = 11;
			label1.Text = "Display Name: ";
			// 
			// DisplayNametextBox
			// 
			DisplayNametextBox.Location = new Point(12, 159);
			DisplayNametextBox.Name = "DisplayNametextBox";
			DisplayNametextBox.Size = new Size(314, 27);
			DisplayNametextBox.TabIndex = 12;
			// 
			// linkLabel1
			// 
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new Point(16, 191);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new Size(110, 20);
			linkLabel1.TabIndex = 16;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Add Gmail app";
			linkLabel1.LinkClicked += linkLabel1_LinkClicked;
			// 
			// EmailLogin
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(338, 303);
			Controls.Add(linkLabel1);
			Controls.Add(label4);
			Controls.Add(PasswordtextBox1);
			Controls.Add(button1);
			Controls.Add(label2);
			Controls.Add(FromtextBox1);
			Controls.Add(label1);
			Controls.Add(DisplayNametextBox);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "EmailLogin";
			Text = "Email Info";
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