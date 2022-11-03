using CompartilhaUtilidades.Model.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompartilhaUtilidades.Model.Entities
{
    public class Produto
    {
        public Produto()
        { }
         public int IdProduto { get; set; }
        public string Titulo { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public Tags Categoria { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public TipoCompartilhamento Acao { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Imagem> Imagens { get; set; }
        public DateTime DataInclusao { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }
    }
}
