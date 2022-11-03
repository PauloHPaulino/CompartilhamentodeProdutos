using CompartilhaUtilidades.Model.Dtos;
using CompartilhaUtilidades.Model.Enumeradores;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompartilhaUtilidades.Model.Entities
{
    public class Endereco
    {
        public Endereco() { }
        public Endereco(EnderecoDto endereco)
        {
            IdEndereco = endereco.IdEndereco;
            Logradouro = endereco.Logradouro;
            Numero = endereco.Numero;
            Cep = endereco.Cep;
            Cidade = endereco.Cidade;
            Bairro = endereco.Bairro;
            Estado = endereco.Estado;
            TipoResidencia = endereco.TipoResidencia;
        }

        public int IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public TipoResidenciaEnum TipoResidencia { get; set; }
        public Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }

    }
}
