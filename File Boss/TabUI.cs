using Middle;
using System.Collections.Specialized;
using System.Diagnostics;

namespace File_Boss;

public partial class TabUI : UserControl
{
    private string currentDirectory;

    public TabUI()
    {
        InitializeComponent();
        listBoxResults.Visible = false;
        string currentDirectory = Environment.CurrentDirectory;
    }

    public event Func<ItemView, Task>? RequestNewTab;
    public event Func<Task>? RequestRefreash;

    public required BackFunctions functionHandler { get; set; }
    public static List<ItemView> SelectedViews { get; set; } = new();

    private void backButton_Click(object sender, EventArgs e)
    {
        DirectoryInfo di = Directory.GetParent(functionHandler.BasePath)!;
        currentDirectory = di.FullName;
        functionHandler.BasePath = di.FullName;
        functionHandler.AddUIUndoAction(updateItemDisplay);
        updateItemDisplay();
        pathText.Text = di.FullName;
        Text = di.Name;
        if (RequestRefreash is not null) RequestRefreash.Invoke();
        UpdateSearchResults(currentDirectory);
    }


    private void button1_Click(object sender, EventArgs e)
    {
        CreateItem ci = new();
        ci.Text = "File Create";
        ci.ShowDialog();
        string fileName = ci.textBox1.Text;
        if (fileName.Contains('.'))
        {
            functionHandler.CreateFile(fileName);
        }
        else
        {
            String defaultExt = fileName + ".txt";
            functionHandler.CreateFile(defaultExt);
        }
        functionHandler.AddUIUndoAction(updateItemDisplay);
        updateItemDisplay();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        CreateItem ci = new();
        ci.Text = "Folder Create";
        ci.ShowDialog();
        string folderName = ci.textBox1.Text;
        functionHandler.CreateFolder(folderName);
        functionHandler.AddUIUndoAction(updateItemDisplay);
        updateItemDisplay();
    }

    private void flowLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
    {
        foreach (ItemView iv in SelectedViews)
        {
            iv.BackColor = SystemColors.Control;
            iv.pictureBox1.BackColor = SystemColors.Control;
        }
        SelectedViews.Clear();
    }

    private void emailSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        EmailLogin el = new()
        { Functions = functionHandler };
        el.ShowDialog();
    }

    private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        StringCollection colection = Clipboard.GetFileDropList();
        functionHandler.PastFilesAndFolders(colection);
        functionHandler.AddUIUndoAction(() => { updateItemDisplay(); });
        updateItemDisplay();
    }

    private void undoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        functionHandler.Undo();
    }

    private void TabUI_Load(object sender, EventArgs e)
    {
        DirectoryInfo di = new(functionHandler.BasePath);
        pathText.Text = di.FullName;
        Text = di.Name;
        updateItemDisplay();
    }

    public void updateItemDisplay()
    {
        flowLayoutPanel1.SuspendLayout();
        flowLayoutPanel1.Controls.Clear();
        DirectoryInfo di = new DirectoryInfo(functionHandler.BasePath);
        foreach (DirectoryInfo fi in di.GetDirectories())
        {
            addFolderDisplay(fi);
        }
        foreach (FileInfo fi in di.GetFiles())
        {
            addFileDisplay(fi);
        }
        SelectedViews.Clear();
        flowLayoutPanel1.ResumeLayout();
        flowLayoutPanel1.PerformLayout();
    }

    private ItemView CreateBoth()
    {
        ItemView iv = new();
        iv.OnAllClick += ItemViewOpenClick;
        iv.RequestUpdate += ItemViewRequestUpdate;
        iv.OnAllSingleLClick += ItemViewSingleLeftClick;
        iv.OnAllSingleRClick += ItemViewSingleRightClick;
        iv.OnDelete += ItemViewRequestDelete;
        iv.RequestEmaile += ItemViewRequestEmail;
        iv.RequestCopy += ItemViewRequestCopy;
        iv.RequestNewTab += ItemViewRequestNewTab;
        return iv;
    }

    public void addFolderDisplay(DirectoryInfo di)
    {
        ItemView iv = CreateBoth();
        iv.LoadFolder(di.FullName, functionHandler);
        flowLayoutPanel1.Controls.Add(iv);
    }

    public ItemView addFileDisplay(FileInfo fi)
    {
        ItemView iv = CreateBoth();
        Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)!;
        iv.LoadFile(fi.FullName, icon, functionHandler);
        flowLayoutPanel1.Controls.Add(iv);
        return iv;
    }

    #region ItemViewTasks
    private Task ItemViewOpenClick(ItemView arg)
    {
        if (arg.CurentFile is not null)
        {
            string fileName = arg.label1.Text;
            functionHandler.Open(fileName);
        }
        else
        {
            functionHandler.BasePath = Path.Join(functionHandler.BasePath, arg.CurentDirectory!.Name);
            functionHandler.AddUIUndoAction(() => { updateItemDisplay(); });
            updateItemDisplay();
            pathText.Text = functionHandler.BasePath;
            Text = new DirectoryInfo(functionHandler.BasePath).Name;
            if (RequestRefreash is not null) RequestRefreash.Invoke();
        }

        return Task.CompletedTask;
    }

    private Task ItemViewRequestUpdate(ItemView arg)
    {
        updateItemDisplay();
        return Task.CompletedTask;
    }

    private Task ItemViewSingleLeftClick(ItemView arg)
    {
        if (Control.ModifierKeys != Keys.Control)
        {
            foreach (ItemView iv in SelectedViews)
            {
                iv.BackColor = SystemColors.Control;
                iv.pictureBox1.BackColor = SystemColors.Control;
            }
            SelectedViews.Clear();
            arg.BackColor = Color.CornflowerBlue;
            arg.pictureBox1.BackColor = Color.CornflowerBlue;
            SelectedViews.Add(arg);
        }
        else
        {

            if (SelectedViews.Contains(arg))
            {
                if (SelectedViews.Count == 1) return Task.CompletedTask;
                arg.BackColor = SystemColors.Control;
                arg.pictureBox1.BackColor = SystemColors.Control;
                SelectedViews.Remove(arg);
            }
            else
            {
                arg.BackColor = Color.CornflowerBlue;
                arg.pictureBox1.BackColor = Color.CornflowerBlue;
                SelectedViews.Add(arg);
            }
        }

        return Task.CompletedTask;
    }

    private Task ItemViewSingleRightClick(ItemView arg)
    {
        if (SelectedViews.Count == 0 || !SelectedViews.Contains(arg))
        {
            ItemViewSingleLeftClick(arg);
        }
        return Task.CompletedTask;
    }

    private Task ItemViewRequestDelete(ItemView arg)
    {
        if (arg.CurentFile is null)
        {
            var result = MessageBox.Show($"Are you sure you want to delete the folder '{arg.CurentDirectory.Name}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    functionHandler.DeleteFolder(arg.CurentDirectory.Name);
                    MessageBox.Show("Folder successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    updateItemDisplay();
                }
                catch (UIException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        else
        {
            var result = MessageBox.Show($"Are you sure you want to delete the file '{arg.CurentFile.Name}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    functionHandler.DeleteFile(arg.CurentFile.Name);
                    MessageBox.Show("File successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    updateItemDisplay();
                }
                catch (UIException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        return Task.CompletedTask;
    }

    private Task ItemViewRequestEmail()
    {
        List<string> paths = new();
        List<string> Dips = new();
        foreach (ItemView item in SelectedViews)
        {
            if (item.CurentFile is not null)
            {
                if (item.CurentFile.Name.ToLower().EndsWith(".zip"))
                {
                    paths.Add(item.CurentFile.FullName);
                }
                else
                {
                    Dips.Add(item.CurentFile.FullName);
                }
            }
            else Dips.Add(item.CurentDirectory!.FullName);
        }
        string zip = Path.GetRandomFileName() + ".zip";
        functionHandler.ZipData(zip, Dips.ToArray());
        paths.Add(Path.Join(functionHandler.BasePath, zip));
        EmailPrompt EP = new()
        {
            PathsToZips = paths.ToArray(),
            Functions = functionHandler
        };
        EP.ShowDialog();
        return Task.CompletedTask;
    }

    private Task ItemViewRequestCopy()
    {
        StringCollection strings = new();
        foreach (ItemView item in SelectedViews)
        {
            if (item.CurentFile is not null)
            {
                strings.Add(item.CurentFile.FullName);
            }
            else
            {
                strings.Add(item.CurentDirectory!.FullName);
            }
        }
        Clipboard.SetFileDropList(strings);
        return Task.CompletedTask;
    }

    private Task ItemViewRequestNewTab(ItemView arg)
    {
        if (RequestNewTab is not null) RequestNewTab.Invoke(arg);
        return Task.CompletedTask;
    }
    #endregion

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        string currentDirectory = functionHandler.BasePath;
        UpdateSearchResults(currentDirectory);
    }

    private void AdjustListBoxHeight(int itemCount)
    {
        int itemHeight = listBoxResults.ItemHeight;
        int newHeight = itemCount * itemHeight;

        newHeight = Math.Min(newHeight, 200);
        newHeight = Math.Max(newHeight, 30);

        listBoxResults.Height = newHeight;
    }


    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedFileName = listBoxResults.SelectedItem.ToString();

        string fullFilePath = Path.Combine(functionHandler.BasePath, selectedFileName);

        if (File.Exists(fullFilePath))
        {
            Process.Start(new ProcessStartInfo(fullFilePath) { UseShellExecute = true });
        }
        else
        {
            MessageBox.Show("File not found.");
        }
    }
    private void UpdateSearchResults(string directory)
    {
        listBoxResults.Items.Clear();
        string searchTerm = textBox1.Text;

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            List<string> results = functionHandler.SearchFilesAndDirectories(directory, $"*{searchTerm}*");
            if (results.Count > 0)
            {
                listBoxResults.Visible = true;
                foreach (var result in results)
                {
                    string fileNameWithExtension = Path.GetFileName(result);
                    listBoxResults.Items.Add(fileNameWithExtension);
                }

                AdjustListBoxHeight(results.Count);
            }
            else
            {
                listBoxResults.Visible = false;
            }
        }
        else
        {
            listBoxResults.Visible = false;
        }
    }
}
