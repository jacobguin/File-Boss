using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms.VisualStyles;

namespace File_Boss
{
    public partial class Form1 : Form
    {
        //TODO Look back at to allow for message to appear when clicking a file in the flow panel
        public Form1()
        {
            //DO NOT TOUCH
            InitializeComponent();
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
            foreach (FileInfo fi in di.GetFiles())
            {
                FileDisplay fd = new();
                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)!;
                fd.LoadFile(fi.FullName, icon);
                //fd.Click += Fd_Click;
                //fd.label1.Click += Fd_Click;
                flowLayoutPanel1.Controls.Add(fd);
            }
        }

        /*private void Fd_Click(object? sender, EventArgs e)
        {
            FileDisplay temp = (FileDisplay)sender;
            MessageBox.Show(temp.label1.Text);
        }
        */

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }
    }
}
