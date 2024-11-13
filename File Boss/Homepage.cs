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
    public partial class Homepage : UserControl
    {
        public Homepage()
        {
            InitializeComponent();
        }
        public BackFunctions functionHandler { get; set; }

        public void LoadFavorites(TabUI t)
        {
            string[] favorites = functionHandler.GetFavorites();
            flowLayoutPanel2.Controls.Clear();
            foreach (string favorite in favorites)
            {
                ItemView iv = parent.CreateBoth();
                FileInfo fi = new FileInfo(favorite);
                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)!;
                iv.LoadFile(favorite, icon, functionHandler, t);
                iv.Name = favorite;
                flowLayoutPanel2.Controls.Add(iv);
                
            }
        }

        public TabUI parent;
        public void LoadCommonDir(TabUI t)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string downloads = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            string music = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            string pictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string videos = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

            addFolderDisplay(new DirectoryInfo(desktop), t);
            addFolderDisplay(new DirectoryInfo(documents), t);
            addFolderDisplay(new DirectoryInfo(downloads), t);
            addFolderDisplay(new DirectoryInfo(music), t);
            addFolderDisplay(new DirectoryInfo(pictures), t);
            addFolderDisplay(new DirectoryInfo(videos), t);
        }

        public void addFolderDisplay(DirectoryInfo di, TabUI t)
        {
            ItemView iv = parent.CreateBoth();
            iv.LoadFolder(di.FullName, functionHandler, t);
            flowLayoutPanel1.Controls.Add(iv);
        }

        public ItemView addFileDisplay(FileInfo fi, TabUI t)
        {
            ItemView iv = parent.CreateBoth();
            Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)!;
            iv.LoadFile(fi.FullName, icon, functionHandler, t);
            flowLayoutPanel1.Controls.Add(iv);
            return iv;
        }
    }
}
