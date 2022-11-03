using CompartilhaUtilidades.Model.Dtos;

namespace CompartilhaUtilidades.Model.Entities
{
    public class ContatoTelefone
    {
        public ContatoTelefone(){}
      
        public ContatoTelefone(ContatoTelefoneDto contato)
        {
            IdContatoTelefone = contato.IdContatoTelefone;
            TelefoneFixo = contato.TelefoneFixo;
            TelefoneCelular = contato.TelefoneCelular;
            TelefoneRecado = contato.TelefoneRecado;
        }

        public int IdContatoTelefone { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneCelular { get; set; }
        public string TelefoneRecado { get; set; }
        public Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }
    }
}
