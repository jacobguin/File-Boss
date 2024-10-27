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

        }

        public void LoadFolder(string Folder, BackFunctions functionHandler)
        {
            LoadBoth(functionHandler);
            CurentDirectory = new(Folder);
            label1.Text = CurentDirectory.Name;
            contextMenuStrip1.Items.Remove(openWithToolStripMenuItem);

            var zipMenuItem = new ToolStripMenuItem("Zip Folder");
            zipMenuItem.Click += ZipMenuItem_Click;
            contextMenuStrip1.Items.Add(zipMenuItem);
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
        private void ZipMenuItem_Click(object sender, EventArgs e)
        {
            if (CurentDirectory != null && !CurentDirectory.Name.EndsWith(".zip"))
            {
                functionHandler.ZipFolder(CurentDirectory.FullName);
                MessageBox.Show("Folder successfully zipped!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("This item is already zipped or is not a folder.", "Cannot Zip", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
