using System.ComponentModel.DataAnnotations;

namespace CompartilhaUtilidades.Model.Dtos
{
    public class ContatoTelefoneDto
    {
        public int IdContatoTelefone { get; set; }
        public string TelefoneFixo { get; set; }

        [Required(ErrorMessage = "O telefone celular é obrigatório")]
        public string TelefoneCelular { get; set; }
        public string TelefoneRecado { get; set; }
    }
}
