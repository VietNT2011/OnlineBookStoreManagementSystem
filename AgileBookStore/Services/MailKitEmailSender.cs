using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Net.Mail;
using System.Threading.Tasks;
namespace AgileBookStore.Services
{
	public class MailKitEmailSender
	{
		List<string> errors = new List<string>();
		public async Task<bool> SendEmailAsync(string email, string subject, string confirmLink)
		{
			try
			{
				var message = new MimeMessage();
				message.From.Add(new MailboxAddress("AEBookStore", "AgileEnterprise.com.vn"));
				message.To.Add(new MailboxAddress(" ", email));
				message.Subject = subject;

				// Create the HTML body
				var bodyBuilder = new BodyBuilder();
				bodyBuilder.HtmlBody = confirmLink;
				message.Body = bodyBuilder.ToMessageBody();

				using (var client = new MailKit.Net.Smtp.SmtpClient())
				{
					await client.ConnectAsync("smtp.gmail.com", 587, false);
					await client.AuthenticateAsync("vietwwezxc@gmail.com", "rieo ibmu ibnj snzj");
					await client.SendAsync(message);
					await client.DisconnectAsync(true);
				}
				errors.Add("True");
				return true;
			}
			catch (Exception ex)
			{
				errors.Add(ex.ToString());
				return false;
			}
		}
	}
}

