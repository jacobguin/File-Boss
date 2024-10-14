using System.Diagnostics;
using System.Reflection;

namespace File_Boss
{
    public partial class Form1 : Form
    {
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
                flowLayoutPanel1.Controls.Add(fd);
            }
        }

       
    }
}
