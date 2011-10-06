using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using InoSoft.TeamStudio.Core.Entities;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace InoSoft.TeamStudio.Core.Helpers
{
    class MessagesSender
    {
        //private string Parse(User user, int languageLetterId)
        //{
        //    using (var manager = new DataManager())
        //    {
        //        string ParsedText = manager.Context.LanguageLetters.SingleOrDefault(u => u.LanguageLetterId == languageLetterId).ToString();
        //        string Pattern = "{+[a-z]+}";
        //        Regex RegularExpression = new Regex(Pattern);
        //        RegularExpression.Match(ParsedText).

        //    }
        //}
        
        public void Send(User user)
        {
            SmtpClient Smtp = new SmtpClient("plus.smtp.mail.yahoo.com", 465);
            Smtp.Credentials = new NetworkCredential("inosoft@ymail.com","AllForHome");

            MailMessage Message = new MailMessage();
            Message.From = new MailAddress("inosoft@ymail.com");
            Message.To.Add(user.Email);
            Message.Subject = "Тема";
            Message.Body = "Текст";

            Smtp.Send(Message);
        }
    }
}
