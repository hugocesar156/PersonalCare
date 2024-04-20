using PersonalCare.Domain.Entities;
using System.Net;
using System.Net.Mail;

namespace PersonalCare.Application.Services
{
    public class EmailService
    {
        public static void EnviarEmail(EmailEmpresa remetente, string destinatario, string assunto, string corpo)
        {
            var mensagem = new MailMessage(remetente.Email, destinatario, assunto, corpo)
            {
                IsBodyHtml = true
            };

            var smtpClient = new SmtpClient(remetente.Smtp)
            {
                Port = remetente.Porta,
                Credentials = new NetworkCredential(remetente.Email, remetente.Senha),
                EnableSsl = remetente.Ssl
            };

            smtpClient.Send(mensagem);
        }
    }
}
