using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStyle.dominio.Modelo
{
    public class Venda : IEntity
    {
        public int Id { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal Desconto { get; private set; }
        public DateTime Data { get; private set; }
        public List<ItemVenda> ItensVenda { get; private set; }

        internal void Alterar(Venda vendaAlterada)
        {
            ValorTotal = vendaAlterada.ValorTotal;
            Desconto = vendaAlterada.Desconto;
        }


        public Venda Cadastrar()
        {
            Data = DateTime.Now;
            return this;
        }

        public void AdicionarValorItemAoTotal(decimal valor)
        {
            ValorTotal += valor;
        }
    }
}
