using System.Net.Mail;

namespace Spg.SpengerSearch.CoreApplication
{
    public class Mailer
    {
        public void SendEMail()
        {
            var message = new MailMessage(new MailAddress("jelinek@spengergasse.at"), new MailAddress("3AHIF@spengergasse.at;"));
            message.Subject = "Wahlpflichtfach";
            message.Body = "<h1><a href='https://e-formular.spengrgasse.at'>https://e-formular.spengergasse.at</a></h1>";
            message.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("??");
            smtpClient.Send(message);

        }
    }
}