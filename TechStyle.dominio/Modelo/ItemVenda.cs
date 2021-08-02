using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStyle.dominio.Modelo
{
    public class ItemVenda : IEntity
    {
        public int Id { get; private set; }
        public int IdProduto { get; private set; }
        public Produto Produto { get; set; }
        public int IdVenda { get; private set; }
        public Venda Venda { get; private set; }
        public int Quantidade { get; private set; }
        
        public void Registrar(int idProduto, int idVenda, int quantidade)
        {
            IdProduto = idProduto;
            IdVenda = idVenda;
            Quantidade = quantidade;
        }

        public ItemVenda Cadastrar(int idVenda, int idProduto, int quantidade)
        {
            IdVenda = idVenda;
            IdProduto = idProduto;
            Quantidade = quantidade;
            return this;
        }
    }
}
