using Middle;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace File_Boss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //DO NOT TOUCH
            InitializeComponent();
            functionHandler = new() { BasePath = Directory.GetCurrentDirectory() };
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
            foreach (FileInfo fi in di.GetFiles())
            {
                addFileDisplay(fi);
            }
        }

        ///Allows for the creation of files
        public BackFunctions functionHandler;

        /// <summary>
        /// New on click function to select files in the flowLayoutPanel1
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private Task Fd_OnAllClick(FileDisplay arg)
        {
            string fileName = arg.label1.Text;
            functionHandler.Open(fileName);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Add Button which creates a text field for you to input a file name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            TextBox textBox = new TextBox();
            textBox.Location = new System.Drawing.Point(200, 16);
            textBox.Size = new System.Drawing.Size(125, 27);
            this.Controls.Add(textBox);
            textBox.KeyPress += TextBox_KeyPress;
        }

        /// <summary>
        /// Once ENTER is pressed, a file is created and a message box appears
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;

            TextBox temp = (TextBox)sender!;
            functionHandler.CreateFile(temp.Text);
            MessageBox.Show(temp.Text + " was Created!");
            addFileDisplay(new FileInfo(temp.Text));
            Controls.Remove(temp);
        }

        /// <summary>
        /// Event Handlers, which change the color of the Add Button if it is hovered over or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.RoyalBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.CornflowerBlue;
        }

        /// <summary>
        /// Backend function in order to display file information
        /// </summary>
        /// <param name="fi"></param>
        public void addFileDisplay(FileInfo fi)
        {
            FileDisplay fd = new();
            Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)!;
            fd.LoadFile(fi.FullName, icon, functionHandler);
            fd.OnAllClick += Fd_OnAllClick;
            fd.OnDelete += Fd_OnDelete;
            flowLayoutPanel1.Controls.Add(fd);
        }
        
        public void addFolderDisplay(DirectoryInfo di)
        {
            FolderDisplay dd = new();
            dd.LoadFolder(di.FullName, functionHandler);
            //fd.OnAllClick += Fd_OnAllClick;
            flowLayoutPanel1.Controls.Add(dd);
            /*TextBox temp = (TextBox)sender!;
            functionHandler.CreateFolder(temp.Text);
            MessageBox.Show(temp.Text + " was Created!");
            addFileDisplay(new FileInfo(temp.Text));
            Controls.Remove(temp);*/
        }

        /// <summary>
        /// These functions will remove an object from the flow layout panel
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private Task Fd_OnDelete(FileDisplay arg)
        {
            RemoveObject(arg);
            return Task.CompletedTask;
        }

        public void RemoveObject(Control fd)
        {
            flowLayoutPanel1.Controls.Remove(fd);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox textBox = new TextBox();
            textBox.Location = new System.Drawing.Point(200, 16);
            textBox.Size = new System.Drawing.Size(125, 27);
            this.Controls.Add(textBox);
            textBox.KeyPress += create_Folder;
        }

        private void create_Folder(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;

            TextBox temp = (TextBox)sender!;
            functionHandler.CreateFolder(temp.Text);
            MessageBox.Show(temp.Text + " was Created!");
            addFolderDisplay(new DirectoryInfo(temp.Text));
            Controls.Remove(temp);
        }
    }
}
