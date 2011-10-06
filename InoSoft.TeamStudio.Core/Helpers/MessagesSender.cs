using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using InoSoft.TeamStudio.Core.Entities;
using System.Net.Mail;
using System.Net;

namespace InoSoft.TeamStudio.Core.Helpers
{
    class MessagesSender
    {
        //private string Parse(User user, int languageLetterId)
        //{
        //    using (var manager = new DataManager())
        //    {
        //        string ParsedText = manager.Context.LanguageLetters.SingleOrDefault(u => u.LanguageLetterId == languageLetterId).ToString();
        //        ParsedText.
        //    }
        //}
        
        public void Send(User user)
        {
            SmtpClient Smtp = new SmtpClient("plus.smtp.mail.yahoo.com", 465);
            Smtp.Credentials = new NetworkCredential("inosoft@ymail.com","AllForHome");

            MailMessage Message = new MailMessage();
            Message.From = new MailAddress("inosoft@ymail.com");
            Message.To.Add(user.Email);
            Message.Subject = "Круто же, получилось";
            Message.Body = "Круто же, получилось";

            Smtp.Send(Message);
        }
    }
}
