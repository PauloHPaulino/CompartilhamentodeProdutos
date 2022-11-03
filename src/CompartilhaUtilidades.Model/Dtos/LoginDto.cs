using System;
using System.ComponentModel.DataAnnotations;

namespace CompartilhaUtilidades.Model.Dtos
{
    public class LoginDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o usuário")]
		public string Usuario { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a senha")]
		public string Senha { get; set; }
    }
}
