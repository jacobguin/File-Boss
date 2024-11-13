namespace File_Boss
{
    partial class Homepage
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			flowLayoutPanel1 = new FlowLayoutPanel();
			flowLayoutPanel2 = new FlowLayoutPanel();
			flowLayoutPanel3 = new FlowLayoutPanel();
			flowLayoutPanel3.SuspendLayout();
			SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.AutoScroll = true;
			flowLayoutPanel1.AutoSize = true;
			flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			flowLayoutPanel1.BackColor = SystemColors.Control;
			flowLayoutPanel1.Dock = DockStyle.Top;
			flowLayoutPanel1.Location = new Point(3, 3);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(0, 0);
			flowLayoutPanel1.TabIndex = 0;
			// 
			// flowLayoutPanel2
			// 
			flowLayoutPanel2.AutoScroll = true;
			flowLayoutPanel2.AutoSize = true;
			flowLayoutPanel2.BackColor = SystemColors.Control;
			flowLayoutPanel2.Dock = DockStyle.Bottom;
			flowLayoutPanel2.Location = new Point(3, 9);
			flowLayoutPanel2.Name = "flowLayoutPanel2";
			flowLayoutPanel2.Size = new Size(0, 0);
			flowLayoutPanel2.TabIndex = 1;
			// 
			// flowLayoutPanel3
			// 
			flowLayoutPanel3.AutoSize = true;
			flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			flowLayoutPanel3.Controls.Add(flowLayoutPanel1);
			flowLayoutPanel3.Controls.Add(flowLayoutPanel2);
			flowLayoutPanel3.Dock = DockStyle.Fill;
			flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
			flowLayoutPanel3.Location = new Point(0, 0);
			flowLayoutPanel3.Name = "flowLayoutPanel3";
			flowLayoutPanel3.Size = new Size(932, 620);
			flowLayoutPanel3.TabIndex = 2;
			// 
			// Homepage
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(flowLayoutPanel3);
			Name = "Homepage";
			Size = new Size(932, 620);
			flowLayoutPanel3.ResumeLayout(false);
			flowLayoutPanel3.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
		private FlowLayoutPanel flowLayoutPanel3;
	}
}
