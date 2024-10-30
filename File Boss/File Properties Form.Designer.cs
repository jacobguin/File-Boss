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
            filePath = new Label();
            fileType = new Label();
            fileSize = new Label();
            fileName = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(86, 53);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 0;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 130);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 1;
            label2.Text = "Size";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 32);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 2;
            label3.Text = "Name";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 66);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 3;
            label4.Text = "Type";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 100);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 4;
            label5.Text = "Location";
            label5.Click += label5_Click;
            // 
            // filePath
            // 
            filePath.AutoSize = true;
            filePath.ForeColor = Color.Blue;
            filePath.Location = new Point(134, 100);
            filePath.Name = "filePath";
            filePath.Size = new Size(53, 15);
            filePath.TabIndex = 5;
            filePath.Text = "Loaction";
            filePath.Click += label6_Click;
            // 
            // fileType
            // 
            fileType.AutoSize = true;
            fileType.Location = new Point(134, 66);
            fileType.Name = "fileType";
            fileType.Size = new Size(31, 15);
            fileType.TabIndex = 6;
            fileType.Text = "Type";
            fileType.Click += label7_Click;
            // 
            // fileSize
            // 
            fileSize.AutoSize = true;
            fileSize.Location = new Point(134, 130);
            fileSize.Name = "fileSize";
            fileSize.Size = new Size(27, 15);
            fileSize.TabIndex = 7;
            fileSize.Text = "Size";
            // 
            // fileName
            // 
            fileName.AutoSize = true;
            fileName.Location = new Point(134, 32);
            fileName.Name = "fileName";
            fileName.Size = new Size(39, 15);
            fileName.TabIndex = 8;
            fileName.Text = "Name";
            // 
            // File_Properties_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 390);
            Controls.Add(fileName);
            Controls.Add(fileSize);
            Controls.Add(fileType);
            Controls.Add(filePath);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "File_Properties_Form";
            Text = "File_Properties_Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label filePath;
        private Label fileType;
        private Label fileSize;
        private Label fileName;
    }
}