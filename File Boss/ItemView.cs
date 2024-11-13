using Middle;
using System.Diagnostics.CodeAnalysis;

namespace File_Boss;

public class ItemView : UserControl
{
	public virtual void LoadFolder(string Folder, BackFunctions functionHandler, TabUI t)
	{

	}

	public virtual void LoadFile(string File, Icon icon, BackFunctions functionHandler, TabUI t)
	{

	}

	public virtual void ShowSelected()
	{

	}

	public virtual void ShowNotSelected()
	{

	}

	public FileInfo? CurrentFile { get; protected set; }
	public DirectoryInfo? CurrentDirectory { get; protected set; }
	public event Func<ItemView, Task>? OnAllSingleLClick;
	public event Func<ItemView, Task>? OnAllSingleRClick;
	public event Func<ItemView, Task>? OnAllClick;
	public event Func<ItemView, Task>? OnDelete;
	public event Func<ItemView, Task>? RequestUpdate;
	public event Func<ItemView, Task>? RequestNewTab;
	public event Func<Task>? RequestEmaile;
	public event Func<Task>? RequestCopy;

	public void CallOnAllSingleLClick()
	{
		if (OnAllSingleLClick is not null) OnAllSingleLClick.Invoke(this);
	}
	public void CallOnAllSingleRClick()
	{
		if (OnAllSingleRClick is not null) OnAllSingleRClick.Invoke(this);
	}
	public void CallOnAllClick()
	{
		if (OnAllClick is not null) OnAllClick.Invoke(this);
	}
	public void CallOnDelete()
	{
		if (OnDelete is not null) OnDelete.Invoke(this);
	}
	public void CallRequestUpdate()
	{
		if (RequestUpdate is not null) RequestUpdate.Invoke(this);
	}
	public void CallRequestNewTab()
	{
		if (RequestNewTab is not null) RequestNewTab.Invoke(this);
	}
	public void CallRequestEmaile()
	{
		if (RequestEmaile is not null) RequestEmaile.Invoke();
	}
	public void CallRequestCopy()
	{
		if (RequestCopy is not null) RequestCopy.Invoke();
	}
}
