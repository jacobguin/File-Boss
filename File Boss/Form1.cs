using Microsoft.VisualBasic.Devices;
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

		public static List<ItemView> SelectedViews { get; set; } = new();

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
			fd.OnAllSingleClick += Fd_OnAllSingleClick;
			fd.RequestEmaile += Fd_RequestEmaile;
			flowLayoutPanel1.Controls.Add(fd);
			return fd;
		}

		private Task Fd_RequestEmaile()
		{
			List<string> paths = new();
			List<string> Dips = new();
			foreach (ItemView item in SelectedViews)
			{
				if (item.CurentFile is not null)
				{
					if (item.CurentFile.Name.ToLower().EndsWith(".zip"))
					{
						paths.Add(item.CurentFile.FullName);
					}
					else
					{
						Dips.Add(item.CurentFile.FullName);
					}
				}
				else Dips.Add(item.CurentDirectory!.FullName);
			}
			string zip = Path.GetRandomFileName() + ".zip";
			functionHandler.ZipData(zip, Dips.ToArray());
			paths.Add(Path.Join(functionHandler.BasePath, zip));
			EmailPrompt EP = new()
			{
				PathsToZips = paths.ToArray(),
				Functions = functionHandler
			};
			EP.ShowDialog();
			return Task.CompletedTask;
		}

		private Task Fd_OnAllSingleClick(ItemView arg)
		{
			if (Control.ModifierKeys != Keys.Control)
			{
				foreach (ItemView iv in SelectedViews)
				{
					iv.BackColor = SystemColors.Control;
					iv.pictureBox1.BackColor = SystemColors.Control;
				}
				SelectedViews.Clear();
				arg.BackColor = Color.CornflowerBlue;
				arg.pictureBox1.BackColor = Color.CornflowerBlue;
				SelectedViews.Add(arg);
			}
			else
			{
				
				if (SelectedViews.Contains(arg))
				{
					if (SelectedViews.Count == 1) return Task.CompletedTask;
					arg.BackColor = SystemColors.Control;
					arg.pictureBox1.BackColor = SystemColors.Control;
					SelectedViews.Remove(arg);
				}
				else
				{
					arg.BackColor = Color.CornflowerBlue;
					arg.pictureBox1.BackColor = Color.CornflowerBlue;
					SelectedViews.Add(arg);
				}
			}

			
			return Task.CompletedTask;
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
			iv.OnAllSingleClick += Fd_OnAllSingleClick;
			iv.RequestEmaile += Fd_RequestEmaile;
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
			SelectedViews.Clear();
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
			RemoveObject(arg);
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

		private void emailSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EmailLogin el = new()
			{ Functions = functionHandler };
			el.ShowDialog();
		}
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
