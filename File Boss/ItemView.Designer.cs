using File_Boss.Properties;

namespace File_Boss
{
	partial class ItemView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemView));
			pictureBox1 = new PictureBox();
			contextMenuStrip1 = new ContextMenuStrip(components);
			openWithToolStripMenuItem = new ToolStripMenuItem();
			deleteToolStripMenuItem = new ToolStripMenuItem();
			copyToolStripMenuItem = new ToolStripMenuItem();
			copyFileToolStripMenuItem = new ToolStripMenuItem();
			renameToolStripMenuItem = new ToolStripMenuItem();
			sendOverEmailToolStripMenuItem = new ToolStripMenuItem();
			propertiesToolStripMenuItem = new ToolStripMenuItem();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// pictureBox1
			// 
			pictureBox1.BackColor = SystemColors.Control;
			pictureBox1.BackgroundImageLayout = ImageLayout.None;
			pictureBox1.ContextMenuStrip = contextMenuStrip1;
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(18, 13);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(72, 72);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 2;
			pictureBox1.TabStop = false;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.ImageScalingSize = new Size(20, 20);
			contextMenuStrip1.Items.AddRange(new ToolStripItem[] { openWithToolStripMenuItem, deleteToolStripMenuItem, copyToolStripMenuItem, copyFileToolStripMenuItem, renameToolStripMenuItem, sendOverEmailToolStripMenuItem, propertiesToolStripMenuItem });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(211, 200);
			contextMenuStrip1.Opening += contextMenuStrip1_Opening;
			// 
			// openWithToolStripMenuItem
			// 
			openWithToolStripMenuItem.Name = "openWithToolStripMenuItem";
			openWithToolStripMenuItem.Size = new Size(210, 24);
			openWithToolStripMenuItem.Text = "Open With";
			// 
			// deleteToolStripMenuItem
			// 
			deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			deleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
			deleteToolStripMenuItem.Size = new Size(210, 24);
			deleteToolStripMenuItem.Text = "Delete";
			deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
			// 
			// copyToolStripMenuItem
			// 
			copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			copyToolStripMenuItem.Size = new Size(210, 24);
			copyToolStripMenuItem.Text = "Copy File Path";
			copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
			// 
			// copyFileToolStripMenuItem
			// 
			copyFileToolStripMenuItem.Name = "copyFileToolStripMenuItem";
			copyFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
			copyFileToolStripMenuItem.Size = new Size(210, 24);
			copyFileToolStripMenuItem.Text = "Copy";
			copyFileToolStripMenuItem.Click += copyToolStripMenuItem1_Click;
			// 
			// renameToolStripMenuItem
			// 
			renameToolStripMenuItem.Name = "renameToolStripMenuItem";
			renameToolStripMenuItem.Size = new Size(210, 24);
			renameToolStripMenuItem.Text = "Rename";
			renameToolStripMenuItem.Click += renameToolStripMenuItem_Click;
			// 
			// sendOverEmailToolStripMenuItem
			// 
			sendOverEmailToolStripMenuItem.Name = "sendOverEmailToolStripMenuItem";
			sendOverEmailToolStripMenuItem.Size = new Size(210, 24);
			sendOverEmailToolStripMenuItem.Text = "Send Over Email";
			sendOverEmailToolStripMenuItem.Click += sendOverEmailToolStripMenuItem_Click;
			// 
			// propertiesToolStripMenuItem
			// 
			propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
			propertiesToolStripMenuItem.Size = new Size(210, 24);
			propertiesToolStripMenuItem.Text = "Properties";
			propertiesToolStripMenuItem.Click += propertiesToolStripMenuItem_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ContextMenuStrip = contextMenuStrip1;
			label1.Location = new Point(18, 97);
			label1.Name = "label1";
			label1.Size = new Size(50, 20);
			label1.TabIndex = 3;
			label1.Text = "label1";
			// 
			// ItemView
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(pictureBox1);
			Controls.Add(label1);
			Name = "ItemView";
			Size = new Size(109, 137);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public PictureBox pictureBox1;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem openWithToolStripMenuItem;
		private ToolStripMenuItem deleteToolStripMenuItem;
		public Label label1;
        private ToolStripMenuItem renameToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
		private ToolStripMenuItem copyFileToolStripMenuItem;
		private ToolStripMenuItem propertiesToolStripMenuItem;
		private ToolStripMenuItem sendOverEmailToolStripMenuItem;
	}
}
