using CompartilhaUtilidades.Model.Dtos;
using CompartilhaUtilidades.Model.Enumeradores;
using CompartilhaUtilidades.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CompartilhaUtilidades.Model.Entities
{
    public class Usuario
    {
        public Usuario()
        { }

        public virtual int IdUsuario { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Login { get; set; }
        public virtual string Hash { get; set; }
        public virtual string Salt { get; set; }
        public virtual Guid CodigoUsuarioEmail { get; set; }
        public virtual DateTime DataDeNascimento { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public SexoEnum Sexo { get; set; }
        public virtual DateTime DataDoCadastro { get; set; }
        public virtual bool EmailValidado { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
        public virtual ICollection<ContatoTelefone> Contatos { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }

        public Usuario(UsuarioDto usuario)
        {
            Nome = usuario.Nome;
            Email = usuario.Email;
            Login = usuario.Login;
            Salt = SecurityManager.CreateSalt();
            Hash = SecurityManager.CreateHash(usuario.Senha, Salt);
            CodigoUsuarioEmail = Guid.NewGuid();
            DataDeNascimento = usuario.DataDeNascimento;
            DataDoCadastro = DateTime.Now;
            Sexo = usuario.Sexo;
            Endereco = AdicionarEndereco(usuario.Endereco);
            Contatos = AdicionarContato(usuario.Contato);
        }

        public void ValidaSeEmailJaEstaCadastrado(string email, string login, Interfaces.IUsuarioRepository usuarioRepository)
        {
            bool existeUsuario = usuarioRepository.Get(x => x.Email == email && x.Login != login).Any();
            if (existeUsuario)
            {
                throw new ArgumentException("E-mail já está cadastrado");
            }
        }

        private ICollection<Endereco> AdicionarEndereco(EnderecoDto endereco)
        {
            return new List<Endereco>
            {
                new Endereco(endereco)
            };
        }

        private ICollection<ContatoTelefone> AdicionarContato(ContatoTelefoneDto contato)
        {
            return new List<ContatoTelefone>
            {
                new ContatoTelefone(contato)
            };
        }

        public void Atualizar(UsuarioDto usuarioDto)
        {
            Nome = usuarioDto.Nome;
            Email = usuarioDto.Email;
            Sexo = usuarioDto.Sexo;
            DataDeNascimento = usuarioDto.DataDeNascimento;
            Endereco = AdicionarEndereco(usuarioDto.Endereco);
            Contatos = AdicionarContato(usuarioDto.Contato);
        }

        public bool ConfirmarEmail()
        {
            if (!EmailValidado)
            {
                return EmailValidado = true;
            }

            return false;
        }
    }
}
