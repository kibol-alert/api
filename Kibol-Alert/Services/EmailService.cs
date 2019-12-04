using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kibol_Alert.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace Kibol_Alert.Services
{
    public class EmailService : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                //From Address  
                string FromAddress = "kibol-alert@outlook.com";
                string FromAdressTitle = "Kibol Alert";
                //To Address  
                string ToAddress = email;
                string ToAdressTitle = "Użytkownik";
                string Subject = subject;
                string BodyContent = message;

                //Smtp Server  
                string SmtpServer = "smtp.live.com";
                //Smtp Port Number  
                int SmtpPortNumber = 587;

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress
                                        (FromAdressTitle,
                                         FromAddress
                                         ));
                mimeMessage.To.Add(new MailboxAddress
                                         (ToAdressTitle,
                                         ToAddress
                                         ));
                mimeMessage.Subject = Subject; //Subject
                mimeMessage.Body = new TextPart("plain")
                {
                    Text = BodyContent
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(SmtpServer, SmtpPortNumber, false);
                    client.Authenticate(
                        "kibol-alert@outlook.com",
                        "KibolAlert"
                        );
                    await client.SendAsync(mimeMessage);
                    Console.WriteLine("The mail has been sent successfully !!");
                    Console.ReadLine();
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
