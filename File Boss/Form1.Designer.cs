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
			components = new System.ComponentModel.Container();
			flowLayoutPanel1 = new FlowLayoutPanel();
			contextMenuStrip1 = new ContextMenuStrip(components);
			undoToolStripMenuItem = new ToolStripMenuItem();
			button1 = new Button();
			button2 = new Button();
			pathText = new Label();
			backButton = new Button();
			emailSettingsToolStripMenuItem = new ToolStripMenuItem();
			emailSettingsToolStripMenuItem = new ToolStripMenuItem();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			flowLayoutPanel1.AutoScroll = true;
			flowLayoutPanel1.ContextMenuStrip = contextMenuStrip1;
			flowLayoutPanel1.Location = new Point(0, 72);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(914, 529);
			flowLayoutPanel1.TabIndex = 0;
			flowLayoutPanel1.DragDrop += flowLayoutPanel1_DragDrop;
			flowLayoutPanel1.DragEnter += flowLayoutPanel1_DragEnter;
			flowLayoutPanel1.AutoScroll = true;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.ImageScalingSize = new Size(20, 20);
			contextMenuStrip1.Items.AddRange(new ToolStripItem[] { undoToolStripMenuItem, emailSettingsToolStripMenuItem });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(211, 80);
			// 
			// undoToolStripMenuItem
			// 
			undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			undoToolStripMenuItem.Size = new Size(210, 24);
			undoToolStripMenuItem.Text = "Undo";
			undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
			// 
			// button1
			// 
			button1.BackColor = Color.CornflowerBlue;
			button1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			button1.Location = new Point(0, 0);
			button1.Margin = new Padding(3, 4, 3, 4);
			button1.Name = "button1";
			button1.Size = new Size(82, 64);
			button1.TabIndex = 1;
			button1.Text = "+";
			button1.UseVisualStyleBackColor = false;
			button1.Click += button1_Click;
			button1.MouseEnter += button1_MouseEnter;
			button1.MouseLeave += button1_MouseLeave;
			// 
			// button2
			// 
			button2.BackColor = Color.FromArgb(0, 192, 0);
			button2.Location = new Point(101, 0);
			button2.Margin = new Padding(3, 5, 3, 5);
			button2.Name = "button2";
			button2.Size = new Size(82, 64);
			button2.TabIndex = 2;
			button2.Text = "New Folder";
			button2.UseVisualStyleBackColor = false;
			button2.Click += button2_Click;
			// 
			// pathText
			// 
			pathText.AutoSize = true;
			pathText.Location = new Point(250, 24);
			pathText.Name = "pathText";
			pathText.Size = new Size(50, 20);
			pathText.TabIndex = 3;
			pathText.Text = "label1";
			// 
			// backButton
			// 
			backButton.BackColor = Color.DarkGray;
			backButton.FlatAppearance.BorderSize = 0;
			backButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			backButton.Location = new Point(9, 20);
			backButton.Name = "backButton";
			backButton.Size = new Size(38, 29);
			backButton.TabIndex = 4;
			backButton.Text = "<";
			backButton.UseVisualStyleBackColor = false;
			backButton.Click += backButton_Click;
			// 
			// emailSettingsToolStripMenuItem
			// 
			emailSettingsToolStripMenuItem.Name = "emailSettingsToolStripMenuItem";
			emailSettingsToolStripMenuItem.Size = new Size(210, 24);
			emailSettingsToolStripMenuItem.Text = "Email Settings";
			emailSettingsToolStripMenuItem.Click += emailSettingsToolStripMenuItem_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(914, 601);
			Controls.Add(backButton);
			Controls.Add(pathText);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(flowLayoutPanel1);
			Name = "Form1";
			Text = "Form1";
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
        private Button button2;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private Label pathText;
        private Button backButton;
		private ToolStripMenuItem emailSettingsToolStripMenuItem;
	}
}
