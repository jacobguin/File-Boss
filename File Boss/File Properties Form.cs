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

    public partial class File_Properties_Form : Form
    {

        public FileInfo? CurentFile;

        public File_Properties_Form()
        {
            InitializeComponent();

        }

        public void load_file(FileInfo fi)
        {
            CurentFile = fi;
            label6.Text = CurentFile.FullName;
            label7.Text = CurentFile.Extension;
            label8.Text = CurentFile.Length.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(CurentFile.FullName);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
