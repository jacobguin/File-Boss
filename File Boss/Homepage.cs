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
        public static List<ItemView> SelectedViews { get; set; } = new();

        public void LoadFavorites()
        {
            string[] favorites = functionHandler.GetFavorites();
            flowLayoutPanel2.Controls.Clear();
            foreach (string favorite in favorites)
            {
                ItemView iv = parent.CreateBoth();
                FileInfo fi = new FileInfo(favorite);
                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)!;
                iv.LoadFile(favorite, icon, functionHandler);
                iv.Name = favorite;
                flowLayoutPanel2.Controls.Add(iv);
                
            }
        }

        public TabUI parent;
        public void LoadCommonDir()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string downloads = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            string music = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            string pictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string videos = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

            addFolderDisplay(new DirectoryInfo(desktop));
            addFolderDisplay(new DirectoryInfo(documents));
            addFolderDisplay(new DirectoryInfo(downloads));
            addFolderDisplay(new DirectoryInfo(music));
            addFolderDisplay(new DirectoryInfo(pictures));
            addFolderDisplay(new DirectoryInfo(videos));
        }

        public void addFolderDisplay(DirectoryInfo di)
        {
            ItemView iv = parent.CreateBoth();
            iv.LoadFolder(di.FullName, functionHandler);
            flowLayoutPanel1.Controls.Add(iv);
        }

        public ItemView addFileDisplay(FileInfo fi)
        {
            ItemView iv = parent.CreateBoth();
            Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)!;
            iv.LoadFile(fi.FullName, icon, functionHandler);
            flowLayoutPanel1.Controls.Add(iv);
            return iv;
        }
    }
}
