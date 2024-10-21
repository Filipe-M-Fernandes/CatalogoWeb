using CatalogoWeb.Domain.Abstractions.Services;
using System.Net;
using System.Net.Mail;

namespace CatalogoWeb.Services
{
    public class EnviaEmailService : IEnviaEmailService
    {
        private readonly string _gmailSmtpServer = "smtp.gmail.com";
        private readonly int _gmailSmtpPort = 587;
        private readonly string _gmailUser = "filipemullerfernandes@gmail.com";
        private readonly string _gmailPassword = "uknv huep miks stnp";

        public async Task<bool> EnviaEmailLista(List<string> emailDestinatario, string tituloEmail, string conteudoEmail, bool conteudoHtml = true, MailPriority prioridade = MailPriority.Normal)
        {
            foreach (string destinatario in emailDestinatario)
            {
                await EnviaEmail(destinatario, tituloEmail, conteudoEmail, conteudoHtml, prioridade);
            }
            return true;
        }

        public async Task EnviaEmail(string destinatario, string tituloEmail, string conteudoEmail, bool conteudoHtml = true, MailPriority prioridade = MailPriority.Normal)
        {
            MailMessage message = new MailMessage()
            {
                From = new MailAddress( _gmailUser, "Catalogo Web")
            };
            message.To.Add(new MailAddress(destinatario));
            message.Subject = tituloEmail;
            message.Body = conteudoEmail;
            message.IsBodyHtml = conteudoHtml;
            message.Priority = prioridade;

            using (var client = new SmtpClient(_gmailSmtpServer, _gmailSmtpPort))
            {
                client.Credentials = new NetworkCredential(_gmailUser, _gmailPassword);
                client.EnableSsl = true;
                await client.SendMailAsync(message);
            }
        }

    }
}
