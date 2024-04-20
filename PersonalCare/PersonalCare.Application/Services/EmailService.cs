using PersonalCare.Domain.Entities;
using System.Net;
using System.Net.Mail;

namespace PersonalCare.Application.Services
{
    public class EmailService
    {
        public static void EnviarEmail(EmailEmpresa remetente, string destinatario, string assunto, string corpo)
        {
            var mensagem = new MailMessage(remetente.Email, destinatario, assunto, corpo);

            var smtpClient = new SmtpClient(remetente.Smtp)
            {
                Port = remetente.Porta,
                Credentials = new NetworkCredential(remetente.Email, remetente.Senha),
                EnableSsl = remetente.Ssl
            };

            smtpClient.Send(mensagem);
        }

        public static string GerarCodigoVerificacao()
        {
            var codigo = string.Empty;

            for (var i = 0; i < 5; i++)
            {
                codigo += new Random().Next(0, 9);
            }

            return codigo;
        }
    }
}
