using System;
using System.Threading.Tasks;

namespace CompartilhaUtilidades.Model.Interfaces
{
    public interface IEmailService
    {
        Task Execute(string email, string login, string nomeUsuario, Guid codigoUsuarioEmail);
    }
}
