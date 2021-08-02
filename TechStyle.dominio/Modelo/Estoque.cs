using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TechStyle.dominio.Modelo
{
    public class Estoque : IEntity
    {
        public int Id { get; private set; }
        public int QuantidadeTotal { get; private set; }
        public int QuantidadeMinima { get; private set; }
        public int QuantidadeAtual { get; set; }
        public string Local { get; private set; }

        //EntityFramework

        public int IdProduto { get; private set; }
        [JsonIgnore]
        public Produto Produto { get; private set; }

        public Estoque Cadastrar(int idProduto, int quantidadeTotal, int quantidadeMinima, int quantidadeAtual, string local)
        {
            IdProduto = idProduto;
            QuantidadeTotal = quantidadeTotal;
            QuantidadeMinima = quantidadeMinima;
            QuantidadeAtual = quantidadeAtual;
            Local = local;
            return this;
        }

        public void Alterar(Estoque estoqueAlterado)
        {
            QuantidadeTotal = estoqueAlterado.QuantidadeTotal;
            QuantidadeMinima = estoqueAlterado.QuantidadeMinima;
            QuantidadeAtual = estoqueAlterado.QuantidadeAtual;
            Local = estoqueAlterado.Local;
        }
    }
}
