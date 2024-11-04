﻿using File_Boss.Properties;
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
        public event Func<ItemView, Task>? OnAllClick;
        public event Func<ItemView, Task>? OnDelete;
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
            contextMenuStrip1.Items.Remove(propertiesToolStripMenuItem);
            contextMenuStrip1.Items.Remove(copyToolStripMenuItem);
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
    }
}
