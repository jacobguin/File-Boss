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

namespace File_Boss;

public partial class SideBarItemView : ItemView
{
	private ToolStripMenuItem? fav, zip, uzip, Tab;
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

    private BackFunctions functionHandler;

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

	private void Tab_Click(object? sender, EventArgs e)
	{
		CallRequestNewTab();
	}

	private void Zip_Click(object? sender, EventArgs e)
	{
		if (CurrentDirectory != null && !CurrentDirectory.Name.EndsWith(".zip"))
		{
			functionHandler.ZipFolder(CurrentDirectory.Name);
			CallRequestUpdate();
			MessageBox.Show("Folder successfully zipped!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		else
		{
			MessageBox.Show("This item is already zipped or is not a folder.", "Cannot Zip", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

	}

	private void Uzip_Click(object? sender, EventArgs e)
	{
		if (CurrentFile != null && CurrentFile.Extension == ".zip")
		{
			functionHandler.UnzipFolder(CurrentFile.Name, Path.GetFileNameWithoutExtension(CurrentFile.FullName));
			CallRequestUpdate();
			MessageBox.Show("Folder successfully unzipped!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		else
		{
			MessageBox.Show("This item is not a zip file.", "Cannot Unzip", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}

	private void Tsm_Click(object? sender, EventArgs e)
	{
		functionHandler.AddFavorites(label1.Text);
		fav!.Enabled = false;
	}

	private void AllSingleClick(object? sender, MouseEventArgs e)
	{
		if (e is not null && e.Button == MouseButtons.Left)
		{
			CallOnAllSingleLClick();
		}
		else if (e is null || e.Button == MouseButtons.Right)
		{
			CallOnAllSingleRClick();
		}
	}

	private void AllDoubleClick(object sender, MouseEventArgs e)
	{
		CallOnAllClick();
	}

	private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
	{
		CallOnDelete();
	}
	private void CreateShortcutMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			if (CurrentFile != null)
			{
				functionHandler.CreateFileShortcut(CurrentFile.FullName);
			}
			else if (CurrentDirectory != null)
			{
				functionHandler.CreateFileShortcut(CurrentDirectory.FullName);
			}
			else
			{
				throw new UIException("No file or directory is currently selected.");
			}

			MessageBox.Show("Shortcut created on desktop successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		catch (UIException ex)
		{
			MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
	private System.Windows.Forms.TextBox? renameBox;
	private void renameToolStripMenuItem_Click(object sender, EventArgs e)
	{
		renameBox = new()
		{
			Text = label1.Text
		};
		label1.Visible = false;
		renameBox.Location = new System.Drawing.Point(18, 95);
		renameBox.Size = new System.Drawing.Size(70, 20);
		this.Controls.Add(renameBox);
		renameBox.KeyPress += rename_Item;
	}
	private void rename_Item(object? sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != (char)Keys.Enter) return;

		System.Windows.Forms.TextBox temp = (System.Windows.Forms.TextBox)sender!;
		String oldName = label1.Text;
		label1.Text = temp.Text;
		if (oldName.Contains('.'))
		{
			if (!temp.Text.Contains('.'))
			{
				String defaultExt = Path.GetExtension(oldName);
				String newName = label1.Text + defaultExt;
				functionHandler.RenameFile(oldName, newName);
				functionHandler.AddUIUndoAction(CallRequestUpdate);
				MessageBox.Show(oldName + " was renamed to " + newName + ". No extension was specified. The file was defaulted to original.");
			}
			else
			{
				functionHandler.RenameFile(oldName, temp.Text);
				functionHandler.AddUIUndoAction(CallRequestUpdate);
				MessageBox.Show(oldName + " was renamed to " + temp.Text);
			}
		}
		else
		{
			functionHandler.RenameFolder(oldName, temp.Text);
			functionHandler.AddUIUndoAction(CallRequestUpdate);
			MessageBox.Show(oldName + " was renamed to " + temp.Text);
		}
		Controls.Remove(temp);
		label1.Visible = true;
		CallRequestUpdate();
	}
	private void copyToolStripMenuItem_Click(object sender, EventArgs e)
	{
		String path = CurrentFile!.FullName;
		Clipboard.SetText(path);
	}
	private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
	{
		File_Properties_Form fp = new();
		fp.load_file(CurrentFile!);
		fp.Show();
	}
	private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
	{
		AllSingleClick(sender, null!);
	}
	public void copyToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		CallRequestCopy();
	}
	private void sendOverEmailToolStripMenuItem_Click(object sender, EventArgs e)
	{
		CallRequestEmaile();
	}
	public override void ShowSelected()
	{
		BackColor = Color.CornflowerBlue;
		pictureBox1.BackColor = Color.CornflowerBlue;
	}
	public override void ShowNotSelected()
	{
		BackColor = SystemColors.Control;
		pictureBox1.BackColor = SystemColors.Control;
	}
}
