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
    public partial class FolderDisplay : UserControl
    {
        public FolderDisplay()
        {
            InitializeComponent();
        }

        public BackFunctions functionHandler;

        public void LoadFolder(string Folder, BackFunctions functionHandler)
        {
            DirectoryInfo di = new(Folder);
            label1.Text = di.Name;
            //this.MouseClick += label1_Click;
            this.functionHandler = functionHandler;
        }
    }
}
