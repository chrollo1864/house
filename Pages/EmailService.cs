using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailService
{
    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var smtpClient = new SmtpClient("mail.phantasma.me")
        {
            Port = 587,
            Credentials = new NetworkCredential("realestate@phantasma.me", "realestatesmtp"),
            EnableSsl = true
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("realestate@phantasma.me"),
            Subject = subject,
            Body = message,
            IsBodyHtml = false,
        };

        mailMessage.To.Add(toEmail);

        await smtpClient.SendMailAsync(mailMessage);
    }
}
