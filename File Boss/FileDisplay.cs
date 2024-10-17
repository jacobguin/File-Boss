﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Boss
{
    public partial class FileDisplay : UserControl
    {
        public FileDisplay()
        {
            InitializeComponent();
        }

        public event Func<FileDisplay, Task>? OnAllClick; 

        public void LoadFile(string File, Icon icon)
        {
            FileInfo fi = new(File);
            label1.Text = fi.Name;
            pictureBox1.Image = icon.ToBitmap();
            this.Click += label1_Click;
            pictureBox1.Click += label1_Click;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (OnAllClick is not null)
            {
                OnAllClick.Invoke(this);
            }
        }
    }
}
