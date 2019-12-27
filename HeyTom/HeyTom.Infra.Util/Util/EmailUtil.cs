using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HeyTom.Infra.Util.Util
{
	public static class EmailUtil
	{
		public static ResultModel Send(List<string> toEmail, string subject, string content, string fromName, string userName = null, string host = "smtp.qq.com", string fromEmail = "420994592@qq.com", string passWord = "tcjiawjzjfodbifd")
		{
			var result = new ResultModel(1);
			SmtpClient smtpClient = new SmtpClient
			{
				Host = host,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(fromEmail, passWord),
				EnableSsl = true
			};
			try
			{
				MailAddress from = new MailAddress(fromEmail);
				var mailMessage = new MailMessage
				{
					From = from,
					Subject = subject,
					Body = content,
					BodyEncoding = Encoding.Default,
					IsBodyHtml = true,
					Priority = MailPriority.Normal,
				};
				toEmail?.ForEach(ea=> {
					mailMessage.To.Add(ea);
				});
				smtpClient.Send(mailMessage);
			}
			catch (Exception ex)
			{
				result.ResultNo = -1;
				result.Message = ex.Message;
			}
			return result;
		}
	}
}
