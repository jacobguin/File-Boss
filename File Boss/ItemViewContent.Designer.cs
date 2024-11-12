using File_Boss.Properties;

namespace File_Boss
{
	partial class ItemViewContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemViewContent));
            contextMenuStrip1 = new ContextMenuStrip(components);
            openWithToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            copyFileToolStripMenuItem = new ToolStripMenuItem();
            renameToolStripMenuItem = new ToolStripMenuItem();
            sendOverEmailToolStripMenuItem = new ToolStripMenuItem();
            propertiesToolStripMenuItem = new ToolStripMenuItem();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { openWithToolStripMenuItem, deleteToolStripMenuItem, copyToolStripMenuItem, copyFileToolStripMenuItem, renameToolStripMenuItem, sendOverEmailToolStripMenuItem, propertiesToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.ShowImageMargin = false;
            contextMenuStrip1.Size = new Size(136, 158);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // openWithToolStripMenuItem
            // 
            openWithToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
            openWithToolStripMenuItem.ForeColor = Color.White;
            openWithToolStripMenuItem.Name = "openWithToolStripMenuItem";
            openWithToolStripMenuItem.Size = new Size(135, 22);
            openWithToolStripMenuItem.Text = "Open With";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
            deleteToolStripMenuItem.ForeColor = Color.White;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
            deleteToolStripMenuItem.Size = new Size(135, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
            copyToolStripMenuItem.ForeColor = Color.White;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(135, 22);
            copyToolStripMenuItem.Text = "Copy File Path";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // copyFileToolStripMenuItem
            // 
            copyFileToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
            copyFileToolStripMenuItem.ForeColor = Color.White;
            copyFileToolStripMenuItem.Name = "copyFileToolStripMenuItem";
            copyFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyFileToolStripMenuItem.Size = new Size(135, 22);
            copyFileToolStripMenuItem.Text = "Copy";
            copyFileToolStripMenuItem.Click += copyToolStripMenuItem1_Click;
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
            renameToolStripMenuItem.ForeColor = Color.White;
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Size = new Size(135, 22);
            renameToolStripMenuItem.Text = "Rename";
            renameToolStripMenuItem.Click += renameToolStripMenuItem_Click;
            // 
            // sendOverEmailToolStripMenuItem
            // 
            sendOverEmailToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
            sendOverEmailToolStripMenuItem.ForeColor = Color.White;
            sendOverEmailToolStripMenuItem.Name = "sendOverEmailToolStripMenuItem";
            sendOverEmailToolStripMenuItem.Size = new Size(135, 22);
            sendOverEmailToolStripMenuItem.Text = "Send Over Email";
            sendOverEmailToolStripMenuItem.Click += sendOverEmailToolStripMenuItem_Click;
            // 
            // propertiesToolStripMenuItem
            // 
            propertiesToolStripMenuItem.BackColor = Color.FromArgb(64, 64, 64);
            propertiesToolStripMenuItem.ForeColor = Color.White;
            propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            propertiesToolStripMenuItem.Size = new Size(135, 22);
            propertiesToolStripMenuItem.Text = "Properties";
            propertiesToolStripMenuItem.Click += propertiesToolStripMenuItem_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.ContextMenuStrip = contextMenuStrip1;
            label3.ForeColor = Color.FromArgb(46, 204, 113);
            label3.Location = new Point(305, 2);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 5;
            label3.Text = "Date modified:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.ContextMenuStrip = contextMenuStrip1;
            label4.ForeColor = Color.FromArgb(46, 204, 113);
            label4.Location = new Point(305, 21);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 6;
            label4.Text = "Size:";
            label4.Visible = false;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.ContextMenuStrip = contextMenuStrip1;
            label6.ForeColor = Color.White;
            label6.Location = new Point(396, 2);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 8;
            label6.Text = "label6";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.ContextMenuStrip = contextMenuStrip1;
            label7.ForeColor = Color.White;
            label7.Location = new Point(335, 21);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 9;
            label7.Text = "label7";
            label7.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(34, 34, 34);
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.ContextMenuStrip = contextMenuStrip1;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 2);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 34);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ContextMenuStrip = contextMenuStrip1;
            label1.ForeColor = Color.White;
            label1.Location = new Point(47, 2);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 11;
            label1.Text = "label1";
            // 
            // ItemViewContent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ItemViewContent";
            Size = new Size(551, 39);
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem openWithToolStripMenuItem;
		private ToolStripMenuItem deleteToolStripMenuItem;
		public Label label1;
        private ToolStripMenuItem renameToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
		private ToolStripMenuItem copyFileToolStripMenuItem;
		private ToolStripMenuItem propertiesToolStripMenuItem;
		private ToolStripMenuItem sendOverEmailToolStripMenuItem;
		public Label label3;
		public Label label4;
		public Label label6;
		public Label label7;
		public PictureBox pictureBox1;
	}
}
