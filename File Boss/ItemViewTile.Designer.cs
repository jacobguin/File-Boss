using File_Boss.Properties;

namespace File_Boss
{
	partial class ItemViewTile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemViewTile));
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
            pictureBox1.BackColor = Color.FromArgb(34, 34, 34);
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.ContextMenuStrip = contextMenuStrip1;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(16, 10);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(63, 54);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { openWithToolStripMenuItem, deleteToolStripMenuItem, copyToolStripMenuItem, copyFileToolStripMenuItem, renameToolStripMenuItem, sendOverEmailToolStripMenuItem, propertiesToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 180);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // openWithToolStripMenuItem
            // 
            openWithToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
            openWithToolStripMenuItem.ForeColor = Color.White;
            openWithToolStripMenuItem.Name = "openWithToolStripMenuItem";
            openWithToolStripMenuItem.Size = new Size(180, 22);
            openWithToolStripMenuItem.Text = "Open With";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
            deleteToolStripMenuItem.ForeColor = Color.White;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
            deleteToolStripMenuItem.Size = new Size(180, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
            copyToolStripMenuItem.ForeColor = Color.White;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(180, 22);
            copyToolStripMenuItem.Text = "Copy File Path";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // copyFileToolStripMenuItem
            // 
            copyFileToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
            copyFileToolStripMenuItem.ForeColor = Color.White;
            copyFileToolStripMenuItem.Name = "copyFileToolStripMenuItem";
            copyFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyFileToolStripMenuItem.Size = new Size(180, 22);
            copyFileToolStripMenuItem.Text = "Copy";
            copyFileToolStripMenuItem.Click += copyToolStripMenuItem1_Click;
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
            renameToolStripMenuItem.ForeColor = Color.White;
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Size = new Size(180, 22);
            renameToolStripMenuItem.Text = "Rename";
            renameToolStripMenuItem.Click += renameToolStripMenuItem_Click;
            // 
            // sendOverEmailToolStripMenuItem
            // 
            sendOverEmailToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
            sendOverEmailToolStripMenuItem.ForeColor = Color.White;
            sendOverEmailToolStripMenuItem.Name = "sendOverEmailToolStripMenuItem";
            sendOverEmailToolStripMenuItem.Size = new Size(180, 22);
            sendOverEmailToolStripMenuItem.Text = "Send Over Email";
            sendOverEmailToolStripMenuItem.Click += sendOverEmailToolStripMenuItem_Click;
            // 
            // propertiesToolStripMenuItem
            // 
            propertiesToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
            propertiesToolStripMenuItem.ForeColor = Color.White;
            propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            propertiesToolStripMenuItem.Size = new Size(180, 22);
            propertiesToolStripMenuItem.Text = "Properties";
            propertiesToolStripMenuItem.Click += propertiesToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ContextMenuStrip = contextMenuStrip1;
            label1.ForeColor = Color.White;
            label1.Location = new Point(16, 73);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // ItemViewTile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ItemViewTile";
            Size = new Size(95, 103);
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
