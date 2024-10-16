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

        public void LoadFile(string File, Icon icon)
        {
            FileInfo fi = new(File);
            label1.Text = fi.Name;
            pictureBox1.Image = icon.ToBitmap();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
