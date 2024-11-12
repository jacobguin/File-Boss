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
            homepage1 = new Homepage();
            button3 = new Button();
            listBoxResults = new ListBox();
            textBox1 = new TextBox();
            homeButton = new Button();
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
            pathText.Location = new Point(194, 14);
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
            flowLayoutPanel1.Location = new Point(145, 50);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(784, 567);
            flowLayoutPanel1.TabIndex = 9;
            flowLayoutPanel1.MouseClick += flowLayoutPanel1_MouseClick;
            // 
            // homepage1
            // 
            homepage1.functionHandler = null;
            homepage1.Location = new Point(148, 50);
            homepage1.Name = "homepage1";
            homepage1.Size = new Size(781, 541);
            homepage1.TabIndex = 12;
            homepage1.Visible = false;
            // 
            // button3
            // 
            button3.BackColor = Color.CornflowerBlue;
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Zoom;
            button3.ImageAlign = ContentAlignment.TopLeft;
            button3.Location = new Point(145, 0);
            button3.Margin = new Padding(3, 5, 3, 5);
            button3.Name = "button3";
            button3.Padding = new Padding(2);
            button3.Size = new Size(43, 43);
            button3.TabIndex = 10;
            button3.TextImageRelation = TextImageRelation.TextAboveImage;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // listBoxResults
            // 
            listBoxResults.FormattingEnabled = true;
            listBoxResults.Location = new Point(641, 31);
            listBoxResults.Name = "listBoxResults";
            listBoxResults.Size = new Size(158, 144);
            listBoxResults.TabIndex = 10;
            listBoxResults.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(641, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(158, 27);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // homeButton
            // 
            homeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            homeButton.BackColor = Color.CornflowerBlue;
            homeButton.BackgroundImage = (Image)resources.GetObject("homeButton.BackgroundImage");
            homeButton.BackgroundImageLayout = ImageLayout.Zoom;
            homeButton.ImageAlign = ContentAlignment.TopLeft;
            homeButton.Location = new Point(886, 3);
            homeButton.Margin = new Padding(3, 5, 3, 5);
            homeButton.Name = "homeButton";
            homeButton.Padding = new Padding(2);
            homeButton.Size = new Size(43, 43);
            homeButton.TabIndex = 11;
            homeButton.TextImageRelation = TextImageRelation.TextAboveImage;
            homeButton.UseVisualStyleBackColor = false;
            homeButton.Click += homeButton_Click;
            // 
            // TabUI
            // 
            Controls.Add(homepage1);
            Controls.Add(homeButton);
            Controls.Add(button3);
            Controls.Add(listBoxResults);
            Controls.Add(textBox1);
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
        private TextBox textBox1;
        private ListBox listBoxResults;
		private Button button3;
        private Button homeButton;
        private Homepage homepage1;
    }
}
