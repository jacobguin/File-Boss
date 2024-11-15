using MetroFramework.Controls;

namespace File_Boss
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			tabControl1 = new MetroTabControl();
			SuspendLayout();
			// 
			// tabControl1
			// 
			tabControl1.Dock = DockStyle.Fill;
			tabControl1.Font = new Font("Segoe UI", 8F);
			tabControl1.HotTrack = true;
			tabControl1.Location = new Point(0, 0);
			tabControl1.Margin = new Padding(3, 3, 30, 3);
			tabControl1.Name = "tabControl1";
			tabControl1.Padding = new Point(6, 8);
			tabControl1.Size = new Size(914, 601);
			tabControl1.Style = MetroFramework.MetroColorStyle.Green;
			tabControl1.TabIndex = 0;
			tabControl1.Theme = MetroFramework.MetroThemeStyle.Dark;
			tabControl1.UseSelectable = true;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(34, 34, 34);
			ClientSize = new Size(914, 601);
			Controls.Add(tabControl1);
			ForeColor = Color.White;
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			ResumeLayout(false);
		}

		#endregion
		private ToolStripMenuItem toolStripMenuItem1;
		private MetroTabControl tabControl1;
	}
}
