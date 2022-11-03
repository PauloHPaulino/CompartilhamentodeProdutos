namespace CompartilhaUtilidades.Model.Entities
{
    public class Imagem
    {
        public int IdImagem { get; set; }
        public string Url { get; set; }
        public string Legenda { get; set; }
        public Produto Produto { get; set; }
        public int IdProduto { get; set; }
    }
}
