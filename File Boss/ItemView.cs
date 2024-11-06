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
    public partial class ItemView : UserControl
    {
        public ItemView()
        {
            InitializeComponent();
        }

		private BackFunctions functionHandler;
		public FileInfo? CurentFile;
		public DirectoryInfo? CurentDirectory;
		public event Func<ItemView, Task>? OnAllSingleLClick;
		public event Func<ItemView, Task>? OnAllSingleRClick;
		public event Func<ItemView, Task>? OnAllClick;
		public event Func<ItemView, Task>? OnDelete;
		public event Func<ItemView, Task>? RequestUpdate;
		public event Func<Task>? RequestEmaile;
		public event Func<Task>? RequestCopy;
		private ToolStripMenuItem? fav, zip, uzip;

		private void LoadBoth(BackFunctions functionHandler)
		{
			this.functionHandler = functionHandler;
			this.MouseDoubleClick += AllDoubleClick;
			label1.MouseDoubleClick += AllDoubleClick;
			pictureBox1.MouseDoubleClick += AllDoubleClick;
			this.MouseClick += AllSingleClick;
			label1.MouseClick += AllSingleClick;
			pictureBox1.MouseClick += AllSingleClick;
		}

		public void LoadFolder(string Folder, BackFunctions functionHandler)
		{
			LoadBoth(functionHandler);
			CurentDirectory = new(Folder);
			label1.Text = CurentDirectory.Name;
			contextMenuStrip1.Items.Remove(openWithToolStripMenuItem);
            contextMenuStrip1.Items.Remove(propertiesToolStripMenuItem);
            contextMenuStrip1.Items.Remove(copyToolStripMenuItem);
            contextMenuStrip1.Items.Add(zip = new ToolStripMenuItem()
			{
				Text = "Zip"
			});
			zip.Click += Zip_Click;
        }

		private void Zip_Click(object? sender, EventArgs e)
		{
			if (CurentDirectory != null && !CurentDirectory.Name.EndsWith(".zip"))
			{
				functionHandler.ZipFolder(CurentDirectory.Name);
				if (RequestUpdate is not null)
				{
					RequestUpdate.Invoke(this);
				}
				MessageBox.Show("Folder successfully zipped!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("This item is already zipped or is not a folder.", "Cannot Zip", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

		}
        public void LoadFile(string File, Icon icon, BackFunctions functionHandler)
		{
			LoadBoth(functionHandler);
			CurentFile = new(File);
			label1.Text = CurentFile.Name;
			pictureBox1.Image = icon.ToBitmap();
			openWithToolStripMenuItem.DropDownItems.Clear();
            ToolStripMenuItem createShortcutMenuItem = new ToolStripMenuItem("Create Shortcut to Desktop");
            contextMenuStrip1.Items.Add(createShortcutMenuItem);
            createShortcutMenuItem.Click += CreateShortcutMenuItem_Click;
            foreach (var program in functionHandler.ProgramMap.Values)
			{
				ToolStripMenuItem programItem = new(program);
				openWithToolStripMenuItem.DropDownItems.Add(programItem);

                programItem.Click += (s, args) =>
                {
                    functionHandler.OpenWith(program, CurentFile.FullName);
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
        }

        private void Uzip_Click(object? sender, EventArgs e)
        {
            if (CurentFile != null && CurentFile.Extension == ".zip")
            {
                functionHandler.UnzipFolder(CurentFile.Name, Path.GetFileNameWithoutExtension(CurentFile.FullName));
                if (RequestUpdate is not null)
                {
                    RequestUpdate.Invoke(this);
                }
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
				if (OnAllSingleLClick is not null)
				{
					OnAllSingleLClick.Invoke(this);
				}
			}
			else if (e is null || e.Button == MouseButtons.Right)
			{
				if (OnAllSingleRClick is not null)
				{
					OnAllSingleRClick.Invoke(this);
				}
			}
		}

		private void AllDoubleClick(object sender, MouseEventArgs e)
		{
			if (OnAllClick is not null)
			{
				OnAllClick.Invoke(this);
			}
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (OnDelete is not null)
			{
				OnDelete.Invoke(this);
			}
		}
        private void CreateShortcutMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurentFile != null)
                {
                    functionHandler.CreateFileShortcut(CurentFile.FullName);
                }
                else if (CurentDirectory != null)
                {
                    functionHandler.CreateFileShortcut(CurentDirectory.FullName);
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
			renameBox.Location = new System.Drawing.Point(15, 70);
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
					functionHandler.AddUIUndoAction(() => { if (RequestUpdate is not null) RequestUpdate.Invoke(this); });

					MessageBox.Show(oldName + " was renamed to " + newName + ". No extension was specified. The file was defaulted to original.");
				}
				else
				{
					functionHandler.RenameFile(oldName, temp.Text);
					functionHandler.AddUIUndoAction(() => { if (RequestUpdate is not null) RequestUpdate.Invoke(this); });
					MessageBox.Show(oldName + " was renamed to " + temp.Text);
				}
			}
			else
			{
				functionHandler.RenameFolder(oldName, temp.Text);
				functionHandler.AddUIUndoAction(() => { if (RequestUpdate is not null) RequestUpdate.Invoke(this); });
				MessageBox.Show(oldName + " was renamed to " + temp.Text);
			}
			Controls.Remove(temp);
			label1.Visible = true;
			if (RequestUpdate is not null)
			{
				RequestUpdate.Invoke(this);
			}

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String path = CurentFile.FullName;
            Clipboard.SetText(path);
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File_Properties_Form fp = new();
            fp.load_file(CurentFile);
            fp.Show();
        }
		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			AllSingleClick(sender, null!);
		}

		private void contextMenuStrip1_Click(object sender, EventArgs e)
		{
			
		}

        public void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {   
            if (RequestCopy is not null)
            {
                RequestCopy.Invoke();
            }
            //Clipboard.SetFileDropList(new StringCollection { CurentFile!.FullName });
        }
          
		private void sendOverEmailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (RequestEmaile is not null) RequestEmaile.Invoke();
		}
	}
}

