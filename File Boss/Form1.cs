using Middle;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            pathText.Text = di.FullName;
            updateItemDisplay();
        }

        ///Allows for the creation of files
        public BackFunctions functionHandler;

        /// <summary>
        /// New on click function to select items in the flowLayoutPanel1
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private Task Fd_OnAllClick(ItemView arg)
        {
            if (arg.CurentFile is not null)
            {
                string fileName = arg.label1.Text;
                functionHandler.Open(fileName);
            }
            else
            {
                //directory
                //TODO Work on moving to directorie
                functionHandler.BasePath = Path.Join(functionHandler.BasePath, arg.CurentDirectory!.Name);
                updateItemDisplay();
                pathText.Text = functionHandler.BasePath;

            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Add Button which creates a text field for you to input a file name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (curentin is not null) Controls.Remove(curentin);
            curentin = new TextBox();
            curentin.Location = new System.Drawing.Point(200, 16);
            curentin.Size = new System.Drawing.Size(125, 27);
            this.Controls.Add(curentin);
            curentin.KeyPress += TextBox_KeyPress;
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
            String name = (String)temp.Text;
            if (name.Contains('.'))
            {
                functionHandler.CreateFile(name);
            }
            else
            {
                String defaultExt = name + ".txt";
                functionHandler.CreateFile(defaultExt);
            }
            updateItemDisplay();
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
        public ItemView addFileDisplay(FileInfo fi)
        {
            ItemView fd = new();
            Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)!;
            fd.LoadFile(fi.FullName, icon, functionHandler);
            fd.OnAllClick += Fd_OnAllClick;
            fd.OnDelete += Fd_OnDelete;
            fd.RequestUpdate += Fd_RequestUpdate;
            flowLayoutPanel1.Controls.Add(fd);
            return fd;
        }

        private Task Fd_RequestUpdate(ItemView arg)
        {
            updateItemDisplay();
            return Task.CompletedTask;
        }

        public void addFolderDisplay(DirectoryInfo di)
        {
            ItemView iv = new();
            iv.OnAllClick += Fd_OnAllClick;
            iv.RequestUpdate += Fd_RequestUpdate;
			iv.OnDelete += Fd_OnDelete;
			iv.LoadFolder(di.FullName, functionHandler);
            flowLayoutPanel1.Controls.Add(iv);
        }

        public void updateItemDisplay()
        {
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();
            DirectoryInfo di = new DirectoryInfo(functionHandler.BasePath);
            foreach (DirectoryInfo fi in di.GetDirectories())
            {
                addFolderDisplay(fi);
            }
            foreach (FileInfo fi in di.GetFiles())
            {
                addFileDisplay(fi);
            }
            flowLayoutPanel1.ResumeLayout();
            flowLayoutPanel1.PerformLayout();
        }

        /// <summary>
        /// These functions will remove an object from the flow layout panel
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private Task Fd_OnDelete(ItemView arg)
        {
            if (arg.CurentFile is null)
            {
				var result = MessageBox.Show($"Are you sure you want to delete the folder '{arg.CurentDirectory.Name}'?",
					"Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				if (result == DialogResult.Yes)
				{
					try
					{
						functionHandler.DeleteFolder(arg.CurentDirectory.Name);
						MessageBox.Show("Folder successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

						updateItemDisplay();
					}
					catch (UIException ex)
					{
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
            else
            {
				var result = MessageBox.Show($"Are you sure you want to delete the file '{arg.CurentFile.Name}'?",
					"Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				if (result == DialogResult.Yes)
				{
					try
					{
						functionHandler.DeleteFile(arg.CurentFile.Name);
						MessageBox.Show("File successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

						updateItemDisplay();
					}
					catch (UIException ex)
					{
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
            return Task.CompletedTask;
        }

        public void RemoveObject(Control fd)
        {

            flowLayoutPanel1.Controls.Remove(fd);
        }

        private TextBox? curentin;

        private void button2_Click(object sender, EventArgs e)
        {
            if (curentin is not null) Controls.Remove(curentin);
            curentin = new TextBox();
            curentin.Location = new System.Drawing.Point(200, 16);
            curentin.Size = new System.Drawing.Size(125, 27);
            this.Controls.Add(curentin);
            curentin.KeyPress += create_Folder;
        }

        private void create_Folder(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;

            TextBox temp = (TextBox)sender!;
            functionHandler.CreateFolder(temp.Text);
            MessageBox.Show(temp.Text + " was Created!");
            updateItemDisplay();
            Controls.Remove(temp);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            functionHandler.Undo();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = Directory.GetParent(functionHandler.BasePath)!;
            functionHandler.BasePath = di.FullName;
            updateItemDisplay();
            pathText.Text = di.FullName;
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data!.GetData(DataFormats.FileDrop)!;
            foreach (string file in files)
            {
                functionHandler.MoveFileToCurrDirectory(file);
            }
            updateItemDisplay();
        }

        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
