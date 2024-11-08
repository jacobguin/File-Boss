using Microsoft.VisualBasic.Devices;
using Middle;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http.Headers;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace File_Boss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //DO NOT TOUCH
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TabUI u = new()
            {
                functionHandler = new() { BasePath = Directory.GetCurrentDirectory() },
                Dock = DockStyle.Fill,
            };
            u.RequestNewTab += U_RequestNewTab;
            DirectoryInfo di = new(u.functionHandler.BasePath);
            TabPage tp = new();
            tp.Text = di.Name;
            tp.Controls.Add(u);
            tabControl1.TabPages.Add(tp);
            u.RequestRefreash += () =>
            {
                tp.Text = new DirectoryInfo(u.functionHandler.BasePath).Name;
                tabControl1.Refresh();
                return Task.CompletedTask;
            };
        }

        private Task U_RequestNewTab(ItemView arg)
        {
            if (arg.CurrentDirectory is not null)
            {
                TabUI u = new()
                {
                    functionHandler = new() { BasePath = arg.CurrentDirectory.FullName },
                    Dock = DockStyle.Fill,
                };
                u.RequestNewTab += U_RequestNewTab;

                DirectoryInfo di = new(u.functionHandler.BasePath);
                TabPage tp = new();
                tp.Text = di.Name;
                tp.Controls.Add(u);
                tabControl1.TabPages.Add(tp);
                tabControl1.SelectedTab = tp;
                u.RequestRefreash += () =>
                {
                    tp.Text = new DirectoryInfo(u.functionHandler.BasePath).Name;
                    tabControl1.Refresh();
                    return Task.CompletedTask;
                };
            }

            return Task.CompletedTask;
        }
    }
}
