using PersonalCare.Domain.Entities;
using System.Net;
using System.Net.Mail;

namespace PersonalCare.Application.Services
{
    public class EmailService
    {
        public static void EnviarEmail(EmailEmpresa remetente, string destinatario, string assunto, string corpo, Dictionary<string, byte[]>? anexos)
        {
            var mensagem = new MailMessage(remetente.Email, destinatario, assunto, corpo)
            {
                IsBodyHtml = true
            };

            if (anexos is not null)
            {
                foreach (var item in anexos)
                {
                    var ms = new MemoryStream(item.Value);
                    var attachment = new Attachment(ms, item.Key);

                    mensagem.Attachments.Add(attachment);
                }
            }

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
