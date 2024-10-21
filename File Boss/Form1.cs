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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox textBox = new TextBox();
            //textBox.Name = "FileName";
            textBox.Location = new System.Drawing.Point(648, 375);
            textBox.Size = new System.Drawing.Size(125, 27);
            this.Controls.Add(textBox);
            

            Middle.BackFunctions.CreateFile("newfile2.txt");




        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Middle.BackFunctions.DeleteFile();
        }
    }
}
