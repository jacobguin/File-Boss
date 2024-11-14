using File_Boss.Properties;
using Middle;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace File_Boss
{
	public partial class ItemViewContent : ItemView
	{
		public ItemViewContent()
		{
			InitializeComponent();
		}

		private BackFunctions functionHandler;
		private ToolStripMenuItem? fav, zip, uzip, Tab;
		private TabUI tap;

		private void LoadBoth(BackFunctions functionHandler, TabUI t)
		{
			this.functionHandler = functionHandler;
			tap = t;
			this.MouseDoubleClick += AllDoubleClick;
			label1.MouseDoubleClick += AllDoubleClick;
			pictureBox1.MouseDoubleClick += AllDoubleClick;
			this.MouseClick += AllSingleClick;
			label1.MouseClick += AllSingleClick;
			pictureBox1.MouseClick += AllSingleClick;
		}

		public override void LoadFolder(string Folder, BackFunctions functionHandler, TabUI t)
		{
			LoadBoth(functionHandler, t);
			CurrentDirectory = new(Folder);
			label1.Text = CurrentDirectory.Name;
			contextMenuStrip1.Items.Remove(openWithToolStripMenuItem);
			contextMenuStrip1.Items.Remove(propertiesToolStripMenuItem);
			contextMenuStrip1.Items.Remove(copyToolStripMenuItem);
			contextMenuStrip1.Items.Add(zip = new ToolStripMenuItem()
			{
				Text = "Zip"
			});
			zip.Click += Zip_Click;
			contextMenuStrip1.Items.Add(Tab = new ToolStripMenuItem()
			{
				Text = "Open in new tab"
			});
			Tab.Click += Tab_Click;
			if (CurrentDirectory.Name.ToLower() == "black sonic")
			{
				pictureBox1.Image = new Bitmap(new MemoryStream(Resources.sonic));
			}
			Directory.GetLastWriteTime(Folder);
			label6.Text = CurrentDirectory.LastWriteTime.ToString();
		}

		private void Tab_Click(object? sender, EventArgs e)
		{
			CallRequestNewTab();
		}

		private void Zip_Click(object? sender, EventArgs e)
		{
			if (CurrentDirectory != null && !CurrentDirectory.Name.EndsWith(".zip"))
			{
				functionHandler.ZipFolder(CurrentDirectory.Name);
				CallRequestUpdate();
				MessageBox.Show("Folder successfully zipped!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("This item is already zipped or is not a folder.", "Cannot Zip", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

		}

		ToolStripMenuItem createShortcutMenuItem;

		public override void LoadFile(string File, Icon icon, BackFunctions functionHandler, TabUI t)
		{
			LoadBoth(functionHandler, t);
			CurrentFile = new(File);
			label1.Text = CurrentFile.Name;
			pictureBox1.Image = icon.ToBitmap();
			try
			{
				using (Bitmap tempImage = new(CurrentFile.FullName))
				{
					pictureBox1.Image = new Bitmap(tempImage);
				}
			}
			catch { }
			openWithToolStripMenuItem.DropDownItems.Clear();
			createShortcutMenuItem = new ToolStripMenuItem("Create Shortcut to Desktop");
			contextMenuStrip1.Items.Add(createShortcutMenuItem);
			createShortcutMenuItem.Click += CreateShortcutMenuItem_Click;
			foreach (var program in functionHandler.ProgramMap.Values)
			{
				ToolStripMenuItem programItem = new(program);
				openWithToolStripMenuItem.DropDownItems.Add(programItem);

				programItem.Click += (s, args) =>
				{
					functionHandler.OpenWith(program, CurrentFile.FullName);
				};
			}
			contextMenuStrip1.Items.Add(fav = new ToolStripMenuItem()
			{
				Text = "Add To Favorites"
			});
			fav.Click += Tsm_Click;
			if (File.ToLower().EndsWith("zip"))
			{
				contextMenuStrip1.Items.Add(uzip = new ToolStripMenuItem()
				{
					Text = "Unzip"
				});
				uzip.Click += Uzip_Click;
			}
			label6.Text = CurrentFile.LastWriteTime.ToString();
			string fst = "";
			ulong size = (ulong)CurrentFile.Length;
			if (size < 1000)
				fst = size + " bytes";
			else if (size < 1000000)
				fst = Math.Round(size / (double)1000, 2) + " KB";
			else if (size < 1000000000)
				fst = Math.Round(size / (double)1000000, 2) + " MB";
			else if (size < 1000000000000) fst = Math.Round(size / (double)1000000000, 2) + " GB";
			label7.Text = fst;
			label7.Visible = true;
			label4.Visible = true;
		}

		private void Uzip_Click(object? sender, EventArgs e)
		{
			if (CurrentFile != null && CurrentFile.Extension == ".zip")
			{
				functionHandler.UnzipFolder(CurrentFile.Name, Path.GetFileNameWithoutExtension(CurrentFile.FullName));
				CallRequestUpdate();
				MessageBox.Show("Folder successfully unzipped!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("This item is not a zip file.", "Cannot Unzip", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void Tsm_Click(object? sender, EventArgs e)
		{
			functionHandler.AddFavorites(label1.Text);
			fav!.Enabled = false;
		}

		private void AllSingleClick(object? sender, MouseEventArgs e)
		{
			if (e is not null && e.Button == MouseButtons.Left)
			{
				CallOnAllSingleLClick();
			}
			else if (e is null || e.Button == MouseButtons.Right)
			{
				CallOnAllSingleRClick();
			}
		}

		private void AllDoubleClick(object sender, MouseEventArgs e)
		{
			CallOnAllClick();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CallOnDelete();
		}
		private void CreateShortcutMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (CurrentFile != null)
				{
					functionHandler.CreateFileShortcut(CurrentFile.FullName);
				}
				else if (CurrentDirectory != null)
				{
					functionHandler.CreateFileShortcut(CurrentDirectory.FullName);
				}
				else
				{
					throw new UIException("No file or directory is currently selected.");
				}

				MessageBox.Show("Shortcut created on desktop successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (UIException ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private TextBox? renameBox;
		private void renameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			renameBox = new TextBox()
			{
				Text = label1.Text
			};
			label1.Visible = false;
			renameBox.Location = new System.Drawing.Point(18, 95);
			renameBox.Size = new System.Drawing.Size(70, 20);
			this.Controls.Add(renameBox);
			renameBox.KeyPress += rename_Item;
		}
		private void rename_Item(object? sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Enter) return;

			TextBox temp = (TextBox)sender!;
			String oldName = label1.Text;
			label1.Text = temp.Text;
			if (oldName.Contains('.'))
			{
				if (!temp.Text.Contains('.'))
				{
					String defaultExt = Path.GetExtension(oldName);
					String newName = label1.Text + defaultExt;
					functionHandler.RenameFile(oldName, newName);
					functionHandler.AddUIUndoAction(CallRequestUpdate);
					MessageBox.Show(oldName + " was renamed to " + newName + ". No extension was specified. The file was defaulted to original.");
				}
				else
				{
					functionHandler.RenameFile(oldName, temp.Text);
					functionHandler.AddUIUndoAction(CallRequestUpdate);
					MessageBox.Show(oldName + " was renamed to " + temp.Text);
				}
			}
			else
			{
				functionHandler.RenameFolder(oldName, temp.Text);
				functionHandler.AddUIUndoAction(CallRequestUpdate);
				MessageBox.Show(oldName + " was renamed to " + temp.Text);
			}
			Controls.Remove(temp);
			label1.Visible = true;
			CallRequestUpdate();
		}
		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			String path = CurrentFile!.FullName;
			Clipboard.SetText(path);
		}
		private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			File_Properties_Form fp = new();
			fp.load_file(CurrentFile!);
			fp.Show();
		}
		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			AllSingleClick(sender, null!);
			foreach (ToolStripItem item in contextMenuStrip1.Items)
			{
				item.Enabled = true;
			}

			if (tap.SelectedViews.Count > 1)
			{
				propertiesToolStripMenuItem.Enabled = false;
				openWithToolStripMenuItem.Enabled = false;
				if (zip is not null) zip.Enabled = false;
				if (uzip is not null) uzip.Enabled = false;
				if (Tab is not null) Tab.Enabled = false;
				if (fav is not null) fav.Enabled = false;
				if (createShortcutMenuItem is not null) createShortcutMenuItem.Enabled = false;
				renameToolStripMenuItem.Enabled = false;
				copyToolStripMenuItem.Enabled = false;

			}
			else if (CurrentFile is not null && functionHandler.GetFavorites().Contains(CurrentFile.FullName))
			{
				fav!.Enabled = false;
			}
		}
		public void copyToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			CallRequestCopy();
		}
		private void sendOverEmailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CallRequestEmaile();
		}
		public override void ShowSelected()
		{
			BackColor = Color.CornflowerBlue;
			pictureBox1.BackColor = Color.CornflowerBlue;
		}
		public override void ShowNotSelected()
		{
			BackColor = SystemColors.Control;
			pictureBox1.BackColor = SystemColors.Control;
		}
	}
}

