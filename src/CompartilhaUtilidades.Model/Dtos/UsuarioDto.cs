
using CompartilhaUtilidades.Model.Enumeradores;
using System;
using System.ComponentModel.DataAnnotations;

namespace CompartilhaUtilidades.Model.Dtos
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O endereço de e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Endereço de e-mail é inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O sexo é obrigatório")]
        public SexoEnum Sexo { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateTime DataDeNascimento { get; set; }
        public EnderecoDto Endereco { get; set; }
        public ContatoTelefoneDto Contato { get; set; }


    }
}
