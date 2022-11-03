using System.ComponentModel.DataAnnotations;

namespace CompartilhaUtilidades.Model.Enumeradores
{
    public enum TipoCompartilhamento
    {
        [Display(Name = "Emprestar")]
        Emprestimo,
        [Display(Name = "Doar")]
        Doacao,
        [Display(Name = "Trocar")]
        Troca,
    }
}
