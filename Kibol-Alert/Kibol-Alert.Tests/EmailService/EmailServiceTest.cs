using Xunit;
using Kibol_Alert.Services.EmailService;
using System;

namespace Kibol_Alert.Tests.EmailService
{
    public class EmailServiceTest
    {
        public EmailServiceTest()
        {
           

        }

        bool IsValidEmail(string email) {
            try {
                var email_address = System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch {  
                return false;
            }
        }

        [Theory]
        [InlineData("makapaka@outlook.com", "topic", "Kiedyś to było")]
        public async void SendAsyncEmail(string email, string subject, string message) {
            string FromAddress = "kibol-alert@outlook.com";
            string FromAdressTitle = "Kibol Alert";
            string ToAddress = email;
            string ToAdressTitle = "Użytkownik";
            string SmtpServer = "smtp.live.com";
            string Subject = subject;
            string BodyContent = message;
            int SmtpPortNumber = 587; 

            if (Assert.Equal(IsValidEmail(FromAddress), true) && Assert.Equal(IsValidEmail(ToAddress), true))
            {
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
                    var connect_result = client.Connect(SmtpServer, SmtpPortNumber, false);
                    if (Assert.Equal(connect_result.Succeeded, excepted)) {
                        
                        var result_send = await client.SendAsync(mimeMessage);
                        Assert.Equal(result_send.Succeeded, excepted);

                         var result_disc = await client.SendAsync(mimeMessage);
                        Assert.Equal(result_disc.Succeeded, excepted);

                    }

                }

                
                
            }
           


        }






        
        
    }
}