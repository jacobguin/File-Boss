using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Boss
{

    public partial class File_Properties_Form : Form
    {

        public FileInfo? CurentFile;

        public File_Properties_Form()
        {
            InitializeComponent();

        }

        public void load_file(FileInfo fi)
        {
            CurentFile = fi;           
            filePath.Text = CurentFile.FullName;
            //fileType.Text = CurentFile.Extension;
            //fileSize.Text = CurentFile.Length.ToString() + " Bytes";
            //fileName.Text = CurentFile.Name;
            

            string fst = "";
            ulong size = (ulong)CurentFile.Length;
            if (size < 1000)
                fst = size + " bytes";
            else if (size < 1000000)
                fst = Math.Round(size / (double)1000, 2) + " KB";
            else if (size < 1000000000)
                fst = Math.Round(size / (double)1000000, 2) + " MB";
            else if (size < 1000000000000) fst = Math.Round(size / (double)1000000000, 2) + " GB";

            fileSize.Text = fst;

            if (CurentFile.Extension == ".txt")
            {
                fileType.Text = "Text";
            }
            else if (CurentFile.Extension == ".exe")
            {
                fileType.Text = "Executable";
            }
            else if (CurentFile.Extension == ".docx")
            {
                fileType.Text = "Word Document";
            }
            else if (CurentFile.Extension == ".pdf")
            {
                fileType.Text = "PDF";
            }
            else if (CurentFile.Extension == ".gif")
            {
                fileType.Text = "GIF";
            }
            else if (CurentFile.Extension == ".jpeg" || CurentFile.Extension == ".jpg")
            {
                fileType.Text = "JPEG";
            }
            else if (CurentFile.Extension == ".png")
            {
                fileType.Text = "PNG";
            }
            else if (CurentFile.Extension == ".xls" || CurentFile.Extension == ".xlsx")
            {
                fileType.Text = "Excel Spreadsheet";
            }
            else if (CurentFile.Extension == ".ppt" || CurentFile.Extension == ".pptx")
            {
                fileType.Text = "PowerPoint Presentation";
            }
            else if (CurentFile.Extension == ".mp3")
            {
                fileType.Text = "MP3 Audio";
            }
            else if (CurentFile.Extension == ".wav")
            {
                fileType.Text = "WAV Audio";
            }
            else if (CurentFile.Extension == ".mp4")
            {
                fileType.Text = "MP4 Video";
            }
            else if (CurentFile.Extension == ".mov")
            {
                fileType.Text = "MOV Video";
            }
            else if (CurentFile.Extension == ".zip")
            {
                fileType.Text = "ZIP Archive";
            }
            else if (CurentFile.Extension == ".rar")
            {
                fileType.Text = "RAR Archive";
            }
            else if (CurentFile.Extension == ".html" || CurentFile.Extension == ".htm")
            {
                fileType.Text = "HTML Document";
            }
            else if (CurentFile.Extension == ".css")
            {
                fileType.Text = "CSS File";
            }
            else if (CurentFile.Extension == ".js")
            {
                fileType.Text = "JavaScript File";
            }
            else if (CurentFile.Extension == ".json")
            {
                fileType.Text = "JSON File";
            }
            else if (CurentFile.Extension == ".xml")
            {
                fileType.Text = "XML File";
            }
            else if (CurentFile.Extension == ".csv")
            {
                fileType.Text = "CSV File";
            }
            else if (CurentFile.Extension == ".bmp")
            {
                fileType.Text = "Bitmap Image";
            }
            else if (CurentFile.Extension == ".svg")
            {
                fileType.Text = "SVG Image";
            }
            else if (CurentFile.Extension == ".md")
            {
                fileType.Text = "Markdown File";
            }
            else if (CurentFile.Extension == ".php")
            {
                fileType.Text = "PHP Script";
            }
            else if (CurentFile.Extension == ".py")
            {
                fileType.Text = "Python Script";
            }
            else if (CurentFile.Extension == ".cpp")
            {
                fileType.Text = "C++ Source File";
            }
            else if (CurentFile.Extension == ".c")
            {
                fileType.Text = "C Source File";
            }
            else if (CurentFile.Extension == ".java")
            {
                fileType.Text = "Java Source File";
            }
            else if (CurentFile.Extension == ".rb")
            {
                fileType.Text = "Ruby Script";
            }
            else if (CurentFile.Extension == ".sh")
            {
                fileType.Text = "Shell Script";
            }
            else if (CurentFile.Extension == ".bat")
            {
                fileType.Text = "Batch File";
            }
            else if (CurentFile.Extension == ".apk")
            {
                fileType.Text = "Android Package";
            }
            else if (CurentFile.Extension == ".iso")
            {
                fileType.Text = "ISO Disk Image";
            }
            else if (CurentFile.Extension == ".dmg")
            {
                fileType.Text = "Disk Image";
            }
            else if (CurentFile.Extension == ".pdb")
            {
                fileType.Text = "Program Database";
            }
            else if (CurentFile.Extension == ".dll")
            {
                fileType.Text = "Dynamic Link Library";
            } 



            if (CurentFile.Name.Contains("."))
            {
                int index = CurentFile.Name.IndexOf(".");
                String tempName = CurentFile.Name.Substring(0, index);
                fileName.Text = tempName;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(CurentFile.FullName);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
