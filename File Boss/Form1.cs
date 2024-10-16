using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
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
                fd.Click += Fd_Click;
                fd.label1.Click += Fd_Click;
                flowLayoutPanel1.Controls.Add(fd);
            }
        }

        private void Fd_Click(object? sender, EventArgs e)
        {
            FileDisplay temp = (FileDisplay)sender;
            MessageBox.Show(temp.label1.Text);
        }

        // Add Button which creates a text field for you to input a file name
        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello World");
            TextBox textBox = new TextBox();
            textBox.Location = new System.Drawing.Point(648, 375);
            textBox.Size = new System.Drawing.Size(125, 27);
            this.Controls.Add(textBox);
            textBox.KeyPress += TextBox_KeyPress;
        }

        // Once enter is pressed, a file is created and a message box appears
        private void TextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;

            TextBox temp = (TextBox)sender!;
            Middle.BackFunctions.CreateFile(temp.Text);
            MessageBox.Show(temp.Text + " was Created!");
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.WhiteSmoke;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }
    }
}
