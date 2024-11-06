using Microsoft.VisualBasic.Devices;
using Middle;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http.Headers;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

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
				functionHandler.AddUIUndoAction(() => { updateItemDisplay(); });
				updateItemDisplay();
				pathText.Text = functionHandler.BasePath;

			}

			return Task.CompletedTask;
		}

		public static List<ItemView> SelectedViews { get; set; } = new();
		/// <summary>
		/// Create File Button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			CreateItem ci = new();
			ci.Text = "File Create";
			ci.ShowDialog();
			string fileName = ci.textBox1.Text;
			if (fileName.Contains('.'))
			{
				functionHandler.CreateFile(fileName);
			}
			else
			{
				String defaultExt = fileName + ".txt";
				functionHandler.CreateFile(defaultExt);
			}
			functionHandler.AddUIUndoAction(updateItemDisplay);
			updateItemDisplay();
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
			fd.OnAllSingleLClick += Fd_OnAllSingleClick;
			fd.OnAllSingleRClick += IV_OnAllSingleRClick;
			fd.RequestEmaile += Fd_RequestEmaile;
			fd.RequestCopy += Fd_RequestCopy;
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

		private Task IV_OnAllSingleRClick(ItemView arg)
		{
			if (SelectedViews.Count == 0 || !SelectedViews.Contains(arg))
			{
				Fd_OnAllSingleClick(arg);
			}
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

		private Task Fd_RequestCopy()
		{
		    StringCollection strings = new();
			foreach (ItemView item in SelectedViews)
			{
				if (item.CurentFile is not null)
				{
					strings.Add(item.CurentFile.FullName);
				}
				else
				{
					strings.Add(item.CurentDirectory!.FullName);
				}
			}
			Clipboard.SetFileDropList(strings);
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
			iv.OnAllSingleLClick += Fd_OnAllSingleClick;
			iv.OnAllSingleRClick += IV_OnAllSingleRClick;
			iv.OnDelete += Fd_OnDelete;
			iv.RequestEmaile += Fd_RequestEmaile;
			iv.RequestCopy += Fd_RequestCopy;
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

		/// <summary>
		/// Folder Create Button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
		{
			CreateItem ci = new();
			ci.Text = "Folder Create";
			ci.ShowDialog();
			string folderName = ci.textBox1.Text;
			functionHandler.CreateFolder(folderName);
			functionHandler.AddUIUndoAction(updateItemDisplay);
			updateItemDisplay();
		}

		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			functionHandler.Undo();
		}

		private void backButton_Click(object sender, EventArgs e)
		{
			DirectoryInfo di = Directory.GetParent(functionHandler.BasePath)!;
			functionHandler.BasePath = di.FullName;
			functionHandler.AddUIUndoAction(updateItemDisplay);
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


		ItemView iv = new ItemView();
		public DirectoryInfo? CurentDirectory;

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringCollection colection = Clipboard.GetFileDropList();
			functionHandler.PastFilesAndFolders(colection);
			functionHandler.AddUIUndoAction(() => { updateItemDisplay(); });
			updateItemDisplay();
		}

		private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (!Clipboard.ContainsFileDropList())
			{
				pasteToolStripMenuItem.Enabled = false;
			}
			else
			{
				pasteToolStripMenuItem.Enabled = true;
			}
		}

		private void emailSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			EmailLogin el = new()
			{ Functions = functionHandler };
			el.ShowDialog();
		}

		private void flowLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
		{
			foreach (ItemView iv in SelectedViews)
			{
				iv.BackColor = SystemColors.Control;
				iv.pictureBox1.BackColor = SystemColors.Control;
			}
			SelectedViews.Clear();
		}
	}
}
