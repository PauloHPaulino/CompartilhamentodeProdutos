using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompartilhaUtilidades.Model.Dtos;

namespace CompartilhaUtilidades.Model.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioDto Autenticar(LoginDto loginDto);
        IEnumerable<UsuarioDto> Filtrar();
        UsuarioDto Selecionar(int id);
        Task<ResultadoDto> Excluir(int id);
        Task<ResultadoDto> Salvar(UsuarioDto usuario);
        Task<bool> ConfirmarEmail(Guid idConfirmacaoEmail);
    }
}
