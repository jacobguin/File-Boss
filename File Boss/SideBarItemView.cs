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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace File_Boss
{
    public partial class SideBarItemView : ItemView
    {
        public SideBarItemView()
        {
            InitializeComponent();
        }

        public override void LoadFolder(string Folder, BackFunctions functionHandler)
        {
            LoadBoth(functionHandler);
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
        }

        public override void LoadFile(string File, Icon icon, BackFunctions functionHandler)
        {
            LoadBoth(functionHandler);
            CurrentFile = new(File);
            label1.Text = CurrentFile.Name;
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
        }

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
    }
}
