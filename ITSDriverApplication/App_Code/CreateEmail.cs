using System;
using System.Net.Mail;

namespace ITSDriverApplication.App_Code
{
    public class CreateEmail
    {
        public static bool SendEmail(string Recipient, string Subject, string Body)
        {
            MailMessage Email = new MailMessage();

            Email.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["fromEmailAddress"]);
            Email.To.Add(Recipient);
            //Email.To.Add(new MailAddress(Recipient));

            Email.Subject = Subject;
            Email.Body = Body;
            Email.IsBodyHtml = true;

            SmtpClient Client = new SmtpClient();

            try
            {
                Client.Send(Email);
            }
            catch (SmtpException err)
            {
                throw new ApplicationException(err.Message);
            }

            return true;
        }
    }
}
