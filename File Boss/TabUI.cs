using Middle;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace File_Boss;

public partial class TabUI : UserControl
{
	private string currentDirectory;

	public TabUI()
	{
		InitializeComponent();
		listBoxResults.Visible = false;
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		string downloads = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
		string music = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
		string pictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
		string videos = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

		addFolderDisplay(new DirectoryInfo(desktop), true);
		addFolderDisplay(new DirectoryInfo(documents), true);
		addFolderDisplay(new DirectoryInfo(downloads), true);
		addFolderDisplay(new DirectoryInfo(music), true);
		addFolderDisplay(new DirectoryInfo(pictures), true);
		addFolderDisplay(new DirectoryInfo(videos), true);
	}

	public event Func<ItemView, Task>? RequestNewTab;
	public event Func<Task>? RequestRefreash;

    public required BackFunctions functionHandler { get; set; }
    public List<ItemView> SelectedViews { get; set; } = new();

	private void backButton_Click(object sender, EventArgs e)
	{
		DirectoryInfo di = Directory.GetParent(functionHandler.BasePath)!;
		try
		{
			currentDirectory = di.FullName;
			functionHandler.BasePath = di.FullName;
			functionHandler.AddUIUndoAction(updateItemDisplay);
			updateItemDisplay();
			pathText.Text = di.FullName;
			Text = di.Name;
			if (RequestRefreash is not null) RequestRefreash.Invoke();
			UpdateSearchResults(currentDirectory);
		}
		catch (Exception ee)
		{
			MessageBox.Show($"Error: {ee.Message}");
		}
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
			iv.ShowNotSelected();
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
		DirectoryInfo di = new(functionHandler.BasePath);
		if (reverse)
		{
			foreach (DirectoryInfo fi in di.GetDirectories().OrderBy(file => Regex.Replace(file.Name, @"\d+", match => match.Value.PadLeft(4, '0'))).Reverse())
			{
				addFolderDisplay(fi);
			}
			foreach (FileInfo fi in di.GetFiles().OrderBy(file => Regex.Replace(file.Name, @"\d+", match => match.Value.PadLeft(4, '0'))).Reverse())
			{
				addFileDisplay(fi);
			}
		}
		else
		{
			foreach (DirectoryInfo fi in di.GetDirectories().OrderBy(file => Regex.Replace(file.Name, @"\d+", match => match.Value.PadLeft(4, '0'))))
			{
				addFolderDisplay(fi);
			}
			foreach (FileInfo fi in di.GetFiles().OrderBy(file =>Regex.Replace(file.Name, @"\d+", match => match.Value.PadLeft(4, '0'))))
			{
				addFileDisplay(fi);
			}
		}
		
		SelectedViews.Clear();
		flowLayoutPanel1.ResumeLayout();
		flowLayoutPanel1.PerformLayout();
	}

	public ItemView CreateBoth(bool side = false)
	{
		ItemView iv;
		if (side)
		{
			iv = new SideBarItemView();
		}
		else if (flowLayoutPanel1.FlowDirection == FlowDirection.LeftToRight)
		{
			iv = new ItemViewTile();
		}
		else
		{
			iv = new ItemViewContent();
			iv.Size = new Size(flowLayoutPanel1.Size.Width, iv.Size.Height);
		}
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

    public void addFolderDisplay(DirectoryInfo di, bool side = false)
    {
        ItemView iv = CreateBoth(side);
        iv.LoadFolder(di.FullName, functionHandler, this);
        (side ? flowLayoutPanel2 : flowLayoutPanel1).Controls.Add(iv);
    }

    public ItemView addFileDisplay(FileInfo fi)
    {
        ItemView iv = CreateBoth();
        Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)!;
        iv.LoadFile(fi.FullName, icon, functionHandler, this);
        flowLayoutPanel1.Controls.Add(iv);
        return iv;
    }

	#region ItemViewTasks
	private Task ItemViewOpenClick(ItemView arg)
	{
		if (arg.CurrentFile is not null)
		{
			string fileName = arg.CurrentFile.Name;
			functionHandler.Open(fileName);
		}
		else
		{
			functionHandler.BasePath = arg.CurrentDirectory!.FullName;

			if (homepage1.Visible)
			{
				homepage1.Visible = !homepage1.Visible;
				flowLayoutPanel1.Visible = !flowLayoutPanel1.Visible;
			}
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
				iv.ShowNotSelected();
			}
			SelectedViews.Clear();
			arg.ShowSelected();
			SelectedViews.Add(arg);
		}
		else
		{

			if (SelectedViews.Contains(arg))
			{
				if (SelectedViews.Count == 1) return Task.CompletedTask;
				arg.ShowNotSelected();
				SelectedViews.Remove(arg);
			}
			else
			{
				arg.ShowSelected();
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
		bool update = false;

		foreach (ItemView iv in SelectedViews)
		{
			try
			{
				if (iv is SideBarItemView) continue;
				if (iv.CurrentFile is not null && iv.CurrentFile.Exists) iv.CurrentFile.Delete();
				if (iv.CurrentDirectory is not null && iv.CurrentDirectory.Exists) iv.CurrentDirectory.Delete();
				if (!homepage1.Visible)
				{
					flowLayoutPanel1.Controls.Remove(iv);
				}
				else
				{
					iv.Parent!.Controls.Remove(iv);
				}
			}
			catch { update = true; }
		}

		if (update) updateItemDisplay();
		return Task.CompletedTask;
	}

    private Task ItemViewRequestEmail()
    {
        List<string> paths = new();
        List<string> Dips = new();
        foreach (ItemView item in SelectedViews)
        {
            if (item.CurrentFile is not null)
            {
                if (item.CurrentFile.Name.ToLower().EndsWith(".zip"))
                {
                    paths.Add(item.CurrentFile.FullName);
                }
                else
                {
                    Dips.Add(item.CurrentFile.FullName);
                }
            }
            else Dips.Add(item.CurrentDirectory!.FullName);
        }
        string? zip = null;
        if (Dips.Count >0)
        {
			zip = Path.GetRandomFileName() + ".zip";
			functionHandler.ZipData(zip, Dips.ToArray());
			paths.Add(Path.Join(functionHandler.BasePath, zip));
		}
        
        EmailPrompt EP = new()
        {
            PathsToZips = paths.ToArray(),
            Functions = functionHandler
        };
        EP.ShowDialog();
        EP.Dispose();
        if (zip is not null)
        {
            try
            {
                functionHandler.DeleteFile(zip);
            }
            catch { }
        }
        return Task.CompletedTask;
    }

	private Task ItemViewRequestCopy()
	{
		StringCollection strings = new();
		foreach (ItemView item in SelectedViews)
		{
			if (item.CurrentFile is not null)
			{
				strings.Add(item.CurrentFile.FullName);
			}
			else
			{
				strings.Add(item.CurrentDirectory!.FullName);
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

	private void button3_Click(object sender, EventArgs e)
	{
		if (flowLayoutPanel1.FlowDirection == FlowDirection.LeftToRight)
		{
			flowLayoutPanel1.Resize += flowLayoutPanel1_Resize;
			flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
			flowLayoutPanel1.WrapContents = false;
		}
		else
		{
			flowLayoutPanel1.Resize -= flowLayoutPanel1_Resize;
			flowLayoutPanel1.WrapContents = true;
			flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
		}
		updateItemDisplay();
	}

	private void flowLayoutPanel1_Resize(object? sender, EventArgs e)
	{
		for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
		{
			flowLayoutPanel1.Controls[i].Size = new(flowLayoutPanel1.Size.Width - SystemInformation.VerticalScrollBarWidth - SystemInformation.VerticalScrollBarWidth - 5, flowLayoutPanel1.Controls[i].Size.Height);
		}
	}

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
		string selectedFileName = big_justice[listBoxResults.SelectedIndex];

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

	private List<string> big_justice = new();
	private void UpdateSearchResults(string directory)
	{
		listBoxResults.Items.Clear();
		big_justice.Clear();
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
					big_justice.Add(result.Replace(functionHandler.BasePath, "").Remove(0, 1));
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

    private void homeButton_Click(object sender, EventArgs e)
    {
        if (homepage1.parent is null)
        {
            homepage1.parent = this;
            homepage1.LoadCommonDir(this);
            homepage1.functionHandler = functionHandler;
        }
        homepage1.Visible = !homepage1.Visible;
        flowLayoutPanel1.Visible = !flowLayoutPanel1.Visible;
        if (homepage1.Visible)
        {
            Text = "Home";
            pathText.Text = "Home";
            homepage1.LoadFavorites(this);
        }
        else
        {
            Text = new DirectoryInfo(functionHandler.BasePath).Name;
            pathText.Text = new DirectoryInfo(functionHandler.BasePath).FullName;
        }
        if (RequestRefreash is not null) RequestRefreash.Invoke();
    }

	bool reverse = false;

	private void button4_Click(object sender, EventArgs e)
	{
		reverse = !reverse;
		updateItemDisplay();
	}
}
