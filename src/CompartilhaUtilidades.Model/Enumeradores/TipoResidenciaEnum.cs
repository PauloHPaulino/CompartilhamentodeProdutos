
using System.ComponentModel.DataAnnotations;

namespace CompartilhaUtilidades.Model.Enumeradores
{
    public enum TipoResidenciaEnum
    {
        [Display(Name = "Apartamento")]
        Apartamento,
        [Display(Name = "Casa")]
        Casa,
        [Display(Name = "Sobrado")]
        Sobrado
    }
}
