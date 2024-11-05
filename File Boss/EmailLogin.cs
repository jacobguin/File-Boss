using Middle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Boss
{
	public partial class EmailLogin : Form
	{
		public EmailLogin()
		{
			InitializeComponent();
		}
		private BackFunctions bf;

		public required BackFunctions Functions
		{
			get
			{
				return bf;
			}
			init
			{
				bf = value;
				EmailInfo set = value.GetSettings("email_info.json", EmailInfoContext.Default.EmailInfo);
				FromtextBox1.Text = set.Email;
				PasswordtextBox1.Text = set.Password;
				DisplayNametextBox.Text = set.DisplayName;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			EmailInfo ei = new()
			{
				DisplayName = DisplayNametextBox.Text,
				Password = PasswordtextBox1.Text,
				Email = FromtextBox1.Text
			};
			Functions.SaveSettings("email_info.json", ei, EmailInfoContext.Default.EmailInfo);
			Close();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			OpenUrl("https://myaccount.google.com/apppasswords");
		}

		private void OpenUrl(string url)
		{
			try
			{
				Process.Start(url);
			}
			catch
			{
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				{
					url = url.Replace("&", "^&");
					Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
				}
				else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
				{
					Process.Start("xdg-open", url);
				}
				else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
				{
					Process.Start("open", url);
				}
				else
				{
					throw;
				}
			}
		}
	}
}
