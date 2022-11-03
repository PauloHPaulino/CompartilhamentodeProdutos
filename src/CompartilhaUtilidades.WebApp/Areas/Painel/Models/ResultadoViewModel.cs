using System;
using System.Collections.Generic;

namespace CompartilhaUtilidades.WebApp.Areas.Painel.Models
{
    public class ResultadoViewModel
    {
        public bool Sucesso { get; set; }
        public string Url { get; set; }
        public Nullable<int> Id { get; set; }
        public List<string> Erro { get; set; }
    }
}
