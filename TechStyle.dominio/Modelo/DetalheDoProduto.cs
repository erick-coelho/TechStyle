using System.Text.Json.Serialization;

namespace TechStyle.dominio.Modelo
{
    public class DetalheDoProduto : IEntity
    {
        public int Id { get; private set; }
        public string Marca { get; private set; }
        public string Tamanho { get; private set; }
        public string Cor { get; private set; }
        public string Modelo { get; private set; }

        //EntityFramework
        [JsonIgnore]
        public Produto Produto { get; private set; }
        public int IdProduto { get; private set; }

        public DetalheDoProduto Cadastrar(string marca, string tamanho, string cor, string modelo, int idProduto)
        {
            Marca = marca;
            Tamanho = tamanho;
            Cor = cor;
            Modelo = modelo;
            IdProduto = idProduto;
            return this;
        }

        public void Alterar(DetalheDoProduto alterado)
        {
            Marca = alterado.Marca;
            Tamanho = alterado.Tamanho;
            Cor = alterado.Cor;
            Modelo = alterado.Modelo;
        }

        public void SetarIdProduto(int id)
        {
            IdProduto = id;
        }

        private string SetMarca(string marca) => string.IsNullOrEmpty(marca.Trim()) ? Marca : marca;
        private string SetTamanho(string tamanho) => string.IsNullOrEmpty(tamanho.Trim()) ? Tamanho : tamanho;
        private string SetCor(string cor) => string.IsNullOrEmpty(cor.Trim()) ? Cor : cor;
        private string SetModelo(string modelo) => string.IsNullOrEmpty(modelo.Trim()) ? Modelo : modelo;

    }
}