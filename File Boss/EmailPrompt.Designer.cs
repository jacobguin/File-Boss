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
			SendTotextBox.Location = new Point(12, 35);
			SendTotextBox.Name = "SendTotextBox";
			SendTotextBox.Size = new Size(314, 27);
			SendTotextBox.TabIndex = 2;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(14, 11);
			label1.Name = "label1";
			label1.Size = new Size(69, 20);
			label1.TabIndex = 1;
			label1.Text = "Send To: ";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(14, 69);
			label3.Name = "label3";
			label3.Size = new Size(65, 20);
			label3.TabIndex = 5;
			label3.Text = "Subject: ";
			// 
			// SubjecttextBox2
			// 
			SubjecttextBox2.Location = new Point(12, 93);
			SubjecttextBox2.Name = "SubjecttextBox2";
			SubjecttextBox2.Size = new Size(314, 27);
			SubjecttextBox2.TabIndex = 3;
			// 
			// button1
			// 
			button1.Location = new Point(14, 137);
			button1.Name = "button1";
			button1.Size = new Size(312, 50);
			button1.TabIndex = 6;
			button1.Text = "Submit";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// EmailPrompt
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(338, 204);
			Controls.Add(button1);
			Controls.Add(label3);
			Controls.Add(SubjecttextBox2);
			Controls.Add(label1);
			Controls.Add(SendTotextBox);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
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