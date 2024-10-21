using System.Net.Mail;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface IEnviaEmailService
    {
        Task<bool> EnviaEmailLista(List<string> emailDestinatario, string tituloEmail, string conteudoEmail, bool conteudoHtml = true, MailPriority prioridade = MailPriority.Normal);
        Task EnviaEmail(string destinatario, string tituloEmail, string conteudoEmail, bool conteudoHtml = true, MailPriority prioridade = MailPriority.Normal);
    }
}
