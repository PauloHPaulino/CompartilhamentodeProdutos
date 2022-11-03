using CompartilhaUtilidades.Model.Enumeradores;
using System.ComponentModel.DataAnnotations;

namespace CompartilhaUtilidades.Model.Dtos
{
    public class EnderecoDto
    {
        public int IdEndereco { get; set; }

        [Required(ErrorMessage = "A rua é obrigatória")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O número é obrigatório")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O cep é obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório")]
        public string Estado { get; set; }
        public TipoResidenciaEnum TipoResidencia { get; set; }
    }
}
