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
        public event Func<ItemView, Task>? RequestUpdate;
        private ToolStripMenuItem? fav;

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
            contextMenuStrip1.Items.Add(fav = new ToolStripMenuItem()
            {
                Text = "Add To Favorites"
            });
            fav.Click += Tsm_Click;
        }

        private void Tsm_Click(object? sender, EventArgs e)
        {
            functionHandler.AddFavorites(label1.Text);
            fav!.Enabled = false;
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

        private TextBox? renameBox;
        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renameBox = new TextBox()
            {
                Text = label1.Text
            };
            label1.Visible = false;
            renameBox.Location = new System.Drawing.Point(15, 103);
            renameBox.Size = new System.Drawing.Size(50, 20);
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
                    String defaultExt = temp.Text + ".txt";
                    label1.Text = defaultExt;
                    functionHandler.RenameFile(oldName, defaultExt);
                    MessageBox.Show(oldName + " was renamed to " + defaultExt + ". No extension was specified. The file was defaulted to a text file.");
                }
                else
                {
                    functionHandler.RenameFile(oldName, temp.Text);
                    MessageBox.Show(oldName + " was renamed to " + temp.Text);
                }
            }
            else
            {
                functionHandler.RenameFolder(oldName, temp.Text);
                MessageBox.Show(oldName + " was renamed to " + temp.Text);
            }
            Controls.Remove(temp);
            label1.Visible = true;
            if (RequestUpdate is not null)
            {
                RequestUpdate.Invoke(this);
            }

        }


    }
}

