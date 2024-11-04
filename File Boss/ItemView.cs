using File_Boss.Properties;
using Middle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
		public event Func<ItemView, Task>? OnAllClick;
		public event Func<ItemView, Task>? OnDelete;

		private void LoadBoth(BackFunctions functionHandler)
		{
			this.functionHandler = functionHandler;
			this.MouseDoubleClick += label1_Click;
			label1.MouseDoubleClick += label1_Click;
			pictureBox1.MouseDoubleClick += label1_Click;

            ToolStripMenuItem createShortcutMenuItem = new ToolStripMenuItem("Create Shortcut to Desktop");
            contextMenuStrip1.Items.Add(createShortcutMenuItem);
            createShortcutMenuItem.Click += CreateShortcutMenuItem_Click;
        }

		public void LoadFolder(string Folder, BackFunctions functionHandler)
		{
			LoadBoth(functionHandler);
			CurentDirectory = new(Folder);
			label1.Text = CurentDirectory.Name;
			contextMenuStrip1.Items.Remove(openWithToolStripMenuItem);
		}

		public void LoadFile(string File, Icon icon, BackFunctions functionHandler)
		{
			LoadBoth(functionHandler);
			CurentFile = new(File);
			label1.Text = CurentFile.Name;
			pictureBox1.Image = icon.ToBitmap();
			openWithToolStripMenuItem.DropDownItems.Clear();
			foreach (var program in functionHandler.ProgramMap.Values)
			{
				ToolStripMenuItem programItem = new(program);
				openWithToolStripMenuItem.DropDownItems.Add(programItem);

				programItem.Click += (s, args) =>
				{
					functionHandler.OpenWith(program, CurentFile.FullName);
				};
			}
		}

		private void label1_Click(object sender, EventArgs e)
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
    }
}

