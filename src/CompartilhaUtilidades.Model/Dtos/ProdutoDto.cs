using System.ComponentModel.DataAnnotations;
using CompartilhaUtilidades.Model.Enumeradores;

namespace CompartilhaUtilidades.Model.Dtos
{
    public class ProdutoDto
    {
        public int IdProduto{ get; set; }

        [Required(ErrorMessage = "O Título é obrigatório")]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Por favor selecionar a Categoria!")]
        public Tags Categoria { get; set; }


        [Required(ErrorMessage = "Por favor selecionar o que deseja!")]
        public TipoCompartilhamento Acao { get; set; }

        public string Descricao { get; set; }

        

    }
}
