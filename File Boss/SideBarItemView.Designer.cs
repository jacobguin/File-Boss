namespace File_Boss
{
    partial class SideBarItemView
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
			components = new System.ComponentModel.Container();
			label1 = new Label();
			contextMenuStrip1 = new ContextMenuStrip(components);
			openWithToolStripMenuItem = new ToolStripMenuItem();
			deleteToolStripMenuItem = new ToolStripMenuItem();
			copyToolStripMenuItem = new ToolStripMenuItem();
			copyFileToolStripMenuItem = new ToolStripMenuItem();
			renameToolStripMenuItem = new ToolStripMenuItem();
			sendOverEmailToolStripMenuItem = new ToolStripMenuItem();
			propertiesToolStripMenuItem = new ToolStripMenuItem();
			pictureBox1 = new PictureBox();
			contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ContextMenuStrip = contextMenuStrip1;
			label1.Location = new Point(33, 8);
			label1.Name = "label1";
			label1.Size = new Size(50, 20);
			label1.TabIndex = 0;
			label1.Text = "label1";
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.BackColor = Color.FromArgb(64, 64, 64);
			contextMenuStrip1.ImageScalingSize = new Size(20, 20);
			contextMenuStrip1.Items.AddRange(new ToolStripItem[] { openWithToolStripMenuItem, deleteToolStripMenuItem, copyToolStripMenuItem, copyFileToolStripMenuItem, renameToolStripMenuItem, sendOverEmailToolStripMenuItem, propertiesToolStripMenuItem });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.ShowImageMargin = false;
			contextMenuStrip1.Size = new Size(186, 200);
			contextMenuStrip1.Opening += contextMenuStrip1_Opening;
			// 
			// openWithToolStripMenuItem
			// 
			openWithToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
			openWithToolStripMenuItem.ForeColor = Color.White;
			openWithToolStripMenuItem.Name = "openWithToolStripMenuItem";
			openWithToolStripMenuItem.Size = new Size(185, 24);
			openWithToolStripMenuItem.Text = "Open With";
			// 
			// deleteToolStripMenuItem
			// 
			deleteToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
			deleteToolStripMenuItem.ForeColor = Color.White;
			deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			deleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
			deleteToolStripMenuItem.Size = new Size(185, 24);
			deleteToolStripMenuItem.Text = "Delete";
			// 
			// copyToolStripMenuItem
			// 
			copyToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
			copyToolStripMenuItem.ForeColor = Color.White;
			copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			copyToolStripMenuItem.Size = new Size(185, 24);
			copyToolStripMenuItem.Text = "Copy File Path";
			copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
			// 
			// copyFileToolStripMenuItem
			// 
			copyFileToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
			copyFileToolStripMenuItem.ForeColor = Color.White;
			copyFileToolStripMenuItem.Name = "copyFileToolStripMenuItem";
			copyFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
			copyFileToolStripMenuItem.Size = new Size(185, 24);
			copyFileToolStripMenuItem.Text = "Copy";
			copyFileToolStripMenuItem.Click += copyToolStripMenuItem1_Click;
			// 
			// renameToolStripMenuItem
			// 
			renameToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
			renameToolStripMenuItem.ForeColor = Color.White;
			renameToolStripMenuItem.Name = "renameToolStripMenuItem";
			renameToolStripMenuItem.Size = new Size(185, 24);
			renameToolStripMenuItem.Text = "Rename";
			renameToolStripMenuItem.Click += renameToolStripMenuItem_Click;
			// 
			// sendOverEmailToolStripMenuItem
			// 
			sendOverEmailToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
			sendOverEmailToolStripMenuItem.ForeColor = Color.White;
			sendOverEmailToolStripMenuItem.Name = "sendOverEmailToolStripMenuItem";
			sendOverEmailToolStripMenuItem.Size = new Size(185, 24);
			sendOverEmailToolStripMenuItem.Text = "Send Over Email";
			sendOverEmailToolStripMenuItem.Click += sendOverEmailToolStripMenuItem_Click;
			// 
			// propertiesToolStripMenuItem
			// 
			propertiesToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
			propertiesToolStripMenuItem.ForeColor = Color.White;
			propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
			propertiesToolStripMenuItem.Size = new Size(185, 24);
			propertiesToolStripMenuItem.Text = "Properties";
			propertiesToolStripMenuItem.Click += propertiesToolStripMenuItem_Click;
			// 
			// pictureBox1
			// 
			pictureBox1.ContextMenuStrip = contextMenuStrip1;
			pictureBox1.Image = Properties.Resources.Folder_Icon;
			pictureBox1.Location = new Point(3, 3);
			pictureBox1.Margin = new Padding(3, 4, 3, 4);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(25, 29);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			// 
			// SideBarItemView
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ContextMenuStrip = contextMenuStrip1;
			Controls.Add(pictureBox1);
			Controls.Add(label1);
			Margin = new Padding(3, 4, 3, 4);
			Name = "SideBarItemView";
			Size = new Size(131, 36);
			contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private PictureBox pictureBox1;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem openWithToolStripMenuItem;
		private ToolStripMenuItem deleteToolStripMenuItem;
		private ToolStripMenuItem copyToolStripMenuItem;
		private ToolStripMenuItem copyFileToolStripMenuItem;
		private ToolStripMenuItem renameToolStripMenuItem;
		private ToolStripMenuItem sendOverEmailToolStripMenuItem;
		private ToolStripMenuItem propertiesToolStripMenuItem;
	}
}
