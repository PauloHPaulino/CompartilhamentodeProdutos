using CompartilhaUtilidades.Model.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace CompartilhaUtilidades.Service
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<EmailOptions> _appSettings;

        private const string InformacaoEmailHtml = @"
                                Oi, #Nome#,<br> <br>                            
                                Sua conta no Compartilha está quase pronta. Para ativá-la, por favor confirme o seu endereço de email clicando no link abaixo.<br><br> 
                                <a href="" #Url##Codigo# "">Ativar minha conta/Confirmar meu email</a> <br><br> 
                                Sua conta não será ativada até que seu email seja confirmado.<br><br>
                                Se você não se cadastrou no Compartilha recentemente, por favor ignore este email.<br> <br> 
                                Equipe Compartilha Utilidades";


        public EmailService(IOptions<EmailOptions> appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task Execute(string email, string login, string nomeUsuario, Guid codigoUsuarioEmail)
        {
            var apiKey = _appSettings.Value.KeyEmail;
            var emailOrigem = _appSettings.Value.EmailBase;
            var urlEmail = _appSettings.Value.UrlEmail;

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(emailOrigem, "Compartilha Utilidades");
            var subject = "Email de Validação";
            var to = new EmailAddress(email, "Confirme seu e-mail");
            var plainTextContent = "Favor Validar seu e-mail";
            string htmlContent = InformacaoEmailHtml.Replace("#Nome#", nomeUsuario)
                                                    .Replace("#Login#", login)
                                                    .Replace("#Url#", urlEmail)
                                                    .Replace("#Codigo#", codigoUsuarioEmail.ToString());
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
