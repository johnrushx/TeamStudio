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
        private string Parse(User user, int languageLetterId)
        {
            using (var manager = new DataManager())
            {
                string ParsedText = manager.Context.LanguageLetters.SingleOrDefault(u => u.LanguageLetterId == languageLetterId).Template;
                Dictionary<string, string> PatternsAndValues = new Dictionary<string, string>()
                {
                    {"{fullname}", user.FirstName+" "+user.LastName},
                    {"{username}", user.UserName}
                };
                foreach (var pair in PatternsAndValues)
                {
                    Regex RegularExpression = new Regex(pair.Key);
                    ParsedText = RegularExpression.Replace(ParsedText, pair.Value);
                }
                return ParsedText;
            }
        }
        
        public void Send(User user)
        {
            SmtpClient Smtp = new SmtpClient("smtp.gmail.com", 587);
            Smtp.Credentials = new NetworkCredential("inosoftts@gmail.com","AllForHome");
            Smtp.EnableSsl = true;

            MailMessage Message = new MailMessage();
            Message.From = new MailAddress("inosoftts@gmail.com");
            Message.To.Add(user.Email);
            Message.Subject = "Тема";
            Message.Body = Parse(user,2);

            Smtp.Send(Message);
        }
    }
}
