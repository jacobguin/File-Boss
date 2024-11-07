namespace File_Boss
{
	partial class TabUI
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabUI));
			contextMenuStrip1 = new ContextMenuStrip(components);
			undoToolStripMenuItem = new ToolStripMenuItem();
			pasteToolStripMenuItem = new ToolStripMenuItem();
			emailSettingsToolStripMenuItem1 = new ToolStripMenuItem();
			backButton = new Button();
			pathText = new Label();
			button2 = new Button();
			button1 = new Button();
			flowLayoutPanel1 = new FlowLayoutPanel();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.ImageScalingSize = new Size(20, 20);
			contextMenuStrip1.Items.AddRange(new ToolStripItem[] { undoToolStripMenuItem, pasteToolStripMenuItem, emailSettingsToolStripMenuItem1 });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(173, 76);
			// 
			// undoToolStripMenuItem
			// 
			undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
			undoToolStripMenuItem.Size = new Size(172, 24);
			undoToolStripMenuItem.Text = "Undo";
			undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
			// 
			// pasteToolStripMenuItem
			// 
			pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
			pasteToolStripMenuItem.Size = new Size(172, 24);
			pasteToolStripMenuItem.Text = "Paste";
			pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
			// 
			// emailSettingsToolStripMenuItem1
			// 
			emailSettingsToolStripMenuItem1.Name = "emailSettingsToolStripMenuItem1";
			emailSettingsToolStripMenuItem1.Size = new Size(172, 24);
			emailSettingsToolStripMenuItem1.Text = "Email Settings";
			emailSettingsToolStripMenuItem1.Click += emailSettingsToolStripMenuItem1_Click;
			// 
			// backButton
			// 
			backButton.BackColor = Color.DarkGray;
			backButton.FlatAppearance.BorderSize = 0;
			backButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			backButton.Location = new Point(3, 14);
			backButton.Name = "backButton";
			backButton.Size = new Size(38, 29);
			backButton.TabIndex = 8;
			backButton.Text = "<";
			backButton.UseVisualStyleBackColor = false;
			backButton.Click += backButton_Click;
			// 
			// pathText
			// 
			pathText.AutoSize = true;
			pathText.BackColor = SystemColors.ControlLight;
			pathText.BorderStyle = BorderStyle.Fixed3D;
			pathText.Location = new Point(145, 14);
			pathText.Name = "pathText";
			pathText.Padding = new Padding(3);
			pathText.Size = new Size(58, 28);
			pathText.TabIndex = 7;
			pathText.Text = "label1";
			// 
			// button2
			// 
			button2.BackColor = Color.CornflowerBlue;
			button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
			button2.BackgroundImageLayout = ImageLayout.Zoom;
			button2.ImageAlign = ContentAlignment.TopLeft;
			button2.Location = new Point(96, 0);
			button2.Margin = new Padding(3, 5, 3, 5);
			button2.Name = "button2";
			button2.Padding = new Padding(2);
			button2.Size = new Size(43, 43);
			button2.TabIndex = 6;
			button2.TextImageRelation = TextImageRelation.TextAboveImage;
			button2.UseVisualStyleBackColor = false;
			button2.Click += button2_Click;
			// 
			// button1
			// 
			button1.BackColor = Color.CornflowerBlue;
			button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
			button1.BackgroundImageLayout = ImageLayout.Zoom;
			button1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			button1.Location = new Point(47, 0);
			button1.Margin = new Padding(3, 4, 3, 4);
			button1.Name = "button1";
			button1.Padding = new Padding(2);
			button1.Size = new Size(43, 43);
			button1.TabIndex = 5;
			button1.UseVisualStyleBackColor = false;
			button1.Click += button1_Click;
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.AllowDrop = true;
			flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			flowLayoutPanel1.AutoScroll = true;
			flowLayoutPanel1.ContextMenuStrip = contextMenuStrip1;
			flowLayoutPanel1.Location = new Point(3, 51);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(926, 566);
			flowLayoutPanel1.TabIndex = 9;
			flowLayoutPanel1.MouseClick += flowLayoutPanel1_MouseClick;
			// 
			// TabUI
			// 
			Controls.Add(flowLayoutPanel1);
			Controls.Add(backButton);
			Controls.Add(pathText);
			Controls.Add(button2);
			Controls.Add(button1);
			Name = "TabUI";
			Size = new Size(932, 620);
			Load += TabUI_Load;
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem undoToolStripMenuItem;
		private ToolStripMenuItem pasteToolStripMenuItem;
		private ToolStripMenuItem emailSettingsToolStripMenuItem1;
		private Button backButton;
		private Label pathText;
		private Button button2;
		private Button button1;
		private FlowLayoutPanel flowLayoutPanel1;
	}
}
