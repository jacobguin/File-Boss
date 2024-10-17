using Middle;
using System;
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
        public BackFunctions functionHandler;
        public void LoadFile(string File, Icon icon, BackFunctions functionHandler)
        {
            FileInfo fi = new(File);
            label1.Text = fi.Name;
            pictureBox1.Image = icon.ToBitmap();
            this.MouseClick += label1_Click;
            pictureBox1.MouseClick += label1_Click;
            this.functionHandler = functionHandler;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (OnAllClick is not null)
            {
                OnAllClick.Invoke(this);
            }
        }

        /// <summary>
        /// This is the right click menu for the files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
