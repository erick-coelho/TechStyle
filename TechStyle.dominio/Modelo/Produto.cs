using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TechStyle.dominio.Modelo
{
    public class Produto : IEntity
    {
        public int Id { get; private set; }
        public decimal ValorDeVenda { get; private set; }
        public string Nome { get; private set; }
        public string SKU { get; private set; }
        public bool Ativo { get; private set; }

        [JsonIgnore]
        public int IdSegmento { get; private set; }
        public Segmento Segmento { get; private set; }
        public DetalheDoProduto DetalheDoProduto { get; private set; }
        public Estoque Estoque { get; private set; }
        public Loja Loja { get; private set; }
        public List<ItemVenda> ItensVenda { get; private set; }

        public Produto Cadastrar(decimal valorDeVenda, string nome, string sku, int idSegmento)
        {
            ValorDeVenda = valorDeVenda;
            Nome = nome;
            SKU = sku;
            IdSegmento = idSegmento;
            Ativo = false;
            return this;
        }
        public void Alterar(Produto produto)
        {
            SKU = produto.SKU;
            ValorDeVenda = produto.ValorDeVenda;
            Nome = produto.Nome;
            IdSegmento = produto.IdSegmento;
        }

        public void AtualizarAtivo(bool atv)
        {
            Ativo = atv;
        }

    }
}
