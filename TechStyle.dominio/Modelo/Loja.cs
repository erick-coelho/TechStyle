using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TechStyle.dominio.Modelo
{
    public class Loja : IEntity
    {
        public int Id { get; private set; }
        public int Quantidade { get; private set; }
        public int QuantidadeMinima { get; private set; }
        public int IdProduto { get; private set; }
        [JsonIgnore]
        public Produto Produto { get; private set; }

        public Loja Cadastrar(int quantidade, int quantidadeMinima, int idProduto)
        {
            Quantidade = quantidade;
            QuantidadeMinima = quantidadeMinima;
            IdProduto = idProduto;
            return this;
        }

        public void Alterar(Loja lojaAlterada)
        {
            Quantidade = lojaAlterada.Quantidade;
            QuantidadeMinima = lojaAlterada.QuantidadeMinima;
        }
    }
}
