using CompartilhaUtilidades.Model.Dtos;
using CompartilhaUtilidades.Model.Entities;
using CompartilhaUtilidades.Model.Interfaces;
using CompartilhaUtilidades.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompartilhaUtilidades.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;

        public UsuarioService(IUnitOfWork unitOfWork, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }

        public virtual UsuarioDto Autenticar(LoginDto loginDto)
        {
            var usuario = _unitOfWork
                .UsuarioRepository
                .Get(q => q.Login.ToLower().Equals(loginDto.Usuario), null, "Endereco,Contatos", true)
                .FirstOrDefault();

            if (!SecurityManager.Validate(loginDto.Senha, usuario.Salt, usuario.Hash))
                return null;

            return new UsuarioDto
            {
                IdUsuario = usuario.IdUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Login = usuario.Login
            };
        }

        public IEnumerable<UsuarioDto> Filtrar()
        {
            var query = _unitOfWork
                .UsuarioRepository
                .Get(null, o => o.OrderBy(u => u.Nome), "Endereco,Contatos", true)
                .Select(s => new UsuarioDto
                {
                    IdUsuario = s.IdUsuario,
                    Nome = s.Nome,
                    Email = s.Email,
                    Login = s.Login
                });
            return query.ToList();
        }

        public UsuarioDto Selecionar(int id)
        {
            var usuario = _unitOfWork
                .UsuarioRepository
                .Get(x => x.IdUsuario == id, null, "Endereco,Contatos", true).FirstOrDefault();

            return new UsuarioDto
            {
                IdUsuario = usuario.IdUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Login = usuario.Login,
                DataDeNascimento = usuario.DataDeNascimento,
                Sexo = usuario.Sexo,
                Endereco = ConverteEnderecoParaDto(usuario.Endereco),
                Contato = ConverteContatoParaDto(usuario.Contatos)
            };
        }

        private ContatoTelefoneDto ConverteContatoParaDto(ICollection<ContatoTelefone> contatos)
        {
            var contatoCliente = contatos.FirstOrDefault();
            if (contatoCliente == default) return new ContatoTelefoneDto();
            return new ContatoTelefoneDto
            {
                TelefoneCelular = contatoCliente.TelefoneCelular,
                TelefoneFixo = contatoCliente.TelefoneFixo,
                TelefoneRecado = contatoCliente.TelefoneRecado
            };
        }

        private EnderecoDto ConverteEnderecoParaDto(ICollection<Endereco> endereco)
        {
            var enderecoCliente = endereco.FirstOrDefault();
            if (enderecoCliente == default) return new EnderecoDto();
            return new EnderecoDto
            {
                Bairro = enderecoCliente.Bairro,
                Cep = enderecoCliente.Cep,
                Cidade = enderecoCliente.Cidade,
                Estado = enderecoCliente.Estado,
                Logradouro = enderecoCliente.Logradouro,
                Numero = enderecoCliente.Numero,
                TipoResidencia = enderecoCliente.TipoResidencia
            };
        }

        public async Task<ResultadoDto> Excluir(int id)
        {
            _unitOfWork.UsuarioRepository.Delete(id);
            var sucesso = await _unitOfWork.SaveChangesAsync();
            return new ResultadoDto
            {
                Sucesso = sucesso
            };
        }

        public async Task<ResultadoDto> Salvar(UsuarioDto usuario)
        {
            try
            {
                if (usuario.IdUsuario > 0)
                {
                    AtualizaUsuario(usuario);
                }
                else
                {
                    var user = await AdicionaUsuario(usuario);
                    usuario.IdUsuario = user.IdUsuario;
                }

                var sucesso = await _unitOfWork.SaveChangesAsync();

                return new ResultadoDto
                {
                    Sucesso = sucesso,
                    Id = usuario.IdUsuario
                };

            }
            catch (Exception ex)
            {
                return new ResultadoDto
                {
                    Sucesso = false,
                    Erros = new List<string> { ex.Message }
                };
            }
        }

        private async Task<Usuario> AdicionaUsuario(UsuarioDto usuarioDto)
        {
            if (usuarioDto is null)
            {
                throw new ArgumentNullException(nameof(usuarioDto));
            }

            var usuario = new Usuario(usuarioDto);
            usuario.ValidaSeEmailJaEstaCadastrado(usuarioDto.Email, usuarioDto.Login, _unitOfWork.UsuarioRepository);
            _unitOfWork.UsuarioRepository.Add(usuario);
            await _emailService.Execute(usuarioDto.Email, usuarioDto.Login, usuarioDto.Nome, usuario.CodigoUsuarioEmail);

            return usuario;
        }

        private async Task AtualizaUsuario(UsuarioDto usuarioDto)
        {
            var usuario = _unitOfWork.UsuarioRepository.
                Get(x => x.IdUsuario == usuarioDto.IdUsuario, null, "Endereco,Contatos", true)
                .SingleOrDefault();

            if (usuario == default)
            {
                throw new ArgumentException("Usuário inválido para atualização");
            }

            usuario.ValidaSeEmailJaEstaCadastrado(usuarioDto.Email, usuarioDto.Login, _unitOfWork.UsuarioRepository);
            usuarioDto.Endereco.IdEndereco = usuario.Endereco.First().IdEndereco;
            usuarioDto.Contato.IdContatoTelefone = usuario.Contatos.First().IdContatoTelefone;
            usuario.Atualizar(usuarioDto);
            _unitOfWork.UsuarioRepository.Update(usuario);
            await _emailService.Execute(usuarioDto.Email, usuarioDto.Login, usuarioDto.Nome, usuario.CodigoUsuarioEmail);
        }

        public async Task<bool> ConfirmarEmail(Guid idConfirmacaoEmail)
        {
            try
            {
                var usuario = _unitOfWork.UsuarioRepository.
                   Get(x => x.CodigoUsuarioEmail == idConfirmacaoEmail, null, "", true)
                   .FirstOrDefault();

                if (usuario == default)
                {
                    throw new ArgumentException("Oops! Chave de confirmação de e-mail inválida");
                }

                var emailConfirmado = usuario.ConfirmarEmail();
                _unitOfWork.UsuarioRepository.Update(usuario);
                await _unitOfWork.SaveChangesAsync();
                return emailConfirmado;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
            catch
            {                
                throw new ArgumentException("Oops! Ocorreu uma falha ao confirmar o e-mail");
            }
        }
    }
}
