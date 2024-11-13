namespace File_Boss
{
    partial class File_Properties_Form
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            location = new Label();
            fileType = new Label();
            fileSize = new Label();
            fileName = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 84);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(152, 152);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 1;
            label2.Text = "Size:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(152, 61);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 2;
            label3.Text = "Name:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(152, 106);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 3;
            label4.Text = "Type:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(195, 195);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 4;
            label5.Text = "Location";
            label5.Click += label5_Click;
            // 
            // location
            // 
            location.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            location.Cursor = Cursors.Hand;
            location.ForeColor = Color.Blue;
            location.Location = new Point(91, 250);
            location.Name = "location";
            location.Size = new Size(322, 44);
            location.TabIndex = 5;
            location.Text = "Location";
            location.Click += label6_Click;
            // 
            // fileType
            // 
            fileType.AutoSize = true;
            fileType.Location = new Point(257, 106);
            fileType.Name = "fileType";
            fileType.Size = new Size(40, 20);
            fileType.TabIndex = 6;
            fileType.Text = "Type";
            fileType.Click += label7_Click;
            // 
            // fileSize
            // 
            fileSize.AutoSize = true;
            fileSize.Location = new Point(257, 152);
            fileSize.Name = "fileSize";
            fileSize.Size = new Size(36, 20);
            fileSize.TabIndex = 7;
            fileSize.Text = "Size";
            // 
            // fileName
            // 
            fileName.AutoSize = true;
            fileName.Location = new Point(257, 61);
            fileName.Name = "fileName";
            fileName.Size = new Size(49, 20);
            fileName.TabIndex = 8;
            fileName.Text = "Name";
            // 
            // File_Properties_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 356);
            Controls.Add(fileName);
            Controls.Add(fileSize);
            Controls.Add(fileType);
            Controls.Add(location);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "File_Properties_Form";
            Text = "Properties";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label location;
        private Label fileType;
        private Label fileSize;
        private Label fileName;
    }
}