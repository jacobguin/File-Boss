using Middle;
using System.Collections.Specialized;

namespace File_Boss;

public partial class TabUI : UserControl
{
	public TabUI()
	{
		InitializeComponent();
	}

	public event Func<ItemView, Task>? RequestNewTab;
	public event Func<Task>? RequestRefreash;

	public required BackFunctions functionHandler { get; set; }
	public static List<ItemView> SelectedViews { get; set; } = new();

	private void backButton_Click(object sender, EventArgs e)
	{
		DirectoryInfo di = Directory.GetParent(functionHandler.BasePath)!;
		functionHandler.BasePath = di.FullName;
		functionHandler.AddUIUndoAction(updateItemDisplay);
		updateItemDisplay();
		pathText.Text = di.FullName;
		Text = di.Name;
		if (RequestRefreash is not null) RequestRefreash.Invoke();
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
		ItemView iv;
		if (flowLayoutPanel1.FlowDirection == FlowDirection.LeftToRight)
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
		if (arg.CurrentFile is not null)
		{
			string fileName = arg.CurrentFile.Name;
			functionHandler.Open(fileName);
		}
		else
		{
			functionHandler.BasePath = Path.Join(functionHandler.BasePath, arg.CurrentDirectory!.Name);
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
		if (arg.CurrentFile is null)
		{
			var result = MessageBox.Show($"Are you sure you want to delete the folder '{arg.CurrentDirectory.Name}'?",
				"Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (result == DialogResult.Yes)
			{
				try
				{
					functionHandler.DeleteFolder(arg.CurrentDirectory.Name);
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
			var result = MessageBox.Show($"Are you sure you want to delete the file '{arg.CurrentFile.Name}'?",
				"Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (result == DialogResult.Yes)
			{
				try
				{
					functionHandler.DeleteFile(arg.CurrentFile.Name);
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
}
