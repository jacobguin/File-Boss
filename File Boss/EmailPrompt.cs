using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Boss
{
	public partial class EmailPrompt : Form
	{
		public EmailPrompt()
		{
			InitializeComponent();
		}

		public required string[] PathsToZips { get; init; }

		private void button1_Click(object sender, EventArgs e)
		{
			var fromAddress = new MailAddress(FromtextBox1.Text);
			var toAddress = new MailAddress(SendTotextBox.Text);
			SmtpClient smtp = new()
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(fromAddress.Address, PasswordtextBox1.Text)
			};
			MailMessage message = new(fromAddress, toAddress)
			{
				Subject = SubjecttextBox2.Text,
				Body = "Attached to this email is the ziped data."
			};
			foreach (string s in PathsToZips)
			{
				message.Attachments.Add(new Attachment(s));
			}
			smtp.Send(message);
		}
	}
}
