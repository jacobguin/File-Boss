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
			foreach (DirectoryInfo fi in di.GetDirectories())
			{
				addFolderDisplay(fi);
			}
			foreach (FileInfo fi in di.GetFiles())
			{
				addFileDisplay(fi);
			}
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
				var v = addFileDisplay(new FileInfo(name));
				functionHandler.AddUIUndoAction(() => { RemoveObject(v); });
				MessageBox.Show(name + " was Created!");
			}
			else
			{
				String defaultExt = name + ".txt";
				functionHandler.CreateFile(defaultExt);
				var v = addFileDisplay(new FileInfo(defaultExt));
				functionHandler.AddUIUndoAction(() => { RemoveObject(v); });
				MessageBox.Show(defaultExt + " was Created! File defaulted to a text file.");
			}
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
			flowLayoutPanel1.Controls.Add(fd);
			return fd;
		}

		public void addFolderDisplay(DirectoryInfo di)
		{
			ItemView iv = new();
			iv.LoadFolder(di.FullName, functionHandler);
			flowLayoutPanel1.Controls.Add(iv);
		}

		/// <summary>
		/// These functions will remove an object from the flow layout panel
		/// </summary>
		/// <param name="arg"></param>
		/// <returns></returns>
		private Task Fd_OnDelete(ItemView arg)
		{
			RemoveObject(arg);
			if (arg.CurentFile is not null)
			{
				functionHandler.DeleteFile(arg.CurentFile.Name);
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
			addFolderDisplay(new DirectoryInfo(temp.Text));
			Controls.Remove(temp);
		}

		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			functionHandler.Undo();
		}
	}
}
